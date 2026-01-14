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
            public int WeaponUses { get; set; }
            public UnitSide UnitSide { get; }

            public Unit(ICombatUnit combatUnit, UnitSide unitSide)
            {
                CombatUnit = combatUnit;
                CurrentHp = combatUnit.Hp;
                WeaponUses = combatUnit.StatusDetail.WeaponUses;
                UnitSide = unitSide;
            }
        }

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
                if (attackerSide.CombatUnit.StatusDetail.HasAether
                    && attackerSide.CombatUnit.StatusDetail.WeaponType != Const.WeaponType.MagicSword // 剣の間接攻撃では発動しない
                    && rngService.CheckActivateAether(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide))
                {
                    // 太陽→月光の2回攻撃
                    attackTypes.Add(AttackType.Sol);
                    attackTypes.Add(AttackType.Luna);
                }
                // 流星判定
                else if (attackerSide.CombatUnit.StatusDetail.HasAstra
                    && attackerSide.CombatUnit.StatusDetail.WeaponType != Const.WeaponType.MagicSword // 剣の間接攻撃では発動しない
                    && attackerSide.WeaponUses >= 2 // 流星は武器耐久残り2以上の時のみ判定
                    && rngService.CheckActivateAstra(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide))
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

            int counterDamage = 0;

            for (int i = 0; i < attackTypes.Count; ++i)
            {
                // 武器耐久がなくなっていたら打ち切り
                if (attackerSide.WeaponUses <= 0)
                {
                    break;
                }

                // 命中判定
                if (rngService.CheckHit(attackerSide.CombatUnit.HitRate, attackerSide.UnitSide))
                {
                    int damage = attackerSide.CombatUnit.Power;
                    bool isCritical = false;

                    // 必殺判定
                    if (rngService.CheckCritical(attackerSide.CombatUnit.CriticalRate, attackerSide.UnitSide))
                    {
                        damage *= 3;
                        isCritical = true;
                    }
                    // 武器破壊判定
                    if (attackerSide.CombatUnit.StatusDetail.HasCorrode && rngService.CheckActivateCorrode(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide))
                    {
                        // CEIL(Lv/4)
                        defenderSide.WeaponUses -= (attackerSide.CombatUnit.StatusDetail.Level + 3) / 4;
                    }
                    // 衝撃判定
                    if (attackerSide.CombatUnit.StatusDetail.HasStun && rngService.CheckActivateStun(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide))
                    {
                        // 戦闘には影響なし
                    }
                    // 鳴動判定
                    // TODO 相手が漆黒の騎士とアシュナードなら判定しない
                    if (attackerSide.CombatUnit.StatusDetail.HasColossus && rngService.CheckActivateColossus(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide))
                    {
                        // 魔法攻撃武器でも力で計算
                        damage += (attackerSide.CombatUnit.StatusDetail.Str / 4);
                    }
                    // 月光判定
                    if (attackTypes[i] == AttackType.Luna || (attackerSide.CombatUnit.StatusDetail.HasLuna && attackerSide.CombatUnit.StatusDetail.WeaponType != Const.WeaponType.MagicSword && rngService.CheckActivateLuna(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide)))
                    {
                        // 必殺が出ていても上書きして月光の素のダメージを適用する
                        damage = attackerSide.CombatUnit.Power + attackerSide.CombatUnit.StatusDetail.OpponentDefense / 2;
                    }
                    // 陽光判定
                    if (attackerSide.CombatUnit.StatusDetail.HasFlare && rngService.CheckActivateFlare(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide))
                    {
                        // 必殺が出ていても上書きして陽光の素のダメージを適用する
                        damage = attackerSide.CombatUnit.Power + attackerSide.CombatUnit.StatusDetail.OpponentDefense / 2;
                    }
                    // 瞬殺判定
                    // 必殺発動時しか瞬殺の効果は無いが、スキルを持っていれば判定は行う
                    // TODO 相手がボスなら判定しない
                    if (attackerSide.CombatUnit.StatusDetail.HasLethality && rngService.CheckActivateLethality(attackerSide.UnitSide) && isCritical)
                    {
                        damage = defenderSide.CurrentHp;
                    }
                    // カウンター判定
                    // TODO 相手が漆黒の騎士とアシュナードなら判定しない
                    if (defenderSide.CombatUnit.StatusDetail.HasCounter && rngService.CheckActivateCounter(defenderSide.CombatUnit.StatusDetail.Tec, defenderSide.UnitSide))
                    {
                        counterDamage += damage / 2;
                    }
                    // 祈り判定
                    if (defenderSide.CombatUnit.StatusDetail.HasMiracle && defenderSide.CurrentHp <= damage && rngService.CheckActivateMiracle(defenderSide.CombatUnit.StatusDetail.Luck, defenderSide.UnitSide))
                    {
                        damage = defenderSide.CurrentHp / 2;
                    }
                    // キャンセル判定
                    if (attackerSide.CombatUnit.StatusDetail.HasGuard && rngService.CheckActivateGuard(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide))
                    {
                    }
                    // 狙撃判定
                    if (attackerSide.CombatUnit.StatusDetail.HasDeadeye && rngService.CheckActivateDeadeye(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide))
                    {
                    }
                    // 太陽判定
                    if (attackerSide.CombatUnit.StatusDetail.HasSol && rngService.CheckActivateSol(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide))
                    {
                    }
                    // 翼の守護判定
                    if (defenderSide.CombatUnit.StatusDetail.HasCancel && rngService.CheckActivateCancel(defenderSide.CombatUnit.StatusDetail.Tec, defenderSide.UnitSide))
                    {
                        damage = 0;
                    }
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
