using FERNGSolver.Common.ViewContracts;
using FERNGSolver.FalconKnightTool.Application.Path;
using FERNGSolver.Gba.Presentation.Search.Internal;
using FERNGSolver.Thracia.Application.Search;
using FERNGSolver.Thracia.Application.Search.Strategy;
using FERNGSolver.Thracia.Domain.RNG;
using FERNGSolver.Thracia.Presentation.ViewContracts;
using System.Text;

namespace FERNGSolver.Thracia.Presentation.Search.Executor.Internal
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
            public required string TableIndex { get; init; }
            public required string Position { get; init; }
            public string Foresight { get; set; } = string.Empty;
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
            var strategy = StrategyFactory.CreateFalconKnightPatternStrategy(cxPattern);

            for (int i = 0; i < Domain.RNG.Const.TableCount; ++i)
            {
                IRng rng = RngFactory.Create(i);
                results.AddRange(Searcher.Search(i, rng, mainFormView.OffsetMin, mainFormView.OffsetMax, strategy));
            }
            return results;
        }

        private static void ShowResults(IExtendedMainFormView mainFormView, IReadOnlyList<ISearchResult> results)
        {
            var viewModels = new ResultViewModel[results.Count];
            for (int i = 0; i < viewModels.Length && i < 100; ++i)
            {
                var rng = RngFactory.Create(results[i].TableIndex);
                for (int a = 0; a < results[i].Position; ++a)
                {
                    rng.Next();
                }
                var sb = new StringBuilder();
                for (int a = 0; a < 30; ++a)
                {
                    sb.Append($"{rng.Next():D2} ");
                }

                viewModels[i] = new ResultViewModel {
                    TableIndex = $"#{results[i].TableIndex:D2}",
                    Position = results[i].Position.ToString(),
                    Foresight = sb.ToString(),
                };
            }
            mainFormView.ShowSearchResults([
                new SearchResultTableColumn("Map", "TableIndex") { Width = 30 },
                new SearchResultTableColumn("消費数", "Position") { Width = 50 },
                new SearchResultTableColumn("続き", "Foresight") { Width = 400 },
            ],
            typeof(ResultViewModel), viewModels);
        }
    }
}
