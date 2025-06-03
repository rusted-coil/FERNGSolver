using FERNGSolver.Common.Presentation.Interfaces;

namespace FERNGSolver.Gba.Presentation.Search.Internal
{
    internal sealed class SearchResultTableColumn : ITableColumn
    {
        public string HeaderText { get; }
        public string PropertyName { get; }
        public int Width { get; set; } = 100;

        public SearchResultTableColumn(string headerText, string propertyName)
        {
            HeaderText = headerText;
            PropertyName = propertyName;
        }
    }
}
