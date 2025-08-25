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
            var (results, patternCount) = ExecuteSearchCore(mainFormView, errorNotifier);
            ShowResults(mainFormView, results, patternCount);
        }

        private class ResultViewModel : IRngStateResultViewModel
        {
            public required string Position { get; init; }
        }

        private static (IReadOnlyList<ISearchResult> results, int patternCount) ExecuteSearchCore(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
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
                return (Array.Empty<ISearchResult>(), 0);
            }

            return (Searcher.Search(
                rng, mainFormView.CurrentPosition + mainFormView.OffsetMin, mainFormView.CurrentPosition + mainFormView.OffsetMax,
                CommonStrategyFactory.CreateHighOrLowPatternStrategy(highOrLowPattern)), highOrLowPattern.Count);
        }

        private static void ShowResults(IExtendedMainFormView mainFormView, IReadOnlyList<ISearchResult> results, int patternCount)
        {
            var viewModels = new ResultViewModel[results.Count];
            for (int i = 0; i < viewModels.Length && i < 100; ++i)
            {
                int offset = mainFormView.AddsOffset ? results[i].Position + patternCount : results[i].Position;
                viewModels[i] = new ResultViewModel { Position = offset.ToString() };
            }
            mainFormView.ShowSearchResults(
                [new SearchResultTableColumn("消費数", "Position") { Width = 50 }],
                typeof(ResultViewModel), viewModels);
        }
    }
}
