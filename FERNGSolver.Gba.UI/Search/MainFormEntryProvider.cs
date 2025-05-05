using FERNGSolver.Common.ViewContracts;
using FERNGSolver.Gba.Presentation.Search;
using FERNGSolver.Windows.Common;
using FERNGSolver.Windows.Common.Interfaces;

namespace FERNGSolver.Gba.UI.Search
{
    public static class MainFormEntryProvider
    {
        public static IMainFormEntry Create(IMainFormView mainFormView)
        {
            var userControl = new MainFormUserControl(mainFormView);
            userControl.InitializeDefaults();

            var presenter = PresenterFactory.Create(userControl);

            // UserControlの破棄時にPresenterも破棄
            userControl.Disposed += (sender, args) => presenter.Dispose();

            return new MainFormEntry(
                "GBA",
                userControl
                );
        }
    }
}
