using FERNGSolver.Application.Config;
using FERNGSolver.Common.Presentation.Interfaces;
using FERNGSolver.Common.UI.Interfaces;
using FormRx.Button;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Subjects;
using System.Linq;

namespace FERNGSolver.UI.Internal
{
    internal partial class MainForm : Form, Common.Presentation.ViewContracts.IMainFormView, Presentation.ViewContracts.IMainFormView
    {
        public string SelectingTitle { get; private set; } = string.Empty;

        public IObservable<Unit> SearchButtonClicked => m_SearchButton.Clicked;
        public IObservable<Unit> AddRngViewButtonClicked => m_AddRngViewButton.Clicked;

        Subject<IEnumerable<object>> m_AddRngViewRequestedFromSearchResults = new Subject<IEnumerable<object>>();
        public IObservable<IEnumerable<object>> AddRngViewRequestedFromSearchResults => m_AddRngViewRequestedFromSearchResults;

        public IObservable<Unit> Initialized => m_Initialized;
        AsyncSubject<Unit> m_Initialized = new AsyncSubject<Unit>();

        public IObservable<Unit> PersistentConfigChanged => m_PersistentConfigChanged;
        Subject<Unit> m_PersistentConfigChanged = new Subject<Unit>();
        private void PersistentConfigControlValueChanged(object sender, EventArgs e) => m_PersistentConfigChanged.OnNext(Unit.Default);

        Dictionary<string, IMainFormEntry> m_Entries = new Dictionary<string, IMainFormEntry>();
        Dictionary<string, ToolStripMenuItem> m_SwitchTitleMenuItems = new Dictionary<string, ToolStripMenuItem>();
        UserControl? m_CurrentSearchConditionUserControl = null;

        private readonly IButton m_SearchButton;
        private readonly IButton m_AddRngViewButton;

        public MainForm()
        {
            InitializeComponent();

            m_SearchButton = ButtonFactory.CreateButton(SearchButton);
            m_AddRngViewButton = ButtonFactory.CreateButton(AddRngViewButton);

            this.Text = "FERNGSolver v2.0.0";
        }

        public void SetEntries(params IMainFormEntry[] entries)
        {
            foreach (var entry in entries)
            {
                m_Entries.Add(entry.Title, entry);

                // ToolBarMenuにタイトルボタンを追加
                var menuItem = new ToolStripMenuItem(entry.Title);
                menuItem.Click += (sender, e) =>
                {
                    if (!menuItem.Checked)
                    {
                        SwitchTitle(entry.Title);
                        m_PersistentConfigChanged.OnNext(Unit.Default);
                    }
                };
                SwitchTitleTreeMenuItem.DropDownItems.Add(menuItem);
                m_SwitchTitleMenuItems.Add(entry.Title, menuItem);
            }

            // とりあえずエントリーのセット=初期化完了としておく。
            m_Initialized.OnNext(Unit.Default);
            m_Initialized.OnCompleted();
        }

        private void SwitchTitle(string title)
        {
            Debug.Assert(m_Entries.ContainsKey(title), $"Title '{title}' is not registered in the entries.");

            // 現在のUserControlを破棄
            if (m_CurrentSearchConditionUserControl != null)
            {
                SearchConditionPanel.Controls.Remove(m_CurrentSearchConditionUserControl);
                m_CurrentSearchConditionUserControl.Dispose();
                m_CurrentSearchConditionUserControl = null;
            }
            SearchResultDataGridView.Columns.Clear();

            SwitchTitleTreeMenuItem.Text = title;
            foreach (var menuItem in m_SwitchTitleMenuItems)
            {
                menuItem.Value.Checked = (menuItem.Key == title);
            }
            SelectingTitle = title;

            // 新しいUserControlを生成
            var userControl = m_Entries[title].CreateSearchConditionUserControl(this, RngViewPanel);
            int height = userControl.Size.Height; // Dock = FillでAddする前にサイズを取得しておかないと意図しない値になってしまっている
            userControl.Dock = DockStyle.Fill;
            SearchConditionPanel.Controls.Add(userControl);
            m_CurrentSearchConditionUserControl = userControl;

            AdjustMainFormSize(height);

            // タイトル切り替え時は乱数ビュータブを表示
            ResultsTabControl.SelectedTab = RngViewTabPage;
        }

        private void AdjustMainFormSize(int searchConditionControlHeight)
        {
            // ウィンドウサイズの動的調整
            // 例えばGBAのUserControlの高さが635の時、メインフォームの高さは760にするのがちょうどいい
            // つまり全UserControlの高さの最大値+125が理想のフォームの高さ
            // ただし、表示ディスプレイのWorkingAreaがこれより狭い場合には全体を表示することを諦めて高さを縮めなければならない
            const int MainFormMarginHeight = 125;

            var idealHeight = searchConditionControlHeight + MainFormMarginHeight;
            var workingArea = Screen.GetWorkingArea(this);

            this.Size = new Size(Math.Min(this.Size.Width, workingArea.Width), Math.Min(Math.Max(this.Size.Height, idealHeight), workingArea.Height));
        }

        public void ReflectConfig(IConfig config)
        {
            if (!string.IsNullOrEmpty(config.SelectingTitle))
            {
                SwitchTitle(config.SelectingTitle);
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

            // 検索結果タブを表示
            ResultsTabControl.SelectedTab = SearchResultsTabPage;
        }

        private void SearchResultDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = SearchResultDataGridView.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    SearchResultDataGridView.ClearSelection();
                    SearchResultDataGridView.Rows[hit.RowIndex].Selected = true;
                    SearchResultDataGridView.CurrentCell = SearchResultDataGridView.Rows[hit.RowIndex].Cells[0];
                    SearchResultContextMenuStrip.Show(SearchResultDataGridView, e.Location);
                }
            }
        }

        private void ResultToRngViewMenuItem_Click(object sender, EventArgs e)
        {
            if (SearchResultDataGridView.SelectedRows.Count > 0)
            {
                var row = SearchResultDataGridView.SelectedRows[0];
                var data = row.DataBoundItem;
                m_AddRngViewRequestedFromSearchResults.OnNext(new object[] { data });

                // AddRngViewの処理が行われたはずなので、タブを切り替える
                ResultsTabControl.SelectedTab = RngViewTabPage;
            }
        }

        private void AllResultToRngViewMenuItem_Click(object sender, EventArgs e)
        {
            // DataSourceから先頭最大10件をIEnumerable<object>として取得し通知（Linqで簡潔に記述）
            if (SearchResultDataGridView.DataSource is IList list && list.Count > 0)
            {
                m_AddRngViewRequestedFromSearchResults.OnNext(list.Cast<object>().Take(10));

                // AddRngViewの処理が行われたはずなので、タブを切り替える
                ResultsTabControl.SelectedTab = RngViewTabPage;
            }
        }
    }
}
