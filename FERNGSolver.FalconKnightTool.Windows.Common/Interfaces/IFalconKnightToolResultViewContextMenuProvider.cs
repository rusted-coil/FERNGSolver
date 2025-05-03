namespace FERNGSolver.FalconKnightTool.Windows.Common.Interfaces
{
    /// <summary>
    /// ファルコンナイト法ツールで結果の行を右クリックした時にコンテキストメニューを生成するインターフェースです。
    /// </summary>
    public interface IFalconKnightToolResultViewContextMenuProvider
    {
        /// <summary>
        /// 指定した行を右クリックした時のコンテキストメニューを生成します。
        /// </summary>
        ContextMenuStrip CreateContextMenu(int rowIndex);
    }
}
