using FERNGSolver.FalconKnightTool.Common.Interfaces;
using FERNGSolver.Gba.Presentation.FalconKnight;

namespace FERNGSolver.Gba.UI.FalconKnight
{
    public record GbaFalconKnightToolBindings(
        UserControl SearchConditionControl,
        IFalconKnightToolSearchStrategy SearchStrategy
    );

    public static class FalconKnightToolIntegration
    {
        public static GbaFalconKnightToolBindings Create()
        {
            var searchConditionControl = new Internal.SearchConditionUserControl();
            return new GbaFalconKnightToolBindings(
                searchConditionControl,
                SearchStrategyFactory.Create(searchConditionControl));
        }
    }
}
