using FERNGSolver.FalconKnightTool.Application.Path;
using FERNGSolver.FalconKnightTool.Common.Interfaces;
using FERNGSolver.Thracia.Application.FalconKnight;
using FERNGSolver.Thracia.Domain.RNG;
using FERNGSolver.Thracia.Presentation.ViewContracts;

namespace FERNGSolver.Thracia.Presentation.FalconKnight.Internal
{
    internal sealed class SearchStrategy : IFalconKnightToolSearchStrategy
    {
        private readonly IFalconKnightToolSearchConditionView m_View;

        public SearchStrategy(IFalconKnightToolSearchConditionView view)
        {
            m_View = view;
        }

        public void ExecuteSearch(string cxString, IFalconKnightToolResultView resultView)
        {
            var cxPattern = CxStringConverter.CxStringToBools(cxString);

            var results = new List<(int, int)>();
            if (m_View.TableIndex == null)
            {
                for (int i = 0; i < Domain.RNG.Const.TableCount; ++i)
                {
                    IRng rng = RngFactory.Create(i);
                    var result = PatternSearcher.Search(rng, m_View.OffsetMin, m_View.OffsetMax, cxPattern);
                    results.AddRange(result.Select(item => (i, item)));
                }
            }
            else
            {
                IRng rng = RngFactory.Create(m_View.TableIndex.Value);
                var result = PatternSearcher.Search(rng, m_View.OffsetMin, m_View.OffsetMax, cxPattern);
                results.AddRange(result.Select(item => (m_View.TableIndex.Value, item)));
            }

            var viewModels = new SearchResultItemViewModel[results.Count];
            for (int i = 0; i < viewModels.Length && i < 100; ++i)
            {
                viewModels[i] = new SearchResultItemViewModel(results[i].Item1, results[i].Item2);
            }
            resultView.ShowSearchResults(typeof(SearchResultItemViewModel), viewModels);
        }
    }
}
