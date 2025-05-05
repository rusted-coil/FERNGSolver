using FERNGSolver.Common.Extensions;
using FERNGSolver.Common.ViewContracts;
using FERNGSolver.FalconKnightTool.Application.Path;
using FERNGSolver.Gba.Application.Search;
using FERNGSolver.Gba.Application.Search.Strategy;
using FERNGSolver.Gba.Domain.RNG;
using FERNGSolver.Gba.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Gba.Presentation.Search.Internal
{
    internal sealed class SearchPresenter : ISearchPresenter
    {
        private readonly IExtendedMainFormView m_MainFormView;
        private readonly IErrorNotifier m_ErrorNotifier;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        public SearchPresenter(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            m_MainFormView = mainFormView;
            m_ErrorNotifier = errorNotifier;
            mainFormView.SearchButtonClicked.Subscribe(_ => ExecuteSearch()).AddTo(m_Disposables);
        }

        public void Dispose()
        {
            m_Disposables.Dispose();
        }

        private void ExecuteSearch()
        {
            if (!ValidateView())
            {
                return;
            }

            var result = ExecuteSearchCore();
            ShowResults(result);
        }

        private bool ValidateView()
        {
            if (!m_MainFormView.UsesFalconKnightMethod && !m_MainFormView.ContainsCombat && !m_MainFormView.ContainsGrowth)
            {
                m_ErrorNotifier.NotifyError("検索条件が選択されていません。");
                return false;
            }
            return true;
        }

        private IReadOnlyList<(int, ushort[])> ExecuteSearchCore()
        {
            IRng rng = RngFactory.CreateDefault();
            ISearchStrategy strategy;

            if (m_MainFormView.UsesFalconKnightMethod)
            {
                IReadOnlyList<bool> cxPattern;
                try
                {
                    cxPattern = CxStringConverter.CxStringToBools(m_MainFormView.CxString);
                }
                catch (Exception e)
                {
                    m_ErrorNotifier.NotifyError($"cx列のパースに失敗しました。\n-----\n{e.ToString()}");
                    return Array.Empty<(int, ushort[])>();
                }
                strategy = StrategyFactory.CreateFalconKnightPatternStrategy(cxPattern);
            }
            else
            {
                strategy = StrategyFactory.CreateCombatAndGrowthStrategy();
            }
            return Searcher.Search(rng, m_MainFormView.OffsetMin, m_MainFormView.OffsetMax, strategy);
        }

        private void ShowResults(IReadOnlyList<(int, ushort[])> results)
        {
            var viewModels = new SearchResultItemViewModel[results.Count];
            for (int i = 0; i < viewModels.Length && i < 100; ++i)
            {
                viewModels[i] = new SearchResultItemViewModel(results[i].Item1);
            }
            m_MainFormView.ShowSearchResults(typeof(SearchResultItemViewModel), viewModels);
        }
    }
}
