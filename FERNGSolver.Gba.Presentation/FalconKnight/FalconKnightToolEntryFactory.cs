using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;

namespace FERNGSolver.Gba.Presentation.FalconKnight
{
    public static class FalconKnightToolEntryFactory
    {
        public static IFalconKnightToolEntry Create(Action<string> addCxString)
        {
            return new Internal.FalconKnightToolEntry(addCxString);
        }
    }
}
