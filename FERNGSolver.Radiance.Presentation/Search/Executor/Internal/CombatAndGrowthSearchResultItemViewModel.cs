using FERNGSolver.Radiance.Domain.Combat;
using System.Text;

namespace FERNGSolver.Radiance.Presentation.Search.Executor.Internal
{
    internal class CombatAndGrowthSearchResultItemViewModel : IRngStateResultViewModel
    {
        public string TableIndex { get; }
        public string Position { get; }
        public string Offset { get; }
        public string FalconKnightMethodConsume { get; }
        public string CombatResult { get; private set; } = string.Empty;
        public string GrowthResult { get; private set; } = string.Empty;

        public CombatAndGrowthSearchResultItemViewModel(
            int tableIndex, int position, int offset,
            int falconHorizontalCount, int falconHorizontalRemain,
            int falconVerticalCount, int falconVerticalRemain)
        {
            TableIndex = $"#{tableIndex}";
            Position = position.ToString();
            Offset = $"+{offset}";

            {
                var sb = new StringBuilder();

                bool h = false;
                if (falconHorizontalCount > 0 || falconHorizontalRemain > 0)
                {
                    sb.Append($"横{falconHorizontalCount}回");
                    if (falconHorizontalRemain > 0)
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
                        sb.Append($"+x{falconVerticalRemain}");
                    }
                }

                FalconKnightMethodConsume = sb.ToString();
            }
        }

        public void SetCombatResult(CombatSimulator.Result result)
        {
            CombatResult = $"自:HP{result.AttackerHp}、敵:HP{result.DefenderHp}";
        }

        public void SetGrowthResult(IReadOnlyList<int> growths)
        {
            string[] stats = ["HP", "力", "魔力", "技", "速さ", "幸運", "守備", "魔防"];

            var sb = new StringBuilder();
            bool b = false;
            for (int i = 0; i < growths.Count; ++i)
            {
                if (growths[i] > 0)
                {
                    if (b)
                    {
                        sb.Append("、");
                    }
                    sb.Append($"{stats[i]}+{growths[i]}");
                    b = true;
                }
            }
            if (!b)
            {
                sb.Append("-");
            }

            GrowthResult = sb.ToString();
        }
    }
}
