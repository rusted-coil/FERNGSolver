using FERNGSolver.Application.Config;
using FERNGSolver.Common.Interfaces;
using FERNGSolver.Windows.Common.Interfaces;
using FormRx.Button;
using System.Collections;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace FERNGSolver
{
    internal partial class MainForm : Form, Common.ViewContracts.IMainFormView, Presentation.ViewContracts.IMainFormView
    {
        public IObservable<Unit> Initialized => m_Initialized;
        AsyncSubject<Unit> m_Initialized = new AsyncSubject<Unit>();

        public IObservable<Unit> PersistentConfigChanged => m_PersistentConfigChanged;
        Subject<Unit> m_PersistentConfigChanged = new Subject<Unit>();
        private void PersistentConfigControlValueChanged(object sender, EventArgs e) => m_PersistentConfigChanged.OnNext(Unit.Default);

        private readonly IButton m_SearchButton;

        public MainForm()
        {
            InitializeComponent();

            m_SearchButton = ButtonFactory.CreateButton(SearchButton);

            SearchConditionTabControl.TabPages.Clear();

            this.Text = "FERNGSolver v1.0.1";
        }

        public IObservable<Unit> GetSearchButtonClicked(string title)
        {
            return m_SearchButton.Clicked.Where(_ => SearchConditionTabControl.SelectedTab != null ? SearchConditionTabControl.SelectedTab.Text == title : false);
        }

        public void SetEntries(params IMainFormEntry[] entries)
        {
            foreach (var entry in entries)
            {
                var tabPage = new TabPage(entry.Title);
                tabPage.BackColor = SystemColors.Window;

                entry.MainFormControl.Dock = DockStyle.Fill;
                tabPage.Controls.Add(entry.MainFormControl);

                SearchConditionTabControl.TabPages.Add(tabPage);
            }

            // とりあえずエントリーのセット=初期化完了としておく。
            m_Initialized.OnNext(Unit.Default);
            m_Initialized.OnCompleted();
        }

        public void ReflectConfig(IConfig config)
        {
            if (!string.IsNullOrEmpty(config.SelectingTitle))
            {
                SelectTab(config.SelectingTitle);
            }
        }

        private void SelectTab(string title)
        {
            for (int i = 0; i < SearchConditionTabControl.TabCount; ++i)
            {
                if (SearchConditionTabControl.TabPages[i].Text == title)
                {
                    SearchConditionTabControl.SelectedIndex = i;
                    break;
                }
            }
        }

        public void ShowSearchResults(IReadOnlyList<ITableColumn> columns, Type viewModelType, IReadOnlyList<object> viewModels)
        {
            SearchResultDataGridView.AutoGenerateColumns = false;
            SearchResultDataGridView.Columns.Clear();
            foreach (var column in columns)
            {
                var dataGridViewColumn = new DataGridViewTextBoxColumn();
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewColumn.HeaderText = column.HeaderText;
                dataGridViewColumn.DataPropertyName = column.PropertyName;
                dataGridViewColumn.Width = column.Width;
                SearchResultDataGridView.Columns.Add(dataGridViewColumn);
            }

            var listType = typeof(BindingList<>).MakeGenericType(viewModelType);
            var list = Activator.CreateInstance(listType, viewModels) as IList;
            SearchResultDataGridView.DataSource = list;
        }

        private void OpenThraciaRngListFormMenuItem_Click(object sender, EventArgs e)
        {
            var form = Thracia.UI.RngList.RngListFormLauncher.CreateForm();
            form.Show();
        }
    }
}
