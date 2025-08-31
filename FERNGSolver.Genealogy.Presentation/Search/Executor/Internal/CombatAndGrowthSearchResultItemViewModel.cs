using FERNGSolver.Genealogy.Domain.Combat;
using System.Text;

namespace FERNGSolver.Genealogy.Presentation.Search.Executor.Internal
{
    internal class CombatAndGrowthSearchResultItemViewModel : IRngStateResultViewModel
    {
        public string Position { get; }
        public string Offset { get; }
        public string CombatResult { get; private set; } = string.Empty;
        public string GrowthResult { get; private set; } = string.Empty;
        public string AfterPosition { get; private set; } = string.Empty;

        public CombatAndGrowthSearchResultItemViewModel(int position, int offset)
        {
            Position = position.ToString();
            Offset = $"+{offset}";
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

        public void SetAfterPosition(int afterPosition)
        {
            AfterPosition = afterPosition.ToString();
        }
    }
}
