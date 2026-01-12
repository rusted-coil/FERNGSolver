using FERNGSolver.Radiance.Presentation.RngView.ViewContracts;
using FERNGSolver.Radiance.Presentation.ViewContracts;

namespace FERNGSolver.Radiance.Presentation.RngView
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
        public static IRngViewPresenter CreateViewPresenter(IExtendedMainFormView mainFormView, IRngView view)
        {
            return new Internal.RngViewPresenter(mainFormView, view);
        }
    }
}
