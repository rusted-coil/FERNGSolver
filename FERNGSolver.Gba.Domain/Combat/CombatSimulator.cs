using FERNGSolver.Gba.Domain.Combat.Service;

namespace FERNGSolver.Gba.Domain.Combat
{
    public static class CombatSimulator
    {
        public sealed class Result
        {
            public int AttackerHp { get; }
            public int DefenderHp { get; }

            public Result(int attackerHp, int defenderHp)
            {
                AttackerHp = attackerHp;
                DefenderHp = defenderHp;
            }
        }

        /// <summary>
        /// RNGを進め、戦闘をシミュレートした結果を得ます。
        /// </summary>
        public static Result Simulate(ICombatRngService rngService, ICombatUnit attacker, ICombatUnit defender, bool isBindingBlade)
        {
            var attackerUnit = new Unit(attacker);
            var defenderUnit = new Unit(defender);

            // 攻撃側→防御側の順でPhaseCountがなくなるまで交互に攻撃を行う
            // どちらかが死んだら終わり
            int a = 0, d = 0;
            while (a < attacker.PhaseCount || d < defender.PhaseCount)
            {
                if (a < attacker.PhaseCount)
                {
                    if (!ExecutePhase(rngService, attackerUnit, defenderUnit, isBindingBlade))
                    {
                        break;
                    }
                    if (attacker.StatusDetail.WeaponType == Const.WeaponType.Brave)
                    {
                        if (!ExecutePhase(rngService, attackerUnit, defenderUnit, isBindingBlade))
                        {
                            break;
                        }
                    }
                    ++a;
                }

                if (d < defender.PhaseCount)
                {
                    if (!ExecutePhase(rngService, defenderUnit, attackerUnit, isBindingBlade))
                    {
                        break;
                    }
                    if (defender.StatusDetail.WeaponType == Const.WeaponType.Brave)
                    {
                        if (!ExecutePhase(rngService, defenderUnit, attackerUnit, isBindingBlade))
                        {
                            break;
                        }
                    }
                    ++d;
                }
            }

            return new Result(attackerUnit.CurrentHp, defenderUnit.CurrentHp);
        }

        private class Unit
        {
            public ICombatUnit CombatUnit { get; }
            public int CurrentHp { get; set; }

            public Unit(ICombatUnit combatUnit)
            {
                CombatUnit = combatUnit;
                CurrentHp = combatUnit.Hp;
            }
        }

        private static int GetLevel(this Unit unit) => unit.CombatUnit.StatusDetail.Level;
        private static bool HasSureStrike(this Unit unit) => unit.CombatUnit.StatusDetail.SkillType == Const.SkillType.SureStrike;
        private static bool HasGreatShield(this Unit unit) => unit.CombatUnit.StatusDetail.SkillType == Const.SkillType.GreatShield;
        private static bool HasPierce(this Unit unit) => unit.CombatUnit.StatusDetail.SkillType == Const.SkillType.Pierce;
        private static bool HasSilencer(this Unit unit) => unit.CombatUnit.StatusDetail.SkillType == Const.SkillType.Silencer;
        private static bool IsAbsorbWeapon(this Unit unit) => unit.CombatUnit.StatusDetail.WeaponType == Const.WeaponType.Absorb;
        private static bool IsPoisonWeapon(this Unit unit) => unit.CombatUnit.StatusDetail.WeaponType == Const.WeaponType.Poison;
        private static bool IsCursedWeapon(this Unit unit) => unit.CombatUnit.StatusDetail.WeaponType == Const.WeaponType.Cursed;

        // フェーズを実行し、Unitを更新する
        // どちらかが死んでいたらfalseを返す
        private static bool ExecutePhase(ICombatRngService rngService, Unit attackerSide, Unit defenderSide, bool isBindingBlade)
        {
            bool isHit = false;
            bool isGreatShieldActive = false;
            bool isPierceActive = false;
            bool isSilencerActive = false;
            int damage = 0;

            // 必的判定
            if (attackerSide.HasSureStrike() && rngService.CheckActivateSureStrike(attackerSide.GetLevel()))
            {
                isHit = true;
            }
            // 命中判定
            else if (rngService.CheckHit(attackerSide.CombatUnit.HitRate))
            {
                isHit = true;

                // 大盾判定
                // 武器が毒/ストーンの時、大盾判定をスキップ
                if (!attackerSide.IsPoisonWeapon() && defenderSide.HasGreatShield() && rngService.CheckActivateGreatShield(defenderSide.GetLevel()))
                {
                    isGreatShieldActive = true;
                }
                // 貫通判定
                else if(attackerSide.HasPierce() && rngService.CheckActivatePierce(attackerSide.GetLevel()))
                {
                    isPierceActive = true;
                }
            }

            if (isHit)
            {
                // 貫通ダメージは必殺に乗る
                int power = (isPierceActive ? attackerSide.CombatUnit.Power + attackerSide.CombatUnit.StatusDetail.OpponentDefense : attackerSide.CombatUnit.Power);

                // 命中していたら必殺判定
                if (rngService.CheckCritical(attackerSide.CombatUnit.CriticalRate))
                {
                    // 必殺が出たら瞬殺判定（封印以外）
                    // 瞬殺のみスキルを持っていなくても判定する
                    // 敵がラスボスなら瞬殺判定をスキップ
                    if(!isBindingBlade
                        && defenderSide.CombatUnit.StatusDetail.BossType != Const.BossType.FinalBoss
                        && rngService.CheckActivateSilencer(defenderSide.CombatUnit.StatusDetail.BossType)
                        && attackerSide.HasSilencer())
                    {
                        isSilencerActive = true;
                    }
                    damage = power * 3;
                }
                else
                {
                    damage = power;
                }

                // TODO 自分がデビルアクスの呪い発動で相手が大盾発動の場合、受けるダメージは？

                // デビルアクス判定
                // アサシンは斧を持てないので呪いと瞬殺は両立しない
                if (attackerSide.IsCursedWeapon() && rngService.CheckActivateCurse(attackerSide.CombatUnit.StatusDetail.Luck))
                {
                    attackerSide.CurrentHp -= damage;
                }
                else if (isSilencerActive)
                {
                    defenderSide.CurrentHp = 0; // 瞬殺は大盾を無視する
                }
                else
                {
                    if (!isGreatShieldActive)
                    {
                        if (attackerSide.IsAbsorbWeapon())
                        {
                            attackerSide.CurrentHp = Math.Min(
                                attackerSide.CombatUnit.StatusDetail.MaxHp,
                                attackerSide.CurrentHp + Math.Min(defenderSide.CurrentHp, damage));
                        }
                        defenderSide.CurrentHp -= damage;
                    }
                }
            }

            bool result = true;
            if (attackerSide.CurrentHp <= 0)
            {
                attackerSide.CurrentHp = 0;
                result = false;
            }
            if (defenderSide.CurrentHp <= 0)
            {
                defenderSide.CurrentHp = 0;
                result = false;
            }
            return result;
        }
    }
}
