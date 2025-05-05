using FERNGSolver.Common.ViewContracts;
using FERNGSolver.Gba.Presentation.ViewContracts;

namespace FERNGSolver.Gba.Presentation.Search
{
    public static class PresenterFactory
    {
        public static ISearchPresenter Create(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            return new Internal.SearchPresenter(mainFormView, errorNotifier);
        }
    }
}
