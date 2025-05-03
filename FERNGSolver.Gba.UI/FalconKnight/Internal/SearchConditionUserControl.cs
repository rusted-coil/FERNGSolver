using FERNGSolver.Gba.Domain.RNG;
using FERNGSolver.Gba.Presentation.ViewContracts;

namespace FERNGSolver.Gba.UI.FalconKnight.Internal
{
    internal partial class SearchConditionUserControl : UserControl, IFalconKnightToolSearchConditionView
    {
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

        public SearchConditionUserControl()
        {
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
