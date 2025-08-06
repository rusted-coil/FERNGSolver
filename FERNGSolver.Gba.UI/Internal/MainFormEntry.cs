using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Common.Presentation.ViewContracts;
using FERNGSolver.Common.UI.Interfaces;
using FERNGSolver.Gba.Application.Config;
using FERNGSolver.Gba.UI.RngView.Internal;
using FERNGSolver.Gba.UI.Search;
using System.Reactive.Disposables;

namespace FERNGSolver.Gba.UI.Internal
{
    public class MainFormEntry : IMainFormEntry
    {
        public static string Title => "GBA";
        string IMainFormEntry.Title => Title;

        private readonly IConfigService m_ConfigService;
        private readonly IErrorNotifier m_ErrorNotifier;

        public MainFormEntry(IConfigService configService, IErrorNotifier errorNotifier)
        {
            m_ConfigService = configService;
            m_ErrorNotifier = errorNotifier;
        }

        public UserControl CreateSearchConditionUserControl(IMainFormView mainFormView, Panel rngViewListViewPanel)
        {
            var userControl = new MainFormUserControl(mainFormView);

            var disposables = new CompositeDisposable();

            Presentation.Search.PresenterFactory.Create(userControl, m_ConfigService, m_ErrorNotifier).AddTo(disposables);
            Presentation.RngView.PresenterFactory.CreateListPresenter(userControl, new RngViewListView(rngViewListViewPanel)).AddTo(disposables);

            // UserControlの破棄時にPresenterも破棄
            userControl.Disposed += (sender, args) => disposables.Dispose();

            return userControl;
        }
    }
}
