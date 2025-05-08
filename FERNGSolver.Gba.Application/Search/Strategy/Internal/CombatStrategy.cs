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
            int a = 0, d = 0;
            while (a < m_Args.Attacker.PhaseCount || d < m_Args.Defender.PhaseCount)
            {
                if (a < m_Args.Attacker.PhaseCount)
                {
                    ExecutePhase(rng, m_Args.Attacker);
                    if (m_Args.Attacker.IsDoubleAttack)
                    {
                        ExecutePhase(rng, m_Args.Attacker);
                    }
                    ++a;
                }

                if (d < m_Args.Defender.PhaseCount)
                {
                    ExecutePhase(rng, m_Args.Defender);
                    if (m_Args.Defender.IsDoubleAttack)
                    {
                        ExecutePhase(rng, m_Args.Defender);
                    }
                    ++d;
                }
            }

            return true;
        }

        private void ExecutePhase(IRng rng, CombatUnitInfo attackerInfo)
        {
            // 命中判定
            if ((rng.Next() + rng.Next()) / 2 < attackerInfo.HitRate)
            {
                // 命中していたら必殺判定
                if (rng.Next() < attackerInfo.CriticalRate)
                {
                    // 必殺が出たら瞬殺判定（封印以外）
                    rng.Next();
                }
            }
        }
    }
}
