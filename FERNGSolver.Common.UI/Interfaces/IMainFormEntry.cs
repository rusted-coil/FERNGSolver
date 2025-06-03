namespace FERNGSolver.Common.UI.Interfaces
{
    /// <summary>
    /// メインフォームに渡す、1タイトルごとの依存物をまとめたエントリーのインターフェースです。
    /// </summary>
    public interface IMainFormEntry
    {
        /// <summary>
        /// タイトルを取得します。
        /// <para> * IDとしても使用するため、複数追加する場合は一意である必要があります。</para>
        /// </summary>
        string Title { get; }

        /// <summary>
        /// 検索条件を設定するパネルのユーザーコントロールを取得します。
        /// </summary>
        UserControl MainFormControl { get; }
    }
}
