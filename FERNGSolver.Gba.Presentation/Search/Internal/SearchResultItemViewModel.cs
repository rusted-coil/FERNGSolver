using System.ComponentModel;

namespace FERNGSolver.Gba.Presentation.Search.Internal
{
    internal class SearchResultItemViewModel
    {
        [DisplayName("消費数")]
        public string Offset { get; }

        public SearchResultItemViewModel(int offset)
        {
            Offset = $"{offset}";
        }
    }
}
