namespace FERNGSolver.Common.Presentation.Search
{
    public static class SearchResultDisplay
    {
        public const int MaxRows = 100;

        public static string GetSummary(int displayedCount, int totalCount)
        {
            return totalCount > displayedCount
                ? $"検索結果: {totalCount:N0} 件（先頭 {displayedCount:N0} 件を表示。検索範囲を絞ると残りの候補を確認できます）"
                : $"検索結果: {totalCount:N0} 件";
        }
    }
}
