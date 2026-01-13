using FERNGSolver.Common.Application.Search.Strategy;
using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Radiance.Domain.Growth;

namespace FERNGSolver.Radiance.Application.Search.Strategy.Internal
{
    internal sealed class GrowthStrategy : ISearchStrategy
    {
        private readonly GrowthStrategyArgs m_Args;
        private readonly int[] m_GrowthRates;
        private readonly GrowthSearchType[] m_SearchTypes;

        public GrowthStrategy(GrowthStrategyArgs args)
        {
            m_Args = args;
            m_GrowthRates = [
                args.HpGrowthRate,
                args.StrGrowthRate,
                args.MgcGrowthRate,
                args.TecGrowthRate,
                args.SpdGrowthRate,
                args.LucGrowthRate,
                args.DefGrowthRate,
                args.MdfGrowthRate
            ];
            m_SearchTypes = [
                args.HpSearchType,
                args.StrSearchType,
                args.MgcSearchType,
                args.TecSearchType,
                args.SpdSearchType,
                args.LucSearchType,
                args.DefSearchType,
                args.MdfSearchType
            ];
        }

        public bool CheckAndAdvance(IRng rng)
        {
            var result = GrowthSimulator.Simulate(rng,
                m_Args.HpGrowthRate,
                m_Args.StrGrowthRate,
                m_Args.MgcGrowthRate,
                m_Args.TecGrowthRate,
                m_Args.SpdGrowthRate,
                m_Args.LucGrowthRate,
                m_Args.DefGrowthRate,
                m_Args.MdfGrowthRate);

            for (int i = 0; i < result.Count; ++i)
            {
                if (m_SearchTypes[i] == GrowthSearchType.MustUp && result[i] <= (m_GrowthRates[i] / 100))
                {
                    return false;
                }
                if (m_SearchTypes[i] == GrowthSearchType.MustNotUp && result[i] > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
