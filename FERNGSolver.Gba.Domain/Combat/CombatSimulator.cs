using FERNGSolver.Gba.Domain.RNG;

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
        public static Result Simulate(IRng rng, ICombatUnit attacker, ICombatUnit defender)
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
                    ExecutePhase(rng, attackerUnit, defenderUnit);
                    if (defenderUnit.CurrentHp <= 0)
                    {
                        defenderUnit.CurrentHp = 0;
                        break;
                    }
                    if (attacker.IsDoubleAttack)
                    {
                        ExecutePhase(rng, attackerUnit, defenderUnit);
                        if (defenderUnit.CurrentHp <= 0)
                        {
                            defenderUnit.CurrentHp = 0;
                            break;
                        }
                    }
                    ++a;
                }

                if (d < defender.PhaseCount)
                {
                    ExecutePhase(rng, defenderUnit, attackerUnit);
                    if (attackerUnit.CurrentHp <= 0)
                    {
                        attackerUnit.CurrentHp = 0;
                        break;
                    }
                    if (defender.IsDoubleAttack)
                    {
                        ExecutePhase(rng, defenderUnit, attackerUnit);
                        if (attackerUnit.CurrentHp <= 0)
                        {
                            attackerUnit.CurrentHp = 0;
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

        // フェーズを実行し、Unitを更新する
        private static void ExecutePhase(IRng rng, Unit attackerSide, Unit defenderSide)
        {
            // TODO
            int level = 0;
            bool hasSureStrike = false;
            bool isPoisonWeapon = false;
            bool hasGreatShield = false;
            bool hasPierce = false;
            bool hasSilencer = false;
            bool isCursedWeapon = false;
            int luck = 0;

            bool isHit = false;
            bool isGreatShieldActive = false;
            bool isPierceActive = false;
            bool isSilencerActive = false;
            int damage = 0;

            // 必的判定
            if (hasSureStrike && rng.Next() < level)
            {
                isHit = true;
            }
            // 命中判定
            else if ((rng.Next() + rng.Next()) / 2 < attackerSide.CombatUnit.HitRate)
            {
                isHit = true;

                // 大盾判定
                // 武器が毒/ストーンの時、大盾判定をスキップ
                if (!isPoisonWeapon && hasGreatShield && rng.Next() < level)
                {
                    isGreatShieldActive = true;
                }
                // 貫通判定
                else if(hasPierce && rng.Next() < level)
                {
                    isPierceActive = true;
                }
            }

            if (isHit)
            {
                // 命中していたら必殺判定
                if (rng.Next() < attackerSide.CombatUnit.CriticalRate)
                {
                    // 必殺が出たら瞬殺判定（封印以外）
                    // 瞬殺のみスキルを持っていなくても発動する
                    // TODO ボス系と魔王系には確率が下がる
                    if (rng.Next() < 50 && hasSilencer)
                    {
                        isSilencerActive = true;
                    }
                    damage = attackerSide.CombatUnit.Power * 3;
                }
                else
                {
                    damage = attackerSide.CombatUnit.Power;
                }

                // デビルアクス判定
                if (isCursedWeapon && rng.Next() < (31 - luck))
                {
                    attackerSide.CurrentHp -= damage;
                }
                // アサシンは斧を持てないので呪いと瞬殺は両立しない
                else if (isSilencerActive)
                {
                    defenderSide.CurrentHp = 0;
                }
                else
                {
                    defenderSide.CurrentHp -= damage;
                }
            }
        }
    }
}
