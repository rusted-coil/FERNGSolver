using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Common.Presentation.Interfaces;
using FERNGSolver.Genealogy.Domain.Combat;
using FERNGSolver.Genealogy.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Genealogy.Presentation.Search.Internal
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

            try
            {
                if (m_MainFormView.UsesArenaCheck)
                {
                    Executor.Internal.ArenaCheckSearchExecutor.ExecuteSearch(m_MainFormView, m_ErrorNotifier);
                }
                else
                {
                    Executor.Internal.CombatAndGrowthSearchExecutor.ExecuteSearch(m_MainFormView, m_ErrorNotifier);
                }
            }
            catch (CombatSimulationLimitException exception)
            {
                m_MainFormView.ShowSearchResults(Array.Empty<ITableColumn>(), typeof(object), Array.Empty<object>());
                m_ErrorNotifier.NotifyError(exception.Message);
            }
        }

        private bool ValidateView()
        {
            if (!m_MainFormView.UsesArenaCheck && !m_MainFormView.ContainsCombat && !m_MainFormView.ContainsGrowth)
            {
                m_ErrorNotifier.NotifyError("検索条件が選択されていません。");
                return false;
            }
            return true;
        }
    }
}
