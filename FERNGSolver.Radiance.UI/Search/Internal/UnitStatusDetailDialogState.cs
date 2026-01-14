using FERNGSolver.Radiance.Domain.Combat;
using System.Text;

namespace FERNGSolver.Radiance.UI.Search.Internal
{
    internal sealed class UnitStatusDetailDialogState : IUnitStatusDetail
    {
        public Const.WeaponType WeaponType { get; set; } = Const.WeaponType.Normal;
        public Const.BossType BossType { get; set; } = Const.BossType.None;

        public bool HasVantage { get; set; } = false;
        public bool HasAdept { get; set; } = false;
        public bool HasWrath { get; set; } = false;
        public bool HasMiracle { get; set; } = false;
        public bool HasResolve { get; set; } = false;
        public bool HasCounter { get; set; } = false;
        public bool HasGuard { get; set; } = false;
        public bool HasCorrode { get; set; } = false;
        public bool HasAether { get; set; } = false;
        public bool HasAstra { get; set; } = false;
        public bool HasLuna { get; set; } = false;
        public bool HasSol { get; set; } = false;
        public bool HasFlare { get; set; } = false;
        public bool HasStun { get; set; } = false;
        public bool HasColossus { get; set; } = false;
        public bool HasDeadeye { get; set; } = false;
        public bool HasLethality { get; set; } = false;
        public bool HasCancel { get; set; } = false;

        public int WeaponUses { get; set; } = 20;
        public int Level { get; set; } = 10;
        public int MaxHp { get; set; } = 30;
        public int Str { get; set; } = 20;
        public int Tec { get; set; } = 10;
        public int Luck { get; set; } = 10;
        public int OpponentDefense { get; set; } = 10;

        public override string ToString()
        {
            var sb = new StringBuilder();

            switch (WeaponType)
            {
                case Const.WeaponType.Brave:
                    sb.Append("[勇者]");
                    break;
                case Const.WeaponType.MagicSword:
                    sb.Append("[剣間接]");
                    break;
                case Const.WeaponType.Absorb:
                    sb.Append($"[吸収(Max:{MaxHp})]");
                    break;
            }

            if (HasVantage)
            {
                sb.Append("[待ち伏せ]");
            }
            if (HasAdept)
            {
                sb.Append($"[連続({Tec}%)]");
            }
            if (HasWrath)
            {
                sb.Append("[怒り]");
            }
            if (HasResolve)
            {
                sb.Append("[勇将]");
            }
            if (HasMiracle)
            {
                sb.Append($"[祈り({Luck})%]");
            }
            if (HasCounter)
            {
                sb.Append($"[カウンター({(Tec/2)})%]");
            }
            if (HasAether)
            {
                sb.Append($"[天空({Tec}%)]");
            }
            if (HasAstra)
            {
                sb.Append($"[流星({(Tec/2)}%)]");
            }
            if (HasLuna)
            {
                sb.Append($"[月光({Tec}%)]");
            }
            if (HasSol)
            {
                sb.Append($"[太陽({Tec}%)]");
            }
            if (HasFlare)
            {
                sb.Append($"[陽光({Tec})%]");
            }
            if (HasStun)
            {
                sb.Append($"[衝撃({(Tec / 2)}%)]");
            }
            if (HasColossus)
            {
                sb.Append($"[鳴動({Tec})%]");
            }
            if (HasDeadeye)
            {
                sb.Append($"[狙撃({(Tec / 2)}%)]");
            }
            if (HasLethality)
            {
                sb.Append("[瞬殺]");
            }
            if (HasGuard)
            {
                sb.Append($"[キャンセル({Tec})%]");
            }
            if (HasCorrode)
            {
                sb.Append($"[武器破壊({Tec})%]");
            }
            if (HasCancel)
            {
                sb.Append($"[翼の守護({Tec})%]");
            }

            switch (BossType)
            {
                case Const.BossType.Boss:
                    sb.Append("[ボス]");
                    break;
                case Const.BossType.FinalBoss:
                    sb.Append("[ラスボス]");
                    break;
            }

            if (sb.Length > 0)
            {
                return sb.ToString();
            }
            return "設定なし";
        }
    }
}
