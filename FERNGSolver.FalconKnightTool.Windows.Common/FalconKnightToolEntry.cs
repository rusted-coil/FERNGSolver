using FERNGSolver.FalconKnightTool.Common.Interfaces;
using FERNGSolver.FalconKnightTool.Windows.Common.Interfaces;

namespace FERNGSolver.FalconKnightTool.Windows.Common
{
    public sealed class FalconKnightToolEntry : IFalconKnightToolEntry
    {
        public string Title { get; }
        public UserControl SearchConditionControl { get; }
        public IFalconKnightToolSearchStrategy SearchStrategy { get; }

        public FalconKnightToolEntry(string title, UserControl searchConditionControl, IFalconKnightToolSearchStrategy searchStrategy)
        {
            Title = title;
            SearchConditionControl = searchConditionControl;
            SearchStrategy = searchStrategy;
        }
    }
}
