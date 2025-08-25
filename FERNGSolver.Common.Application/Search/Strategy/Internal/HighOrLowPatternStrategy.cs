using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Common.Application.Search.Strategy.Internal
{
    internal sealed class HighOrLowPatternStrategy : ISearchStrategy
    {
        private IReadOnlyList<(ushort, bool)> m_Pattern;

        public HighOrLowPatternStrategy(IReadOnlyList<(ushort, bool)> highOrLowPattern)
        {
            m_Pattern = highOrLowPattern;
        }

        public bool CheckAndAdvance(IRng rng)
        {
            foreach (var (value, isOk) in m_Pattern)
            {
                var rngValue = rng.Next();
                if (isOk) // 判定値valueで判定に成功＝rngValueはその数未満
                {
                    if (rngValue >= value)
                    {
                        return false;
                    }
                }
                else
                {
                    if (rngValue < value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
