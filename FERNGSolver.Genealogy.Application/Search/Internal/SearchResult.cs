namespace FERNGSolver.Genealogy.Application.Search.Internal
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
