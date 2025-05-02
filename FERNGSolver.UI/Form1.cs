using FERNGSolver.FalconKnightTool.UI;
using System.Diagnostics;

namespace FERNGSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var form = FalconKnightToolLauncher.CreateToolForm(Gba.UI.Search.SearchUserControlFactoryProvider.CreateFalconKnightToolSearchConditionUserControlFactory());
            form.Show();
        }
    }
}
