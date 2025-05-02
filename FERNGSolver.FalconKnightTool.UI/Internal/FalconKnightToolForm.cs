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
        public IObservable<Unit> SearchButtonClicked => m_SearchButton.Clicked;
        public IObservable<IReadOnlyList<GridPosition>> PathDetermined => GridCanvas.PathDetermined;

        IButton m_AddButton, m_SearchButton;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        public FalconKnightToolForm(UserControl searchConditionUserControl)
        {
            InitializeComponent();

            // 検索条件のUserControlを展開
            {
                m_TestPanel.Controls.Clear();
                searchConditionUserControl.Dock = DockStyle.Fill;
                m_TestPanel.Controls.Add(searchConditionUserControl);
            }

            m_AddButton = ButtonFactory.CreateButton(AddButton);
            m_SearchButton = ButtonFactory.CreateButton(SearchButton);
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
            TotalCxStringTextBox.Text += text;
        }

        public string GetCxStringText()
        {
            return TotalCxStringTextBox.Text;
        }
    }
}
