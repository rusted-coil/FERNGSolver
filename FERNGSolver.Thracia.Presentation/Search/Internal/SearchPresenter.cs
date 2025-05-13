using FERNGSolver.Common.Extensions;
using FERNGSolver.Common.ViewContracts;
using FERNGSolver.Thracia.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Thracia.Presentation.Search.Internal
{
    internal class SearchPresenter : ISearchPresenter
    {
        private readonly IExtendedMainFormView m_MainFormView;
        private readonly IErrorNotifier m_ErrorNotifier;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        public SearchPresenter(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            m_MainFormView = mainFormView;
            m_ErrorNotifier = errorNotifier;
            mainFormView.GetSearchButtonClicked(Const.Title).Subscribe(_ => ExecuteSearch()).AddTo(m_Disposables);
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

            if (m_MainFormView.UsesFalconKnightMethod)
            {
                Executor.Internal.FalconKnightMethodSearchExecutor.ExecuteSearch(m_MainFormView, m_ErrorNotifier);
            }
            else
            {
                // TODO
            }
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
    }
}
