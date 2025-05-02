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
    }
}
