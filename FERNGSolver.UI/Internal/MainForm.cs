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

        public void ShowSearchResults(Type viewModelType, IReadOnlyList<object> viewModels)
        {
            var listType = typeof(BindingList<>).MakeGenericType(viewModelType);
            var list = Activator.CreateInstance(listType, viewModels) as IList;
            SearchResultDataGridView.DataSource = list;
        }

        private void OpenThraciaRngListFormMenuItem_Click(object sender, EventArgs e)
        {
            var form = FERNGSolver.Thracia.UI.RngList.RngListFormLauncher.CreateForm();
            form.Show();
        }
    }
}
