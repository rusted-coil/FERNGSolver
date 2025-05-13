using FERNGSolver.Common.ViewContracts;
using FERNGSolver.Thracia.Presentation.ViewContracts;

namespace FERNGSolver.Thracia.Presentation.Search
{
    public static class PresenterFactory
    {
        public static ISearchPresenter Create(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            return new Internal.SearchPresenter(mainFormView, errorNotifier);
        }
    }
}
