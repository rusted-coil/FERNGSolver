using FERNGSolver.Common.ViewContracts;
using FERNGSolver.Gba.Application.Config;
using FERNGSolver.Gba.Presentation;
using FERNGSolver.Gba.Presentation.Search;
using FERNGSolver.Windows.Common;
using FERNGSolver.Windows.Common.Interfaces;

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
