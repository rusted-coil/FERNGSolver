using FERNGSolver.Radiance.Domain.Combat.Service;

namespace FERNGSolver.Radiance.Domain.Combat
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
        public static Result Simulate(ICombatRngService rngService, ICombatUnit attacker, ICombatUnit defender)
        {
            var attackerUnit = new Unit(attacker, UnitSide.Player);
            var defenderUnit = new Unit(defender, UnitSide.Enemy);

            // 攻撃側→防御側の順でPhaseCountがなくなるまで交互に攻撃を行う
            // どちらかが死んだら終わり
            int a = 0, d = 0;
            while (a < attacker.PhaseCount || d < defender.PhaseCount)
            {
                if (a < attacker.PhaseCount)
                {
                    if (!ExecutePhase(rngService, attackerUnit, defenderUnit))
                    {
                        break;
                    }
                    ++a;
                }

                if (d < defender.PhaseCount)
                {
                    if (!ExecutePhase(rngService, defenderUnit, attackerUnit))
                    {
                        break;
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
            public UnitSide UnitSide { get; }

            public Unit(ICombatUnit combatUnit, UnitSide unitSide)
            {
                CombatUnit = combatUnit;
                CurrentHp = combatUnit.Hp;
                UnitSide = unitSide;
            }
        }

        private static int GetLevel(this Unit unit) => unit.CombatUnit.StatusDetail.Level;
        private static bool IsAbsorbWeapon(this Unit unit) => unit.CombatUnit.StatusDetail.WeaponType == Const.WeaponType.Absorb;
        private static bool IsPoisonWeapon(this Unit unit) => unit.CombatUnit.StatusDetail.WeaponType == Const.WeaponType.Poison;
        private static bool IsCursedWeapon(this Unit unit) => unit.CombatUnit.StatusDetail.WeaponType == Const.WeaponType.Cursed;

        enum AttackType
        {
            Normal,
            Sol,
            Luna,
            Astra,
        }

        // フェーズを実行し、Unitを更新する
        // どちらかが死んでいたらfalseを返す
        private static bool ExecutePhase(ICombatRngService rngService, Unit attackerSide, Unit defenderSide)
        {
            int attackCount = attackerSide.CombatUnit.StatusDetail.WeaponType == Const.WeaponType.Brave ? 2 : 1;

            // 連続判定
            if (attackerSide.CombatUnit.StatusDetail.HasAdept && rngService.CheckActivateAdept(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide))
            {
                attackCount *= 2;
            }

            List<AttackType> attackTypes = new List<AttackType>();
            for (int i = 0; i < attackCount; ++i)
            {
                // 天空判定
                if (attackerSide.CombatUnit.StatusDetail.HasAether && rngService.CheckActivateAether(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide))
                {
                    // 太陽→月光の2回攻撃
                    attackTypes.Add(AttackType.Sol);
                    attackTypes.Add(AttackType.Luna);
                }
                // 流星判定
                else if (attackerSide.CombatUnit.StatusDetail.HasAstra && rngService.CheckActivateAstra(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide))
                {
                    // ダメージ半分の5回攻撃
                    attackTypes.Add(AttackType.Astra);
                    attackTypes.Add(AttackType.Astra);
                    attackTypes.Add(AttackType.Astra);
                    attackTypes.Add(AttackType.Astra);
                    attackTypes.Add(AttackType.Astra);
                }
                else
                {
                    attackTypes.Add(AttackType.Normal);
                }
            }

            for (int i = 0; i < attackTypes.Count; ++i)
            {
                // 命中判定
                if (rngService.CheckHit(attackerSide.CombatUnit.HitRate, attackerSide.UnitSide))
                {
                    // 必殺判定
                    if (rngService.CheckCritical(attackerSide.CombatUnit.CriticalRate, attackerSide.UnitSide))
                    {
                    }
                    // 武器破壊判定
                    if (attackerSide.CombatUnit.StatusDetail.HasCorrode)
                    {
                    }
                    // 衝撃判定（戦闘には影響なし）
                    // 鳴動判定
                    // 月光判定
                    // 陽光判定
                    // 瞬殺判定
                    // カウンター判定
                    // 祈り判定
                    // キャンセル判定
                    // 狙撃判定
                    // 太陽判定
                    // 翼の守護判定
                    // 
                }
            }

            /*

            bool isHit = false;
            bool isGreatShieldActive = false;
            bool isPierceActive = false;
            bool isSilencerActive = false;
            int damage = 0;

            // 必的判定
            if (attackerSide.HasSureStrike() && rngService.CheckActivateSureStrike(attackerSide.GetLevel(), attackerSide.UnitSide))
            {
                isHit = true;
            }
            // 命中判定
            else if (rngService.CheckHit(attackerSide.CombatUnit.HitRate, attackerSide.UnitSide))
            {
                isHit = true;

                // 大盾判定
                // 武器が毒/ストーンの時、大盾判定をスキップ
                if (!attackerSide.IsPoisonWeapon() && defenderSide.HasGreatShield() && rngService.CheckActivateGreatShield(defenderSide.GetLevel(), defenderSide.UnitSide))
                {
                    isGreatShieldActive = true;
                }
                // 貫通判定
                else if(attackerSide.HasPierce() && rngService.CheckActivatePierce(attackerSide.GetLevel(), attackerSide.UnitSide))
                {
                    isPierceActive = true;
                }
            }

            if (isHit)
            {
                // 貫通ダメージは必殺に乗る
                int power = (isPierceActive ? attackerSide.CombatUnit.Power + attackerSide.CombatUnit.StatusDetail.OpponentDefense : attackerSide.CombatUnit.Power);

                // 命中していたら必殺判定
                if (rngService.CheckCritical(attackerSide.CombatUnit.CriticalRate, attackerSide.UnitSide))
                {
                    // 必殺が出たら瞬殺判定（封印以外）
                    // 瞬殺のみスキルを持っていなくても判定する
                    // 敵がラスボスなら瞬殺判定をスキップ
                    if(defenderSide.CombatUnit.StatusDetail.BossType != Const.BossType.FinalBoss
                        && rngService.CheckActivateSilencer(defenderSide.CombatUnit.StatusDetail.BossType, attackerSide.HasSilencer(), attackerSide.UnitSide))
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
                if (attackerSide.IsCursedWeapon() && rngService.CheckActivateCurse(attackerSide.CombatUnit.StatusDetail.Luck, attackerSide.UnitSide))
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
            }*/

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
