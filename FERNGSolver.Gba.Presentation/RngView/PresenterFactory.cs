using FERNGSolver.Gba.Presentation.RngView.ViewContracts;
using FERNGSolver.Gba.Presentation.ViewContracts;

namespace FERNGSolver.Gba.Presentation.RngView
{
    public static class PresenterFactory
    {
        /// <summary>
        /// 乱数ビューア全体を管理するPresenterを作成します。
        /// </summary>
        public static IRngViewListPresenter CreateListPresenter(IExtendedMainFormView mainFormView, IRngViewListView listView)
        {
            return new Internal.RngViewListPresenter(mainFormView, listView);
        }

        /// <summary>
        /// RngView一つあたりのPresenterを作成します。
        /// </summary>
        public static IRngViewPresenter CreateViewPresenter(IRngView view)
        {
            return new Internal.RngViewPresenter(view);
        }
    }
}
