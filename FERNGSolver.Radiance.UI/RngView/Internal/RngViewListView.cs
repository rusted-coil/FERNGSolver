using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Radiance.Presentation.RngView;
using FERNGSolver.Radiance.Presentation.RngView.ViewContracts;
using FERNGSolver.Radiance.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Radiance.UI.RngView.Internal
{
    internal class RngViewListView : IRngViewListView, IDisposable
    {
        private readonly Panel m_ListViewPanel;

        public RngViewListView(Panel listViewPanel)
        {
            m_ListViewPanel = listViewPanel;
        }

        public void Dispose()
        {
            foreach (Control control in m_ListViewPanel.Controls)
            {
                control.Dispose();
            }
            m_ListViewPanel.Controls.Clear();
        }

        public void AddView(IExtendedMainFormView mainFormView, int tableIndex, int initialPosition)
        {
            var userControl = new RngViewUserControl(tableIndex, initialPosition);
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
            // Dockを設定して横幅いっぱいに広げる
            userControl.Dock = DockStyle.Top;

            // 末尾に追加ができないため手動で要素を並べ替えて対応している。
            // 要素数が増えるとパフォーマンスに影響する可能性があるので注意。

            m_ListViewPanel.SuspendLayout();
            try
            {
                var controls = m_ListViewPanel.Controls.Cast<Control>().ToList();

                m_ListViewPanel.Controls.Clear();
                m_ListViewPanel.Controls.Add(userControl);
                m_ListViewPanel.Controls.AddRange(controls.ToArray());
            }
            finally
            {
                m_ListViewPanel.ResumeLayout();
            }
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
