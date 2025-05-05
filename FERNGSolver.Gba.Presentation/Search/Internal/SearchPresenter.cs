using FERNGSolver.Common.Extensions;
using FERNGSolver.Gba.Application.Search;
using FERNGSolver.Gba.Application.Search.Strategy;
using FERNGSolver.Gba.Domain.RNG;
using FERNGSolver.Gba.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Gba.Presentation.Search.Internal
{
    internal sealed class SearchPresenter : ISearchPresenter
    {
        CompositeDisposable m_Disposables = new CompositeDisposable();

        public SearchPresenter(IExtendedMainFormView mainFormView)
        {
            mainFormView.SearchButtonClicked.Subscribe(_ =>
            {
                IRng rng = RngFactory.CreateDefault();
                var strategy = StrategyFactory.CreateCombatAndGrowthStrategy();

                var result = Searcher.Search(rng, mainFormView.OffsetMin, mainFormView.OffsetMax, strategy);

                var viewModels = new SearchResultItemViewModel[result.Count];
                for (int i = 0; i < viewModels.Length && i < 100; ++i)
                {
                    viewModels[i] = new SearchResultItemViewModel(result[i].Item1);
                }
                mainFormView.ShowSearchResults(typeof(SearchResultItemViewModel), viewModels);
            }).AddTo(m_Disposables);
        }

        public void Dispose()
        {
            m_Disposables.Dispose();
        }
    }
}
