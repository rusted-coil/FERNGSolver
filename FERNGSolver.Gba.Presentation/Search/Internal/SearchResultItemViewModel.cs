using System.ComponentModel;
using System.Text;

namespace FERNGSolver.Gba.Presentation.Search.Internal
{
    internal class SearchResultItemViewModel
    {
        [DisplayName("消費数")]
        public string Position { get; }

        [DisplayName("Offset")]
        public string Offset { get; }

        [DisplayName("F法消費回数")]
        public string FalconKnightMethodConsume { get; }

        public SearchResultItemViewModel(
            int position, int offset,
            int falconHorizontalCount, int falconHorizontalRemain,
            int falconVerticalCount, int falconVerticalRemain)
        {
            Position = position.ToString();
            Offset = $"+{offset}";

            {
                var sb = new StringBuilder();

                bool h = false;
                if (falconHorizontalCount > 0 || falconHorizontalRemain > 0)
                {
                    sb.Append($"横{falconHorizontalCount}回");
                    if(falconHorizontalRemain > 0)
                    {
                        sb.Append($"+c{falconHorizontalRemain}");
                    }
                    h = true;
                }


                if (falconVerticalCount > 0 || falconVerticalRemain > 0)
                {
                    if (h)
                    {
                        sb.AppendLine("、");
                    }
                    sb.Append($"縦{falconVerticalCount}回");
                    if (falconVerticalRemain > 0)
                    {
                        sb.Append($"+{falconVerticalRemain}");
                    }
                }

                FalconKnightMethodConsume = sb.ToString();
            }
        }
    }
}
