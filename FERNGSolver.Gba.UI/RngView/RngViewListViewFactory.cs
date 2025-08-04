using FERNGSolver.Gba.Presentation.RngView.ViewContracts;

namespace FERNGSolver.Gba.UI.RngView
{
    public static class RngViewListViewFactory
    {
        public static IRngViewListView Create(Panel listViewPanel)
        {
            return new Internal.RngViewListView(listViewPanel);
        }
    }
}
