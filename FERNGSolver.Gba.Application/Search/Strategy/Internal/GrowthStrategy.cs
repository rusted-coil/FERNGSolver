using FERNGSolver.Gba.Domain.Growth;
using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Search.Strategy.Internal
{
    internal sealed class GrowthStrategy : ISearchStrategy
    {
        private readonly GrowthStrategyArgs m_Args;

        public GrowthStrategy(GrowthStrategyArgs args)
        {
            m_Args = args;
        }

        public bool CheckAndAdvance(IRng rng)
        {
            var result = GrowthSimulator.Simulate(rng,
                m_Args.HpGrowthRate,
                m_Args.AtkGrowthRate,
                m_Args.TecGrowthRate,
                m_Args.SpdGrowthRate,
                m_Args.DefGrowthRate,
                m_Args.MdfGrowthRate,
                m_Args.LucGrowthRate);

            for (int i = 0; i < result.Count; ++i)
            {
                if (result[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
