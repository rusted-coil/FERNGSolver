using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;

namespace FERNGSolver.Gba.Presentation.FalconKnight
{
    public static class FalconKnightToolEntryFactory
    {
        public static IFalconKnightToolEntry Create(string title, Action<string> addCxString)
        {
            return new Internal.FalconKnightToolEntry(title, addCxString);
        }
    }
}
