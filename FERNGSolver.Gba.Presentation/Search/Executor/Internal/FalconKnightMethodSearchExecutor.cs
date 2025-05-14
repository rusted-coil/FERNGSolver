using FERNGSolver.Common.ViewContracts;
using FERNGSolver.FalconKnightTool.Application.Path;
using FERNGSolver.Gba.Application.Search;
using FERNGSolver.Gba.Application.Search.Strategy;
using FERNGSolver.Gba.Domain.RNG;
using FERNGSolver.Gba.Presentation.ViewContracts;
using FERNGSolver.Gba.Presentation.Search.Internal;

namespace FERNGSolver.Gba.Presentation.Search.Executor.Internal
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

        private class ResultViewModel
        {
            public required string Position { get; init; }
        }

        private static IReadOnlyList<ISearchResult> ExecuteSearchCore(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            IRng rng = RngFactory.CreateDefault();

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
            return Searcher.Search(
                rng, mainFormView.CurrentPosition + mainFormView.OffsetMin, mainFormView.CurrentPosition + mainFormView.OffsetMax,
                StrategyFactory.CreateFalconKnightPatternStrategy(cxPattern));
        }

        private static void ShowResults(IExtendedMainFormView mainFormView, IReadOnlyList<ISearchResult> results)
        {
            var viewModels = new ResultViewModel[results.Count];
            for (int i = 0; i < viewModels.Length && i < 100; ++i)
            {
                viewModels[i] = new ResultViewModel { Position = results[i].Position.ToString() };
            }
            mainFormView.ShowSearchResults(
                [ new SearchResultTableColumn("消費数", "Position") { Width = 50 } ],
                typeof(ResultViewModel), viewModels);
        }
    }
}
