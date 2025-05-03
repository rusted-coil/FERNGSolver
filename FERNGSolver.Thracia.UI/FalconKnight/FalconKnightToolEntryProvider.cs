using FERNGSolver.FalconKnightTool.Windows.Common;
using FERNGSolver.FalconKnightTool.Windows.Common.Interfaces;
using FERNGSolver.Thracia.Presentation.FalconKnight;

namespace FERNGSolver.Thracia.UI.FalconKnight
{
    public static class FalconKnightToolEntryProvider
    {
        public static IFalconKnightToolEntry Create()
        {
            var searchConditionControl = new Internal.SearchConditionUserControl();
            searchConditionControl.InitializeDefaults();

            return new FalconKnightToolEntry(
                "トラキア",
                searchConditionControl,
                SearchStrategyFactory.Create(searchConditionControl),
                new Internal.ResultViewContextMenuProvider());
        }
    }
}
