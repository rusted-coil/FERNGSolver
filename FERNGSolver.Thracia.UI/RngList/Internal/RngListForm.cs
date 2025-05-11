namespace FERNGSolver.Thracia.UI.RngList.Internal
{
    internal partial class RngListForm : Form
    {
        public RngListForm()
        {
            InitializeComponent();

            for (int i = 0; i < 10; ++i)
            {
                var userControl = new RngViewUserControl();
                AddUserControl(userControl);
            }
        }

        public void AddUserControl(UserControl userControl)
        {
            // 現在のコントロール数を取得
            int controlCount = RngViewPanel.Controls.Count;

            // UserControlの位置を計算
            userControl.Top = controlCount * userControl.Height;
            userControl.Left = 0;

            // UserControlをPanelに追加
            RngViewPanel.Controls.Add(userControl);
        }

        public void RemoveLastUserControl()
        {
            if (RngViewPanel.Controls.Count > 0)
            {
                // 最後のコントロールを削除
                var lastControl = RngViewPanel.Controls[RngViewPanel.Controls.Count - 1];
                RngViewPanel.Controls.Remove(lastControl);
                lastControl.Dispose();
            }
        }
    }
}
