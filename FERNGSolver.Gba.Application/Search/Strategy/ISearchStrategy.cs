using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Search.Strategy
{
    public interface ISearchStrategy
    {
        /// <summary>
        /// 現在のRNGが条件を満たすか判定します。
        /// <para> * 受け取ったRNGは進めません。</para>
        /// </summary>
        bool IsOk(IRng currentRng);
    }
}
