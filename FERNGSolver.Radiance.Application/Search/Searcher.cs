using FERNGSolver.Common.Application.Search.Strategy;
using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Radiance.Application.Search
{
    /// <summary>
    /// 乱数検索を行うクラスです。
    /// </summary>
    public static class Searcher
    {
        /// <summary>
        /// Strategyを使い、条件を満たす消費数を全て検索します。
        /// </summary>
        /// <param name="initialRng">初期状態のRNG。状態を変更しません。</param>
        /// <param name="positionMin">検索する最小の消費数</param>
        /// <param name="positionMax">検索する最大の消費数</param>
        /// <param name="strategy">条件をチェックするストラテジ</param>
        /// <returns></returns>
        public static IReadOnlyList<ISearchResult> Search(int tableIndex, ICloneableRng initialRng, int positionMin, int positionMax, ISearchStrategy strategy)
        {
            var result = new List<ISearchResult>();

            var currentRng = initialRng.Clone();
            currentRng.Advance(positionMin);

            for (int i = 0; i <= positionMax - positionMin; ++i)
            {
                var tempRng = currentRng.Clone();
                if (strategy.CheckAndAdvance(tempRng))
                {
                    result.Add(new Internal.SearchResult(tableIndex, positionMin + i));
                }

                currentRng.Next();
            }

            return result;
        }
    }
}
