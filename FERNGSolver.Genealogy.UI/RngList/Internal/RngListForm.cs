using FERNGSolver.Genealogy.Presentation.RngList.RngView;

namespace FERNGSolver.Genealogy.UI.RngList.Internal
{
    internal partial class RngListForm : Form
    {
        public RngListForm()
        {
            InitializeComponent();

            var userControl = new RngViewUserControl();
            AddUserControl(userControl);
            var presenter = RngViewPresenterFactory.Create(userControl);
        }

        public void AddUserControl(UserControl userControl)
        {
            // 現在のコントロール数を取得
            int controlCount = RngViewPanel.Controls.Count;

            // UserControlの位置を計算
            userControl.Top = controlCount * userControl.Height;
            userControl.Left = 0;

            // Dockを設定して横幅いっぱいに広げる
            userControl.Dock = DockStyle.Top;

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
