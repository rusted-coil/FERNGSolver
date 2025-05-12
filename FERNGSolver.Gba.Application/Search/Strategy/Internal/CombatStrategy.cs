using FERNGSolver.Gba.Domain.Combat;
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

        public bool CheckAndAdvance(IRng rng)
        {
            var result = CombatSimulator.Simulate(rng, m_Args.Attacker, m_Args.Defender);

            // HP事後条件チェック
            if (result.AttackerHp < m_Args.AttackerHpPostconditionMin || result.AttackerHp > m_Args.AttackerHpPostconditionMax
                || result.DefenderHp < m_Args.DefenderHpPostconditionMin || result.DefenderHp > m_Args.DefenderHpPostconditionMax)
            {
                return false;
            }

            return true;
        }
    }
}
