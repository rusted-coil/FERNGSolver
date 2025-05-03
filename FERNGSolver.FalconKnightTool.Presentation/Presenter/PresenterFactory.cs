using FERNGSolver.FalconKnightTool.Common.Interfaces;
using FERNGSolver.FalconKnightTool.Presentation.Presenter.Internal;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;

namespace FERNGSolver.FalconKnightTool.Presentation.Presenter
{
    public static class PresenterFactory
    {
        public static IFalconKnightToolPresenter Create(IFalconKnightToolView view, params IFalconKnightToolEntryCore[] entries)
        {
            return new FalconKnightToolPresenter(view, entries);
        }
    }
}
