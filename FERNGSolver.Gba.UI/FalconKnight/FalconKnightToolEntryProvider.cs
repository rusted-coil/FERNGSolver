using FERNGSolver.FalconKnightTool.Windows.Common;
using FERNGSolver.FalconKnightTool.Windows.Common.Interfaces;
using FERNGSolver.Gba.Presentation.FalconKnight;

namespace FERNGSolver.Gba.UI.FalconKnight
{
    public static class FalconKnightToolEntryProvider
    {
        public static IFalconKnightToolEntry Create()
        {
            var searchConditionControl = new Internal.SearchConditionUserControl();
            searchConditionControl.InitializeDefaults();

            return new FalconKnightToolEntry(
                "GBA",
                searchConditionControl,
                SearchStrategyFactory.Create(searchConditionControl),
                new Internal.ResultViewContextMenuProvider());
        }
    }
}
