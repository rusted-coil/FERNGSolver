using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Radiance.Presentation.RngView.ViewContracts;
using FERNGSolver.Radiance.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Radiance.Presentation.RngView.Internal
{
    internal sealed class RngViewListPresenter : IRngViewListPresenter
    {
        private readonly IExtendedMainFormView m_MainFormView;
        private readonly IRngViewListView m_ListView;

        private readonly CompositeDisposable m_Disposables = new CompositeDisposable();

        public RngViewListPresenter(IExtendedMainFormView mainFormView, IRngViewListView listView)
        {
            m_MainFormView = mainFormView;
            m_ListView = listView;

            // 初期状態で1つ追加
            m_ListView.AddView(m_MainFormView, 0);
        }

        public void Dispose()
        {
            m_Disposables.Dispose();
        }

        public void AddRngView(int initialPosition)
        {
            m_ListView.AddView(m_MainFormView, initialPosition);
        }
    }
}
