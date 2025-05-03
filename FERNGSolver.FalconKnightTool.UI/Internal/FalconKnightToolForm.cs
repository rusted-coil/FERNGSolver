using FERNGSolver.Common.Types;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;
using FERNGSolver.FalconKnightTool.Windows.Common.Interfaces;
using FormRx.Button;
using System.Collections;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Disposables;

namespace FERNGSolver.FalconKnightTool.UI.Internal
{
    internal partial class FalconKnightToolForm : Form, IFalconKnightToolView
    {
        public string CurrentTitle => m_Titles[SearchConditionTabControl.SelectedIndex];
        public IObservable<Unit> AddButtonClicked => m_AddButton.Clicked;
        public IObservable<Unit> SearchButtonClicked => m_SearchButton.Clicked;
        public IObservable<IReadOnlyList<GridPosition>> PathDetermined => GridCanvas.PathDetermined;

        IButton m_AddButton, m_SearchButton;
        string[] m_Titles;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        public FalconKnightToolForm(params IFalconKnightToolEntry[] entries)
        {
            InitializeComponent();

            m_Titles = entries.Select(entry => entry.Title).ToArray();

            // 検索条件のUserControlを展開
            SearchConditionTabControl.TabPages.Clear();
            foreach (var entry in entries)
            {
                var tabPage = new TabPage(entry.Title);
                tabPage.BackColor = SystemColors.Window;

                entry.SearchConditionControl.Dock = DockStyle.Fill;
                tabPage.Controls.Add(entry.SearchConditionControl);

                SearchConditionTabControl.TabPages.Add(tabPage);
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

        public void ShowSearchResults(Type viewModelType, IReadOnlyList<object> viewModels)
        {
            var listType = typeof(BindingList<>).MakeGenericType(viewModelType);
            var list = Activator.CreateInstance(listType, viewModels) as IList;
            SearchResultDataGridView.DataSource = list;
        }
    }
}
