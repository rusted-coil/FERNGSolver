using FERNGSolver.Thracia.Presentation.ViewContracts;

namespace FERNGSolver.Thracia.UI.FalconKnight.Internal
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

        public int? TableIndex {
            get {
                if (IsSpecificTableCheckBox.Checked && int.TryParse(TableIndexTextBox.Text, out var value))
                {
                    return value;
                }
                return null;
            }
        }

        public SearchConditionUserControl()
        {
            InitializeComponent();
        }

        public void InitializeDefaults()
        {
            OffsetMinTextBox.Text = "0";
            OffsetMaxTextBox.Text = "0";
        }
    }
}
