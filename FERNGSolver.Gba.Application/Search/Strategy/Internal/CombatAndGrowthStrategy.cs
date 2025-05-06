using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Search.Strategy.Internal
{
    internal sealed class CombatAndGrowthStrategy : ISearchStrategy
    {
        private CombatAndGrowthStrategyArgs m_Args;

        public CombatAndGrowthStrategy(CombatAndGrowthStrategyArgs args)
        {
            m_Args = args;
        }

        public bool IsOk(IRng currentRng)
        {
            var tempRng = RngFactory.CreateFromRng(currentRng);

            if (!CheckCombat(tempRng) || !CheckGrowth(tempRng))
            {
                return false;
            }
            return true;
        }

        // 戦闘をチェックしてRNGを進める
        private bool CheckCombat(IRng rng)
        {
            if (m_Args.ContainsCombat)
            {
            }
            return true;
        }

        // レベルアップをチェックしてRNGを進める
        private bool CheckGrowth(IRng rng)
        {
            if (m_Args.ContainsGrowth)
            {
                if (rng.Next() >= 70)
                {
                    return false;
                }
                if (rng.Next() >= 40)
                {
                    return false;
                }
                if (rng.Next() >= 60)
                {
                    return false;
                }
                if (rng.Next() >= 60)
                {
                    return false;
                }
                if (rng.Next() >= 30)
                {
                    return false;
                }
                if (rng.Next() >= 30)
                {
                    return false;
                }
                if (rng.Next() >= 60)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
