using FERNGSolver.FalconKnightTool.Domain.Path;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;

namespace FERNGSolver.Gba.Presentation.FalconKnight.Internal
{
    internal sealed class FalconKnightToolEntry : IFalconKnightToolEntry
    {
        public string Title => Const.Title;
        public IPathConverter PathConverter { get; }

        public FalconKnightToolEntry()
        {
            PathConverter = new PathConverter();
        }
    }
}
