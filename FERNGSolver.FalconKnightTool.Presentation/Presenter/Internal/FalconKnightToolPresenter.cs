using FERNGSolver.Common.Extensions;
using FERNGSolver.FalconKnightTool.Application.Path;
using FERNGSolver.FalconKnightTool.Common.Interfaces;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.FalconKnightTool.Presentation.Presenter.Internal
{
    internal sealed class FalconKnightToolPresenter : IFalconKnightToolPresenter
    {
        private string m_CurrentCxString = string.Empty;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        public FalconKnightToolPresenter(IFalconKnightToolView view, IFalconKnightToolSearchStrategy searchStrategy)
        {
            view.AddButtonClicked.Subscribe(_ =>
            {
                view.AddCxStringText(m_CurrentCxString);
            }).AddTo(m_Disposables);

            view.SearchButtonClicked.Subscribe(_ =>
            {
                searchStrategy.ExecuteSearch(view.GetCxStringText());
            }).AddTo(m_Disposables);

            view.PathDetermined.Subscribe(list =>
            {
                m_CurrentCxString = PathConverter.PathToCxString(list);
                view.SetCurrentPathText($"現在の入力: {m_CurrentCxString}");
            }).AddTo(m_Disposables);
        }

        public void Dispose()
        {
            m_Disposables.Dispose();
        }
    }
}
