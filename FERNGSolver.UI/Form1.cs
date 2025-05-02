using FERNGSolver.FalconKnightTool.UI;

namespace FERNGSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var bindings = Gba.UI.FalconKnight.FalconKnightToolIntegration.Create();
            var form = FalconKnightToolLauncher.CreateToolForm(bindings.SearchConditionControl, bindings.SearchStrategy);
            form.Show();
        }
    }
}
