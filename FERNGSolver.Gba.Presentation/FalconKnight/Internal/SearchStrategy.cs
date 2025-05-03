using FERNGSolver.FalconKnightTool.Application.Path;
using FERNGSolver.FalconKnightTool.Common.Interfaces;
using FERNGSolver.Gba.Application.FalconKnight;
using FERNGSolver.Gba.Domain.RNG;
using FERNGSolver.Gba.Presentation.ViewContracts;

namespace FERNGSolver.Gba.Presentation.FalconKnight.Internal
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

            IRng rng = RngFactory.CreateDefault();
            var result = PatternSearcher.Search(rng, m_View.OffsetMin, m_View.OffsetMax, cxPattern);

            var viewModels = new SearchResultItemViewModel[result.Count];
            for (int i = 0; i < viewModels.Length && i < 100; ++i)
            {
                viewModels[i] = new SearchResultItemViewModel(result[i].Item1, cxPattern.Count, result[i].Item2);
            }
            resultView.ShowSearchResults(typeof(SearchResultItemViewModel), viewModels);
        }
    }
}
