using FERNGSolver.Gba.Presentation.RngView;
using FERNGSolver.Gba.Presentation.RngView.ViewContracts;
using FERNGSolver.Gba.Presentation.ViewContracts;

namespace FERNGSolver.Gba.UI.RngView.Internal
{
    internal class RngViewListView : IRngViewListView
    {
        private readonly Panel m_ListViewPanel;

        public RngViewListView(Panel listViewPanel)
        {
            m_ListViewPanel = listViewPanel;
        }

        public void Clear()
        {
            m_ListViewPanel.Controls.Clear();
        }

        public void AddView(IExtendedMainFormView mainFormView)
        {
            var userControl = new RngViewUserControl();
            AddUserControl(userControl);
            var presenter = PresenterFactory.CreateViewPresenter(mainFormView, userControl);

            // UserControlの破棄時にPresenterも破棄
            userControl.Disposed += (sender, args) => presenter.Dispose();
        }

        public void AddUserControl(UserControl userControl)
        {
            // 現在のコントロール数を取得
            int controlCount = m_ListViewPanel.Controls.Count;

            // UserControlの位置を計算
            userControl.Top = controlCount * userControl.Height;
            userControl.Left = 0;

            // Dockを設定して横幅いっぱいに広げる
            userControl.Dock = DockStyle.Top;

            // UserControlをPanelに追加
            m_ListViewPanel.Controls.Add(userControl);
        }

        public void RemoveLastUserControl()
        {
            if (m_ListViewPanel.Controls.Count > 0)
            {
                // 最後のコントロールを削除
                var lastControl = m_ListViewPanel.Controls[m_ListViewPanel.Controls.Count - 1];
                m_ListViewPanel.Controls.Remove(lastControl);
                lastControl.Dispose();
            }
        }
    }
}
