using FERNGSolver.FalconKnightTool.Windows.Common.Interfaces;

namespace FERNGSolver.Gba.UI.FalconKnight.Internal
{
    internal sealed class ResultViewContextMenuProvider : IFalconKnightToolResultViewContextMenuProvider
    {
        public ContextMenuStrip CreateContextMenu(int rowIndex)
        {
            var contextMenu = new ContextMenuStrip();

            contextMenu.Items.Add(new ToolStripMenuItem("消費前の消費数を反映", null, (s, e) => ReflectPreConsumptionCount(rowIndex)));
            contextMenu.Items.Add(new ToolStripMenuItem("消費後の消費数を反映", null, (s, e) => ReflectPostConsumptionCount(rowIndex)));
            contextMenu.Items.Add(new ToolStripMenuItem("消費前のSeedを反映", null, (s, e) => ReflectPreSeed(rowIndex)));
            contextMenu.Items.Add(new ToolStripMenuItem("消費後のSeedを反映", null, (s, e) => ReflectPostSeed(rowIndex)));

            return contextMenu;
        }

        private void ReflectPreConsumptionCount(int rowIndex)
        {
            // 消費前の消費数を反映するロジック
        }

        private void ReflectPostConsumptionCount(int rowIndex)
        {
            // 消費後の消費数を反映するロジック
        }

        private void ReflectPreSeed(int rowIndex)
        {
            // 消費前のSeedを反映するロジック
        }

        private void ReflectPostSeed(int rowIndex)
        {
            // 消費後のSeedを反映するロジック
        }
    }
}
