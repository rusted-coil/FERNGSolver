using FERNGSolver.Common.ViewContracts;
using FERNGSolver.Gba.Domain.RNG;
using FERNGSolver.Gba.Presentation.ViewContracts;
using System.ComponentModel;
using System.Reactive;

namespace FERNGSolver.Gba.UI.Search
{
    internal partial class MainFormUserControl : UserControl, IExtendedMainFormView
    {
        public IObservable<Unit> SearchButtonClicked => m_MainFormView.SearchButtonClicked;
        public void ShowSearchResults(Type viewModelType, IReadOnlyList<object> viewModels) => m_MainFormView.ShowSearchResults(viewModelType, viewModels);

        public bool ContainsCombat => ContainsCombatCheckBox.Checked;
        public bool ContainsGrowth => ContainsGrowthCheckBox.Checked;

        public IReadOnlyList<ushort> Seeds {
            get {
                var values = new ushort[3];
                //                if()
                return values;
            }
        }

        public int OffsetMin {
            get {
                if (int.TryParse(OffsetMinTextBox.Text, out var value))
                {
                    return value;
                }
                return 0;
            }
        }

        public int OffsetMax {
            get {
                if (int.TryParse(OffsetMaxTextBox.Text, out var value))
                {
                    return value;
                }
                return 0;
            }
        }

        private IMainFormView m_MainFormView;

        public MainFormUserControl(IMainFormView mainFormView)
        {
            m_MainFormView = mainFormView;
            InitializeComponent();
        }

        public void InitializeDefaults()
        {
            SetDefaultSeeds();
            OffsetMinTextBox.Text = "0";
            OffsetMaxTextBox.Text = "1000";
        }

        private void SetDefaultSeeds()
        {
            var seeds = Const.DefaultSeeds;
            Seed0TextBox.Text = seeds[0].ToString("X4");
            Seed1TextBox.Text = seeds[1].ToString("X4");
            Seed2TextBox.Text = seeds[2].ToString("X4");
        }

        private void DefaultSeedButton_Click(object sender, EventArgs e)
        {
            SetDefaultSeeds();
        }
    }
}
