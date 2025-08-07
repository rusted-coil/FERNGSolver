using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Common.Presentation.ViewContracts;
using FERNGSolver.Common.UI.Interfaces;
using FERNGSolver.Gba.Application.Config;
using FERNGSolver.Gba.Presentation.RngView.ViewContracts;
using FERNGSolver.Gba.Presentation.Search;
using FERNGSolver.Gba.Presentation.ViewContracts;
using FERNGSolver.Gba.UI.RngView.Internal;
using FERNGSolver.Gba.UI.Search;
using System.Diagnostics;
using System.Reactive.Disposables;

namespace FERNGSolver.Gba.UI.Internal
{
    public class MainFormEntry : IMainFormEntry
    {
        public static string Title => "GBA";
        string IMainFormEntry.Title => Title;

        private IExtendedMainFormView? m_ExtendedMainFormView = null;
        private IRngViewListView? m_RngViewListView = null;

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
            m_ExtendedMainFormView = userControl;

            var disposables = new CompositeDisposable();

            PresenterFactory.Create(userControl, m_ConfigService, m_ErrorNotifier).AddTo(disposables);

            var rngViewListView = new RngViewListView(rngViewListViewPanel);
            rngViewListView.AddTo(disposables);
            m_RngViewListView = rngViewListView;

            Presentation.RngView.PresenterFactory.CreateListPresenter(userControl, m_RngViewListView).AddTo(disposables);
            mainFormView.AddRngViewButtonClicked.Subscribe(_ => m_RngViewListView.AddView(userControl, 0)).AddTo(disposables);
            mainFormView.AddRngViewRequestedFromSearchResults.Subscribe(AddRngViewFromSearchResults).AddTo(disposables);

            // UserControlの破棄時にPresenterも破棄
            userControl.Disposed += (sender, args) => disposables.Dispose();

            return userControl;
        }

        private void AddRngViewFromSearchResults(IEnumerable<object> viewModels)
        {
            Debug.Assert(m_ExtendedMainFormView != null, "m_ExtendedMainFormView should not be null");
            Debug.Assert(m_RngViewListView != null, "m_RngViewListView should not be null");

            foreach (var viewModel in viewModels)
            {
                if (viewModel is IRngStateResultViewModel rngState)
                {
                    m_RngViewListView.AddView(m_ExtendedMainFormView, int.Parse(rngState.Position));
                }
            }
        }
    }
}
