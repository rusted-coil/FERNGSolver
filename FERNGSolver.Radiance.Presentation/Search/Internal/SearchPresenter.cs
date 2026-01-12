using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Radiance.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Radiance.Presentation.Search.Internal
{
    internal sealed class SearchPresenter : ISearchPresenter
    {
        private readonly IExtendedMainFormView m_MainFormView;
//        private readonly IConfigService m_ConfigService;
        private readonly IErrorNotifier m_ErrorNotifier;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        public SearchPresenter(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            m_MainFormView = mainFormView;
//            m_ConfigService = configService;
            m_ErrorNotifier = errorNotifier;

//            m_MainFormView.ReflectConfig(m_ConfigService.Config);

            mainFormView.FalconKnightToolOpenButtonClicked.Subscribe(_ => OpenFalconKnightTool()).AddTo(m_Disposables);
            mainFormView.SearchButtonClicked.Subscribe(_ => ExecuteSearch()).AddTo(m_Disposables);

//            mainFormView.PersistentConfigChanged.Subscribe(_ => OnPersistentConfigChanged()).AddTo(m_Disposables);
        }

        public void Dispose()
        {
            m_Disposables.Dispose();
        }

        private void OpenFalconKnightTool()
        {
            m_MainFormView.OpenFalconKnightTool();
        }

        private void ExecuteSearch()
        {
            if (!ValidateView())
            {
                return;
            }

            if (m_MainFormView.UsesFalconKnightMethod)
            {
//                Executor.Internal.FalconKnightMethodSearchExecutor.ExecuteSearch(m_MainFormView, m_ErrorNotifier);
            }
            else
            {
//                Executor.Internal.CombatAndGrowthSearchExecutor.ExecuteSearch(m_MainFormView, m_ErrorNotifier);
            }
        }

        private bool ValidateView()
        {
//            if (!m_MainFormView.UsesFalconKnightMethod && !m_MainFormView.ContainsCombat && !m_MainFormView.ContainsGrowth)
//            {
//                m_ErrorNotifier.NotifyError("検索条件が選択されていません。");
//                return false;
//            }
            return true;
        }

        private void OnPersistentConfigChanged()
        {
//            m_ConfigService.Config.IsBindingBlade = m_MainFormView.IsBindingBlade;

//            m_ConfigService.Serialize();
        }
    }
}
