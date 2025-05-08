using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Search.Strategy.Internal
{
    internal sealed class SequentialStrategy : ISearchStrategy
    {
        private readonly IReadOnlyList<ISearchStrategy> m_Strategies;

        public SequentialStrategy(IReadOnlyList<ISearchStrategy> strategies)
        {
            m_Strategies = strategies;
        }

        public bool Check(IRng currentRng, bool allowsAdvance)
        {
            var rng = allowsAdvance ? currentRng : RngFactory.CreateFromRng(currentRng);

            // Checkは高頻度で呼び出すことが予想されるため、ヒープを生成しないforを使う
            for (int i = 0; i < m_Strategies.Count; ++i)
            {
                if (!m_Strategies[i].Check(rng, true))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
