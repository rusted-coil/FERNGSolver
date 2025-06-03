using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Gba.Application.Config;
using FERNGSolver.Gba.Presentation.ViewContracts;

namespace FERNGSolver.Gba.Presentation.Search
{
    public static class PresenterFactory
    {
        public static ISearchPresenter Create(IExtendedMainFormView mainFormView, IConfigService configService, IErrorNotifier errorNotifier)
        {
            return new Internal.SearchPresenter(mainFormView, configService, errorNotifier);
        }
    }
}
