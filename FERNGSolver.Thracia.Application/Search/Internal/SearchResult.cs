namespace FERNGSolver.Thracia.Application.Search.Internal
{
    internal sealed class SearchResult : ISearchResult
    {
        public int TableIndex { get; }
        public int Position { get; }

        public SearchResult(int tableIndex, int position)
        {
            TableIndex = tableIndex;
            Position = position;
        }
    }
}
