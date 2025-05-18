using FERNGSolver.FalconKnightTool.Presentation.Presenter.Internal;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;

namespace FERNGSolver.FalconKnightTool.Presentation.Presenter
{
    public static class PresenterFactory
    {
        public static IFalconKnightToolPresenter Create(IFalconKnightToolView view, IFalconKnightToolEntry entry)
        {
            return new FalconKnightToolPresenter(view, entry);
        }
    }
}
