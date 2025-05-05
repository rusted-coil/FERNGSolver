using FERNGSolver.Gba.Application.Search.Strategy;
using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Search
{
    /// <summary>
    /// 乱数検索を行うクラスです。
    /// </summary>
    public static class Searcher
    {
        /// <summary>
        /// Strategyを使い、条件を満たす消費数を全て検索します。
        /// </summary>
        public static IReadOnlyList<(int, ushort[])> Search(IRng currentRng, int offsetMin, int offsetMax, ISearchStrategy strategy)
        {
            var result = new List<(int, ushort[])>();

            var startRng = RngFactory.CreateFromRng(currentRng);
            for (int i = 0; i < offsetMin; ++i)
            {
                startRng.Next();
            }

            for (int i = 0; i <= offsetMax - offsetMin; ++i)
            {
                if (strategy.IsOk(startRng))
                {
                    result.Add((offsetMin + i, [startRng.States[0], startRng.States[1], startRng.States[2]]));
                }

                startRng.Next();
            }

            return result;
        }
    }
}
