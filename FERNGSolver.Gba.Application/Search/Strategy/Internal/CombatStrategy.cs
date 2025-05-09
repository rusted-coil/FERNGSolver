using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Search.Strategy.Internal
{
    internal sealed class CombatStrategy : ISearchStrategy
    {
        private CombatStrategyArgs m_Args;

        public CombatStrategy(CombatStrategyArgs args)
        {
            m_Args = args;
        }

        public bool Check(IRng currentRng, bool allowsAdvance)
        {
            var rng = allowsAdvance ? currentRng : RngFactory.CreateFromRng(currentRng);

            // 攻撃側→防御側の順でPhaseCountがなくなるまで交互に攻撃を行う
            // どちらかが死んだら終わり
            int a = 0, d = 0;
            int attackerHp = m_Args.Attacker.Hp, defenderHp = m_Args.Defender.Hp;
            while (a < m_Args.Attacker.PhaseCount || d < m_Args.Defender.PhaseCount)
            {
                if (a < m_Args.Attacker.PhaseCount)
                {
                    defenderHp = ExecutePhase(rng, m_Args.Attacker, defenderHp);
                    if (defenderHp <= 0)
                    {
                        defenderHp = 0;
                        break;
                    }
                    if (m_Args.Attacker.IsDoubleAttack)
                    {
                        defenderHp = ExecutePhase(rng, m_Args.Attacker, defenderHp);
                        if (defenderHp <= 0)
                        {
                            defenderHp = 0;
                            break;
                        }
                    }
                    ++a;
                }

                if (d < m_Args.Defender.PhaseCount)
                {
                    attackerHp = ExecutePhase(rng, m_Args.Defender, attackerHp);
                    if (attackerHp <= 0)
                    {
                        attackerHp = 0;
                        break;
                    }
                    if (m_Args.Defender.IsDoubleAttack)
                    {
                        attackerHp = ExecutePhase(rng, m_Args.Defender, attackerHp);
                        if (attackerHp <= 0)
                        {
                            attackerHp = 0;
                            break;
                        }
                    }
                    ++d;
                }
            }

            // HP事後条件チェック
            if (attackerHp < m_Args.AttackerHpPostconditionMin || attackerHp > m_Args.AttackerHpPostconditionMax
                || defenderHp < m_Args.DefenderHpPostconditionMin || defenderHp > m_Args.DefenderHpPostconditionMax)
            {
                return false;
            }

            return true;
        }

        private int ExecutePhase(IRng rng, CombatUnitInfo attackerInfo, int currentDefenderHp)
        {
            // 命中判定
            if ((rng.Next() + rng.Next()) / 2 < attackerInfo.HitRate)
            {
                // 命中していたら必殺判定
                if (rng.Next() < attackerInfo.CriticalRate)
                {
                    // 必殺が出たら瞬殺判定（封印以外）
                    rng.Next();

                    return currentDefenderHp - attackerInfo.Power * 3;
                }
                else
                {
                    return currentDefenderHp - attackerInfo.Power;
                }
            }
            return currentDefenderHp;
        }
    }
}
