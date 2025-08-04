using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Common.Presentation.ViewContracts;
using FERNGSolver.Common.UI;
using FERNGSolver.Common.UI.Interfaces;
using FERNGSolver.Gba.Application.Config;
using FERNGSolver.Gba.Presentation;
using FERNGSolver.Gba.Presentation.RngView.ViewContracts;
using FERNGSolver.Gba.UI.Search;
using System.Reactive.Disposables;

namespace FERNGSolver.Gba.UI
{
    public static class MainFormEntryProvider
    {
        public static IMainFormEntry Create(IMainFormView mainFormView, IRngViewListView listView, IConfigService configService, IErrorNotifier errorNotifier)
        {
            var userControl = new MainFormUserControl(mainFormView);

            var disposables = new CompositeDisposable();

            Presentation.Search.PresenterFactory.Create(userControl, configService, errorNotifier).AddTo(disposables);
            Presentation.RngView.PresenterFactory.CreateListPresenter(userControl, listView).AddTo(disposables);

            // UserControlの破棄時にPresenterも破棄
            userControl.Disposed += (sender, args) => disposables.Dispose();

            return new MainFormEntry(Const.Title, userControl);
        }
    }
}
