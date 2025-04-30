using FERNGSolver.FalconKnightTool.UI;

namespace FERNGSolver
{
    public partial class Form1 : Form
    {
//        private IFalconKnightTool? m_FalconKnightTool = null;

        public Form1()
        {
            InitializeComponent();

            var form = FalconKnightToolLauncher.CreateToolForm();
            form.Show();

//            m_FalconKnightTool = FalconKnightToolFactory.Create();
//            m_FalconKnightTool.Show();
        }
    }
}
