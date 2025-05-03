using System.ComponentModel;

namespace FERNGSolver.Thracia.Presentation.FalconKnight.Internal
{
    internal class SearchResultItemViewModel
    {
        [DisplayName("乱数位置")]
        public string Offset { get; }

        public SearchResultItemViewModel(int tableIndex, int offset)
        {
            Offset = $"#{tableIndex:D2}-{offset}";
        }
    }
}
