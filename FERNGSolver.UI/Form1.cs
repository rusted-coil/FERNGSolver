using FERNGSolver.FalconKnightTool.UI;

namespace FERNGSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var form = FalconKnightToolLauncher.CreateToolForm(
                Thracia.UI.FalconKnight.FalconKnightToolEntryProvider.Create(),
                Gba.UI.FalconKnight.FalconKnightToolEntryProvider.Create());
            form.Show();
        }
    }
}
