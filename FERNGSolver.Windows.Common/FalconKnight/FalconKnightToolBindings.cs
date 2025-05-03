using FERNGSolver.FalconKnightTool.Common.Interfaces;

namespace FERNGSolver.Common.FalconKnight
{
    public record FalconKnightToolBindings(
        UserControl SearchConditionControl,
        IFalconKnightToolSearchStrategy SearchStrategy
    );
}
