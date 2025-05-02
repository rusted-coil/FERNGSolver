using FERNGSolver.FalconKnightTool.Common.Interfaces;
using FERNGSolver.Gba.Presentation.ViewContracts;

namespace FERNGSolver.Gba.Presentation.FalconKnight
{
    public static class SearchStrategyFactory
    {
        public static IFalconKnightToolSearchStrategy Create(IFalconKnightToolSearchConditionView view)
        {
            return new Internal.SearchStrategy(view);
        }
    }
}
