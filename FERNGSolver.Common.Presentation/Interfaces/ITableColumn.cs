namespace FERNGSolver.Common.Presentation.Interfaces
{
    /// <summary>
    /// テーブル表示の列情報の共通インターフェースです。
    /// </summary>
    public interface ITableColumn
    {
        /// <summary>
        /// 列のタイトルを取得します。
        /// </summary>
        string HeaderText { get; }

        /// <summary>
        /// データのプロパティ名を取得します。
        /// </summary>
        string PropertyName { get; }

        /// <summary>
        /// 列の幅を取得します。
        /// </summary>
        int Width { get; }
    }
}
