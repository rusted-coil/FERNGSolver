using FERNGSolver.Gba.Presentation.RngView.ViewContracts;

namespace FERNGSolver.Gba.Presentation.RngView
{
    public static class PresenterFactory
    {
        /// <summary>
        /// 乱数ビューア全体を管理するPresenterを作成します。
        /// </summary>
        public static IRngViewListPresenter CreateListPresenter()
        {
            //            return new Internal.RngViewListPresenter(view);
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
