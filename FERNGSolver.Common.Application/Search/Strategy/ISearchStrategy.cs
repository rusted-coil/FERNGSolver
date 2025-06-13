using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Common.Application.Search.Strategy
{
    public interface ISearchStrategy
    {
        /// <summary>
        /// RNGを進め、条件を満たすか判定します。
        /// </summary>
        bool CheckAndAdvance(IRng rng);
    }
}
