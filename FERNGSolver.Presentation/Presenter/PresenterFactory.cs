using FERNGSolver.Application.Config;
using FERNGSolver.Presentation.ViewContracts;

namespace FERNGSolver.Presentation.Presenter
{
    public static class PresenterFactory
    {
        public static IMainFormPresenter Create(IMainFormView mainFormView, IConfigService configService)
        {
            return new Internal.MainFormPresenter(mainFormView, configService);
        }
    }
}
