using FERNGSolver.Genealogy.Domain.Combat;
using System.Text;

namespace FERNGSolver.Genealogy.UI.Search.Internal
{
    internal sealed class UnitStatusDetailDialogState : IUnitStatusDetail
    {
        public Const.WeaponType WeaponType { get; set; } = Const.WeaponType.Normal;
        public int Level { get; set; } = 10;
        public int MaxHp { get; set; } = 30;
        public int Tec { get; set; } = 10;
        public int AttackSpeed { get; set; } = 10;
        public int OpponentAttackSpeed { get; set; } = 10;
        public int OpponentMdf { get; set; } = 5;

        public bool HasVantage { get; set; } = false;
        public bool HasAstra { get; set; } = false;
        public bool HasLuna { get; set; } = false;
        public bool HasSol { get; set; } = false;
        public bool HasContinuation { get; set; } = false;
        public bool HasAssault { get; set; } = false;
        public bool HasGreatShield { get; set; } = false;
        public bool HasWrath { get; set; } = false;
        public bool HasPray { get; set; } = false;

        // 必殺関連
        public bool HasCriticalSkill { get; set; } = false;
        public bool HasSupport { get; set; } = false;
        public bool IsEffective { get; set; } = false;
        public int WeaponStarCount { get; set; } = 50;

        public override string ToString()
        {
            var sb = new StringBuilder();

            switch (WeaponType)
            {
                case Const.WeaponType.Brave:
                    sb.Append("[勇者]");
                    break;
                case Const.WeaponType.Absorb:
                    sb.Append($"[吸収(Max:{MaxHp})]");
                    break;
                case Const.WeaponType.Sleep:
                    sb.Append("[状態異常]");
                    break;
            }

            if (HasVantage)
            {
                sb.Append("[待ち伏せ]");
            }
            if (HasAstra)
            {
                sb.Append($"[流星剣({Tec}%)]");
            }
            if (HasLuna)
            {
                sb.Append($"[月光剣({Tec}%)]");
            }
            if (HasSol)
            {
                sb.Append($"[太陽剣({Tec}%)]");
            }
            if (HasContinuation)
            {
                sb.Append($"[連続({AttackSpeed+20}%)]");
            }
            if (HasAssault)
            {
                sb.Append($"[突撃({AttackSpeed - OpponentAttackSpeed}+残HP/2%)]");
            }
            if (HasGreatShield)
            {
                sb.Append($"[大盾({Level}%)]");
            }
            if (HasWrath)
            {
                sb.Append($"[怒り]");
            }
            if (HasPray)
            {
                sb.Append($"[祈り]");
            }

            int criticalRate = Util.GetCriticalRate(Tec, HasCriticalSkill, HasSupport, IsEffective, WeaponStarCount);
            if (criticalRate > 0)
            {
                sb.Append($"[必殺({criticalRate}%)]");
            }

            if (sb.Length > 0)
            {
                return sb.ToString();
            }
            return "設定なし";
        }
    }
}
