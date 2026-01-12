using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Application.Search.Strategy;
using FERNGSolver.FalconKnightTool.Application.Path;
using FERNGSolver.Radiance.Application.Search;
using FERNGSolver.Radiance.Domain.RNG;
using FERNGSolver.Radiance.Presentation.Search.Internal;
using FERNGSolver.Radiance.Presentation.ViewContracts;

namespace FERNGSolver.Radiance.Presentation.Search.Executor.Internal
{
    /// <summary>
    /// 検索処理のうち、ファルコンナイト法を使った検索を担当するクラスです。
    /// </summary>
    internal static class FalconKnightMethodSearchExecutor
    {
        public static void ExecuteSearch(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            var result = ExecuteSearchCore(mainFormView, errorNotifier);
            ShowResults(mainFormView, result);
        }

        private class ResultViewModel : IRngStateResultViewModel
        {
            public required string TableIndex { get; init; }
            public required string Position { get; init; }
        }

        private static IReadOnlyList<ISearchResult> ExecuteSearchCore(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            List<ISearchResult> results = new List<ISearchResult>();

            IReadOnlyList<bool> cxPattern;
            try
            {
                cxPattern = CxStringConverter.CxStringToBools(mainFormView.CxString);
            }
            catch (Exception e)
            {
                errorNotifier.NotifyError($"cx列のパースに失敗しました。\n-----\n{e.ToString()}");
                return Array.Empty<ISearchResult>();
            }

            var strategy = CommonStrategyFactory.CreateFalconKnightPatternStrategy(cxPattern, Util.IsRngValueOk);

            for (int i = 0; i < Domain.RNG.Const.TableCount; ++i)
            {
                var rng = RngFactory.Create(i);
                results.AddRange(Searcher.Search(
                    i, rng, 0, 10000,
                    CommonStrategyFactory.CreateFalconKnightPatternStrategy(cxPattern, Util.IsRngValueOk)));
            }
            return results;
        }

        private static void ShowResults(IExtendedMainFormView mainFormView, IReadOnlyList<ISearchResult> results)
        {
            var viewModels = new ResultViewModel[results.Count];
            for (int i = 0; i < viewModels.Length && i < 100; ++i)
            {
                int offset = mainFormView.AddsCxOffset ? results[i].Position + mainFormView.CxString.Length : results[i].Position;
                viewModels[i] = new ResultViewModel { TableIndex = results[i].TableIndex.ToString(), Position = offset.ToString() };
            }
            mainFormView.ShowSearchResults([
                new SearchResultTableColumn("Map", "TableIndex") { Width = 30 },
                new SearchResultTableColumn("消費数", "Position") { Width = 50 }
            ],
            typeof(ResultViewModel), viewModels);
        }
    }
}
