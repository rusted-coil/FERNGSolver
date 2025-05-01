using FERNGSolver.Common.Extensions;
using FERNGSolver.FalconKnightTool.Application.Path;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;
using System.Diagnostics;
using System.Reactive.Disposables;

namespace FERNGSolver.FalconKnightTool.Presentation.Presenter.Internal
{
    internal sealed class FalconKnightToolPresenter : IFalconKnightToolPresenter
    {
        CompositeDisposable m_Disposables = new CompositeDisposable();

        public FalconKnightToolPresenter(IFalconKnightToolView view)
        {
            view.AddButtonClicked.Subscribe(_ => OnAddButtonClicked()).AddTo(m_Disposables);
            view.PathDetermined.Subscribe(list => {
                var cxString = PathConverter.PathToCxString(list);
                foreach (var position in list)
                {
                    Debug.WriteLine($"{position.X}, {position.Y}");
                }
                Debug.WriteLine(cxString);
            }).AddTo(m_Disposables);
        }

        void OnAddButtonClicked()
        {
            System.Diagnostics.Debug.WriteLine("Addボタンが押されました。");
        }
    }
}
