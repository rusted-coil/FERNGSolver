using FERNGSolver.Application.Config;
using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Presentation.Presenter.Internal
{
    internal sealed class MainFormPresenter : IMainFormPresenter
    {
        CompositeDisposable m_Disposable = new CompositeDisposable();

        public MainFormPresenter(IMainFormView mainFormView, IConfigService configService)
        {
            mainFormView.Initialized.Subscribe(_ => mainFormView.ReflectConfig(configService.Config)).AddTo(m_Disposable);
//            mainFormView.RngViewInitializeButtonClicked
        }

        public void Dispose()
        {
            m_Disposable.Dispose();
        }
    }
}
