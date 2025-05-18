using FERNGSolver.Common.Types;
using FERNGSolver.FalconKnightTool.Domain.Path;

namespace FERNGSolver.Gba.Presentation.FalconKnight.Internal
{
    internal sealed class PathConverter : IPathConverter
    {
        public IReadOnlyList<bool> PathToCx(IReadOnlyList<GridPosition> path)
        {
            return Array.Empty<bool>();
        }
    }
}
