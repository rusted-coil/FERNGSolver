using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Search.Strategy.Internal
{
    internal sealed class GrowthStrategy : ISearchStrategy
    {
        private GrowthStrategyArgs m_Args;

        public GrowthStrategy(GrowthStrategyArgs args)
        {
            m_Args = args;
        }

        public bool Check(IRng currentRng, bool allowsAdvance)
        {
            var rng = allowsAdvance ? currentRng : RngFactory.CreateFromRng(currentRng);

            if (rng.Next() >= m_Args.HpGrowthRate) return false;
            if (rng.Next() >= m_Args.AtkGrowthRate) return false;
            if (rng.Next() >= m_Args.TecGrowthRate) return false;
            if (rng.Next() >= m_Args.SpdGrowthRate) return false;
            if (rng.Next() >= m_Args.DefGrowthRate) return false;
            if (rng.Next() >= m_Args.MdfGrowthRate) return false;
            if (rng.Next() >= m_Args.LucGrowthRate) return false;

            return true;
        }
    }
}
