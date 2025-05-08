using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Search.Strategy
{
    public interface ISearchStrategy
    {
        /// <summary>
        /// 現在のRNGが条件を満たすか判定します。
        /// <para> * allowsAdvanceがtrueの時、RNGを進めます。</para>
        /// </summary>
        bool Check(IRng currentRng, bool allowsAdvance);
    }
}
