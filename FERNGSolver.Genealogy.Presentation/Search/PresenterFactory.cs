using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Genealogy.Presentation.ViewContracts;

namespace FERNGSolver.Genealogy.Presentation.Search
{
    public static class PresenterFactory
    {
        public static ISearchPresenter Create(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            return new Internal.SearchPresenter(mainFormView, errorNotifier);
        }
    }
}
