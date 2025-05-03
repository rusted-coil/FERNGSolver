using FERNGSolver.FalconKnightTool.Common.Interfaces;
using FERNGSolver.Thracia.Presentation.ViewContracts;

namespace FERNGSolver.Thracia.Presentation.FalconKnight
{
    public static class SearchStrategyFactory
    {
        public static IFalconKnightToolSearchStrategy Create(IFalconKnightToolSearchConditionView view)
        {
            return new Internal.SearchStrategy(view);
        }
    }
}
