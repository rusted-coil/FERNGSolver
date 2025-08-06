using FERNGSolver.FalconKnightTool.Domain.Path;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;

namespace FERNGSolver.Gba.Presentation.FalconKnight.Internal
{
    internal sealed class FalconKnightToolEntry : IFalconKnightToolEntry
    {
        public string Title { get; }
        public IPathConverter PathConverter { get; }
        public void AddCxString(string cxString) => m_AddCxString(cxString);

        private readonly Action<string> m_AddCxString;

        public FalconKnightToolEntry(string title, Action<string> addCxString)
        {
            Title = title;
            PathConverter = new PathConverter();
            m_AddCxString = addCxString;
        }
    }
}
