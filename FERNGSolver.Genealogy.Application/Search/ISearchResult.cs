namespace FERNGSolver.Genealogy.Application.Search
{
    public interface ISearchResult
    {
        /// <summary>
        /// 消費数の絶対位置を取得します。
        /// </summary>
        int Position { get; }
    }
}
