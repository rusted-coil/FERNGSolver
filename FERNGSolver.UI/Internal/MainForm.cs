using FERNGSolver.Common.Interfaces;
using FERNGSolver.Common.ViewContracts;
using FERNGSolver.Windows.Common.Interfaces;
using FormRx.Button;
using System.Collections;
using System.ComponentModel;
using System.Reactive;

namespace FERNGSolver
{
    internal partial class MainForm : Form, IMainFormView
    {
        public IObservable<Unit> SearchButtonClicked => m_SearchButton.Clicked;

        private IButton m_SearchButton;

        public MainForm()
        {
            InitializeComponent();

            m_SearchButton = ButtonFactory.CreateButton(SearchButton);

            SearchConditionTabControl.TabPages.Clear();

            this.Text = "FERNGSolver v1.0.0";
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
        }

        public void ShowSearchResults(IReadOnlyList<ITableColumn> columns, Type viewModelType, IReadOnlyList<object> viewModels)
        {
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
