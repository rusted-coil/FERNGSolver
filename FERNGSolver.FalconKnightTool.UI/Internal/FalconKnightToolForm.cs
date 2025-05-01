using FERNGSolver.Common.Types;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;
using FormRx.Button;
using FormRx.Extensions;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Subjects;

namespace FERNGSolver.FalconKnightTool.UI.Internal
{
    internal partial class FalconKnightToolForm : Form, IFalconKnightToolView
    {
        Subject<Unit> m_AddButtonClicked = new Subject<Unit>();
        public IObservable<Unit> AddButtonClicked => m_AddButtonClicked;
        public IObservable<IReadOnlyList<GridPosition>> PathDetermined => m_GridCanvas.PathDetermined;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        public FalconKnightToolForm()
        {
            InitializeComponent();

            var button = ButtonFactory.CreateButton(m_AddButton);
            button.Clicked.Subscribe(m_AddButtonClicked).AddTo(m_Disposables);
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            m_Disposables.Dispose();
        }

        public void SetCurrentPathText(string text)
        {
            m_CurrentPathText.Text = text;
        }

        public void AddCxStringText(string text)
        {
            m_TotalCxStringTextBox.Text += text;
        }
    }
}
