using FERNGSolver.Common.Extensions;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.FalconKnightTool.Presentation.Presenter.Internal
{
    internal sealed class FalconKnightToolPresenter : IFalconKnightToolPresenter
    {
        CompositeDisposable m_Disposables = new CompositeDisposable();

        public FalconKnightToolPresenter(IFalconKnightToolView view)
        {
            view.AddButtonClicked.Subscribe(_ => OnAddButtonClicked()).AddTo(m_Disposables);
        }

        void OnAddButtonClicked()
        {
            Console.WriteLine("Addボタンが押されました。");
        }
    }
}
