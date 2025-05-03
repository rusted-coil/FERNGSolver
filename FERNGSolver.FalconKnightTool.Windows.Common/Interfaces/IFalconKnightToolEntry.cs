using FERNGSolver.FalconKnightTool.Common.Interfaces;

namespace FERNGSolver.FalconKnightTool.Windows.Common.Interfaces
{
    /// <summary>
    /// ファルコンナイト法ツールに渡す、1タイトルごとの依存物をまとめたエントリーのインターフェースです。
    /// </summary>
    public interface IFalconKnightToolEntry : IFalconKnightToolEntryCore
    {
        /// <summary>
        /// 検索条件を設定するパネルのユーザーコントロールを取得します。
        /// </summary>
        UserControl SearchConditionControl { get; }
    }
}
