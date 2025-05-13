namespace FERNGSolver.Thracia.Application.Search
{
    public interface ISearchResult
    {
        /// <summary>
        /// テーブルの番号を取得します。
        /// </summary>
        int TableIndex { get; }

        /// <summary>
        /// 消費数の絶対位置を取得します。
        /// </summary>
        int Position { get; }
    }
}
