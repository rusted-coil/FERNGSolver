using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Radiance.Presentation.ViewContracts;

namespace FERNGSolver.Radiance.Presentation.Search
{
    public static class PresenterFactory
    {
        public static ISearchPresenter Create(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            return new Internal.SearchPresenter(mainFormView, errorNotifier);
        }
    }
}
