using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Search.Strategy.Internal
{
    internal sealed class GrowthStrategy : ISearchStrategy
    {
        private readonly int[] m_ActualGrowthRates = new int[7];

        public GrowthStrategy(GrowthStrategyArgs args)
        {
            m_ActualGrowthRates[0] = args.HpGrowthRate != 100 ? args.HpGrowthRate % 100 : 100;
            m_ActualGrowthRates[1] = args.AtkGrowthRate != 100 ? args.AtkGrowthRate % 100 : 100;
            m_ActualGrowthRates[2] = args.TecGrowthRate != 100 ? args.TecGrowthRate % 100 : 100;
            m_ActualGrowthRates[3] = args.SpdGrowthRate != 100 ? args.SpdGrowthRate % 100 : 100;
            m_ActualGrowthRates[4] = args.DefGrowthRate != 100 ? args.DefGrowthRate % 100 : 100;
            m_ActualGrowthRates[5] = args.MdfGrowthRate != 100 ? args.MdfGrowthRate % 100 : 100;
            m_ActualGrowthRates[6] = args.LucGrowthRate != 100 ? args.LucGrowthRate % 100 : 100;
        }

        public bool Check(IRng currentRng, bool allowsAdvance)
        {
            var rng = allowsAdvance ? currentRng : RngFactory.CreateFromRng(currentRng);

            for (int i = 0; i < m_ActualGrowthRates.Length; ++i)
            {
                if (rng.Next() >= m_ActualGrowthRates[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
