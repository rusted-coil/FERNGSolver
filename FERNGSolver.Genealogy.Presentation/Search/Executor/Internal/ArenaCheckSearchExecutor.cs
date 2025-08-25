using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Application.Search.Pattern;
using FERNGSolver.Common.Application.Search.Strategy;
using FERNGSolver.Genealogy.Application.Search;
using FERNGSolver.Genealogy.Domain.RNG;
using FERNGSolver.Genealogy.Presentation.Search.Internal;
using FERNGSolver.Genealogy.Presentation.ViewContracts;

namespace FERNGSolver.Genealogy.Presentation.Search.Executor.Internal
{
    /// <summary>
    /// 検索処理のうち、闘技場チェックを使った検索を担当するクラスです。
    /// </summary>
    internal static class ArenaCheckSearchExecutor
    {
        public static void ExecuteSearch(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            var result = ExecuteSearchCore(mainFormView, errorNotifier);
            ShowResults(mainFormView, result);
        }

        private class ResultViewModel : IRngStateResultViewModel
        {
            public required string Position { get; init; }
        }

        private static IReadOnlyList<ISearchResult> ExecuteSearchCore(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            var rng = RngFactory.Create();

            IReadOnlyList<(ushort, bool)> highOrLowPattern;
            try
            {
                highOrLowPattern = HighOrLowPatternConverter.ConvertFromString(mainFormView.HighOrLowPatternString);
            }
            catch (Exception e)
            {
                errorNotifier.NotifyError($"cx列のパースに失敗しました。\n-----\n{e.ToString()}");
                return Array.Empty<ISearchResult>();
            }

            return Searcher.Search(
                rng, mainFormView.CurrentPosition + mainFormView.OffsetMin, mainFormView.CurrentPosition + mainFormView.OffsetMax,
                CommonStrategyFactory.CreateHighOrLowPatternStrategy(highOrLowPattern));
        }

        private static void ShowResults(IExtendedMainFormView mainFormView, IReadOnlyList<ISearchResult> results)
        {
            var viewModels = new ResultViewModel[results.Count];
            for (int i = 0; i < viewModels.Length && i < 100; ++i)
            {
                viewModels[i] = new ResultViewModel { Position = results[i].Position.ToString() };
            }
            mainFormView.ShowSearchResults(
                [new SearchResultTableColumn("消費数", "Position") { Width = 50 }],
                typeof(ResultViewModel), viewModels);
        }
    }
}
