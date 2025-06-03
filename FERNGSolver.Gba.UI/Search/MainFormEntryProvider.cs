using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Presentation.ViewContracts;
using FERNGSolver.Common.UI;
using FERNGSolver.Common.UI.Interfaces;
using FERNGSolver.Gba.Application.Config;
using FERNGSolver.Gba.Presentation;
using FERNGSolver.Gba.Presentation.Search;

namespace FERNGSolver.Gba.UI.Search
{
    public static class MainFormEntryProvider
    {
        public static IMainFormEntry Create(IMainFormView mainFormView, IConfigService configService, IErrorNotifier errorNotifier)
        {
            var userControl = new MainFormUserControl(mainFormView);

            var presenter = PresenterFactory.Create(userControl, configService, errorNotifier);

            // UserControlの破棄時にPresenterも破棄
            userControl.Disposed += (sender, args) => presenter.Dispose();

            return new MainFormEntry(Const.Title, userControl);
        }
    }
}
