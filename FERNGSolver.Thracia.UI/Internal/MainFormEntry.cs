using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Common.Presentation.ViewContracts;
using FERNGSolver.Common.UI.Interfaces;
using FERNGSolver.Thracia.Presentation.Search;
using FERNGSolver.Thracia.UI.Search.Internal;
using System.Reactive.Disposables;

namespace FERNGSolver.Thracia.UI.Internal
{
    public class MainFormEntry : IMainFormEntry
    {
        public static string Title => "トラキア776";
        string IMainFormEntry.Title => Title;

        private readonly IErrorNotifier m_ErrorNotifier;

        public MainFormEntry(IErrorNotifier errorNotifier)
        {
            m_ErrorNotifier = errorNotifier;
        }

        public UserControl CreateSearchConditionUserControl(IMainFormView mainFormView, Panel rngViewListViewPanel)
        {
            var userControl = new MainFormUserControl(mainFormView);

            var disposables = new CompositeDisposable();

            PresenterFactory.Create(userControl, m_ErrorNotifier).AddTo(disposables);

            // UserControlの破棄時にPresenterも破棄
            userControl.Disposed += (sender, args) => disposables.Dispose();

            return userControl;
        }
    }
}
