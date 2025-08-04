using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Gba.Presentation.RngView.ViewContracts;
using FERNGSolver.Gba.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Gba.Presentation.RngView.Internal
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

            m_MainFormView.GetRngViewInitializeButtonClicked(Const.Title).Subscribe(_ => OnInitializeButtonClicked()).AddTo(m_Disposables);
        }

        public void Dispose()
        {
            m_Disposables.Dispose();
        }

        private void OnInitializeButtonClicked()
        {
            m_ListView.Clear();
            // とりあえず1つ追加
            m_ListView.AddView(m_MainFormView);
        }
    }
}
