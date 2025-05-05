using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Search.Strategy.Internal
{
    internal sealed class FalconKnightPatternStrategy : ISearchStrategy
    {
        private IReadOnlyList<bool> m_Pattern;

        public FalconKnightPatternStrategy(IReadOnlyList<bool> pattern)
        {
            m_Pattern = pattern;
        }

        public bool IsOk(IRng currentRng)
        {
            var tempRng = RngFactory.CreateFromRng(currentRng);
            foreach (var pattern in m_Pattern)
            {
                if (pattern != tempRng.Next().ToCx())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
