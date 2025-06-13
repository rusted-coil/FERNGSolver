using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Common.Application.Search.Strategy.Internal
{
    internal sealed class FalconKnightPatternStrategy : ISearchStrategy
    {
        private IReadOnlyList<bool> m_Pattern;
        private Func<int, bool> m_isRngValueOk;

        public FalconKnightPatternStrategy(IReadOnlyList<bool> pattern, Func<int, bool> isRngValueOk)
        {
            m_Pattern = pattern;
            m_isRngValueOk = isRngValueOk;
        }

        public bool CheckAndAdvance(IRng rng)
        {
            foreach (var pattern in m_Pattern)
            {
                if (pattern != m_isRngValueOk(rng.Next()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
