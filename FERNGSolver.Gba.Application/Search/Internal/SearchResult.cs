namespace FERNGSolver.Gba.Application.Search.Internal
{
    internal sealed class SearchResult : ISearchResult
    {
        public int Position { get; }

        public SearchResult(int position)
        {
            Position = position;
        }
    }
}
