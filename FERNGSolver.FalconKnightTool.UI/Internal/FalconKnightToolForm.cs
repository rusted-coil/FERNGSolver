using FERNGSolver.Common.Types;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;
using FormRx.Button;
using System.Reactive;
using System.Reactive.Disposables;

namespace FERNGSolver.FalconKnightTool.UI.Internal
{
    internal partial class FalconKnightToolForm : Form, IFalconKnightToolView
    {
        public IObservable<Unit> AddButtonClicked => m_AddButton.Clicked;
        public IObservable<IReadOnlyList<GridPosition>> PathDetermined => GridCanvas.PathDetermined;

        private IButton m_AddButton;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        public FalconKnightToolForm(string title)
        {
            InitializeComponent();
            this.Text = $"ファルコンナイト法ツール - {title}";

            m_AddButton = ButtonFactory.CreateButton(AddButton);
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            m_Disposables.Dispose();
        }

        public void SetCurrentPathText(string text)
        {
            m_CurrentPathText.Text = text;
        }

        private void GridCanvas_SizeChanged(object sender, EventArgs e)
        {
            GridCanvas.Invalidate();
        }
    }
}
