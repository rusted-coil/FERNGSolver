namespace FERNGSolver.FalconKnightTool.Common.Interfaces
{
    /// <summary>
    /// ファルコンナイト法ツールに渡す、1タイトルごとの依存物をまとめたエントリーのWindows非依存部分のインターフェースです。
    /// </summary>
    public interface IFalconKnightToolEntryCore
    {
        /// <summary>
        /// タイトルを取得します。
        /// <para> * IDとしても使用するため、複数追加する場合は一意である必要があります。</para>
        /// </summary>
        string Title { get; }

        /// <summary>
        /// 検索処理を行うストラテジを取得します。
        /// </summary>
        IFalconKnightToolSearchStrategy SearchStrategy { get; }
    }
}
