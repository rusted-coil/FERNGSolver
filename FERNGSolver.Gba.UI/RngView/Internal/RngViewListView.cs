using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Gba.Presentation.RngView;
using FERNGSolver.Gba.Presentation.RngView.ViewContracts;
using FERNGSolver.Gba.Presentation.ViewContracts;
using System.Reactive.Disposables;

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

        public void AddView(IExtendedMainFormView mainFormView, int initialPosition)
        {
            var userControl = new RngViewUserControl(initialPosition);
            AddUserControl(userControl);

            var disposables = new CompositeDisposable();

            PresenterFactory.CreateViewPresenter(mainFormView, userControl).AddTo(disposables);

            // UserControlの破棄時にPresenterも破棄
            userControl.Disposed += (sender, args) => disposables.Dispose();

            // xボタンが押されたら削除
            userControl.RemoveButtonClicked.Subscribe(_ => RemoveUserControl(userControl)).AddTo(disposables);
        }

        private void AddUserControl(UserControl userControl)
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

        private void RemoveUserControl(UserControl userControl)
        {
            if (m_ListViewPanel.Controls.Contains(userControl))
            {
                m_ListViewPanel.Controls.Remove(userControl);
                userControl.Dispose();
            }
        }
    }
}
