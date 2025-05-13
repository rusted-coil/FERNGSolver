using FERNGSolver.Thracia.Domain.RNG;

namespace FERNGSolver.Thracia.Application.Search.Strategy.Internal
{
    internal sealed class FalconKnightPatternStrategy : ISearchStrategy
    {
        private IReadOnlyList<bool> m_Pattern;

        public FalconKnightPatternStrategy(IReadOnlyList<bool> pattern)
        {
            m_Pattern = pattern;
        }

        public bool CheckAndAdvance(IRng rng)
        {
            foreach (var pattern in m_Pattern)
            {
                if (pattern != rng.Next().ToCx())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
