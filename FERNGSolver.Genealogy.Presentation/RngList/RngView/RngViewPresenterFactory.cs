using FERNGSolver.Genealogy.Presentation.RngList.RngView.ViewContracts;

namespace FERNGSolver.Genealogy.Presentation.RngList.RngView
{
    /// <summary>
    /// RngView一つあたりのPresenterを作成するファクトリクラスです。
    /// </summary>
    public static class RngViewPresenterFactory
    {
        public static IRngViewPresenter Create(IRngView view)
        {
            return new Internal.RngViewPresenter(view);
        }
    }
}
