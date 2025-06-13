using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Gba.Application.Search.Strategy.Internal
{
    internal sealed class SequentialStrategy : ISearchStrategy
    {
        private readonly IReadOnlyList<ISearchStrategy> m_Strategies;

        public SequentialStrategy(IReadOnlyList<ISearchStrategy> strategies)
        {
            m_Strategies = strategies;
        }

        public bool CheckAndAdvance(IRng rng)
        {
            // Checkは高頻度で呼び出すことが予想されるため、ヒープを生成しないforを使う
            for (int i = 0; i < m_Strategies.Count; ++i)
            {
                if (!m_Strategies[i].CheckAndAdvance(rng))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
