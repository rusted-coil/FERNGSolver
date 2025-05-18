using FERNGSolver.Common.Extensions;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.FalconKnightTool.Presentation.Presenter.Internal
{
    internal sealed class FalconKnightToolPresenter : IFalconKnightToolPresenter
    {
        private string m_CurrentCxString = string.Empty;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        public FalconKnightToolPresenter(IFalconKnightToolView view, IFalconKnightToolEntry entry)
        {
            view.AddButtonClicked.Subscribe(_ =>
            {
                // Add処理
            }).AddTo(m_Disposables);
        }

        public void Dispose()
        {
            m_Disposables.Dispose();
        }
    }
}
