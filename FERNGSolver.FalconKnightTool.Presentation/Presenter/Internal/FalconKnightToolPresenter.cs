using FERNGSolver.Common.Domain.Types;
using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;
using System.Reactive.Disposables;
using System.Text;

namespace FERNGSolver.FalconKnightTool.Presentation.Presenter.Internal
{
    internal sealed class FalconKnightToolPresenter : IFalconKnightToolPresenter
    {
        private string m_CurrentCxString = string.Empty;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        private readonly IFalconKnightToolView m_View;
        private readonly IFalconKnightToolEntry m_Entry;

        public FalconKnightToolPresenter(IFalconKnightToolView view, IFalconKnightToolEntry entry)
        {
            m_View = view;
            m_Entry = entry;

            view.PathDetermined.Subscribe(ReceivePath).AddTo(m_Disposables);
            view.AddButtonClicked.Subscribe(_ =>
            {
                m_Entry.AddCxString(m_CurrentCxString);
            }).AddTo(m_Disposables);

            SetCxNone();
        }

        public void Dispose()
        {
            m_Disposables.Dispose();
        }

        private void ReceivePath(IReadOnlyList<GridPosition> path)
        {
            var cxList = m_Entry.PathConverter.PathToCx(path);
            if (cxList.Count == 0)
            {
                m_CurrentCxString = string.Empty;
                SetCxNone();
            }
            else
            {
                var sb = new StringBuilder();
                for (int i = 0; i < cxList.Count; ++i)
                {
                    sb.Append(cxList[i] ? 'c' : 'x');
                }
                m_CurrentCxString = sb.ToString();
                m_View.SetCurrentPathText($"現在の入力: {sb.ToString()}");
            }
        }

        private void SetCxNone()
        {
            m_View.SetCurrentPathText("現在の入力: -");
        }
    }
}
