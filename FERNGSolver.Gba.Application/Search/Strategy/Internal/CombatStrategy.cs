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

            return true;
        }
    }
}
