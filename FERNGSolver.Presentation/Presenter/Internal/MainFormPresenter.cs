using System.Reactive.Disposables;

namespace FERNGSolver.Presentation.Presenter.Internal
{
    internal sealed class MainFormPresenter : IMainFormPresenter
    {
        CompositeDisposable m_Disposable = new CompositeDisposable();

        public void Dispose()
        {
            m_Disposable.Dispose();
        }
    }
}
