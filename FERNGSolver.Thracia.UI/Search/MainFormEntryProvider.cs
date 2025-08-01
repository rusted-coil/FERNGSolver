using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Presentation.ViewContracts;
using FERNGSolver.Common.UI;
using FERNGSolver.Common.UI.Interfaces;
using FERNGSolver.Thracia.Presentation;
using FERNGSolver.Thracia.Presentation.Search;

namespace FERNGSolver.Thracia.UI.Search
{
    public static class MainFormEntryProvider
    {
        public static IMainFormEntry Create(IMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            var userControl = new Internal.MainFormUserControl(mainFormView);
//            userControl.InitializeDefaults();

            var presenter = PresenterFactory.Create(userControl, errorNotifier);

            // UserControlの破棄時にPresenterも破棄
            userControl.Disposed += (sender, args) => presenter.Dispose();

            return new MainFormEntry(Const.Title, userControl);
        }
    }
}
