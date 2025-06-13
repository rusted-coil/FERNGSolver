using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.FalconKnightTool.Application.Path;
using FERNGSolver.Gba.Application.Search;
using FERNGSolver.Gba.Application.Search.Strategy;
using FERNGSolver.Gba.Domain.RNG;
using FERNGSolver.Gba.Presentation.Search.Internal;
using FERNGSolver.Gba.Presentation.ViewContracts;

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
            var rng = RngFactory.CreateDefault();

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
                int offset = mainFormView.AddsCxOffset ? results[i].Position + mainFormView.CxString.Length : results[i].Position;
                viewModels[i] = new ResultViewModel { Position = offset.ToString() };
            }
            mainFormView.ShowSearchResults(
                [ new SearchResultTableColumn("消費数", "Position") { Width = 50 } ],
                typeof(ResultViewModel), viewModels);
        }
    }
}
