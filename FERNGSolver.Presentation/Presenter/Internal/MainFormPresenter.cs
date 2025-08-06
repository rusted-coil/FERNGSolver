using FERNGSolver.Application.Config;
using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Presentation.Presenter.Internal
{
    internal sealed class MainFormPresenter : IMainFormPresenter
    {
        private readonly IMainFormView m_MainFormView;
        private readonly IConfigService m_ConfigService;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        public MainFormPresenter(IMainFormView mainFormView, IConfigService configService)
        {
            m_MainFormView = mainFormView;
            m_ConfigService = configService;

            mainFormView.Initialized.Subscribe(_ => mainFormView.ReflectConfig(configService.Config)).AddTo(m_Disposables);

            mainFormView.PersistentConfigChanged.Subscribe(_ => OnPersistentConfigChanged()).AddTo(m_Disposables);
        }

        public void Dispose()
        {
            m_Disposables.Dispose();
        }

        private void OnPersistentConfigChanged()
        {
            m_ConfigService.Config.SelectingTitle = m_MainFormView.SelectingTitle;

            m_ConfigService.Serialize();
        }
    }
}
