using FERNGSolver.Radiance.Domain.Combat;
using System.Text;

namespace FERNGSolver.Radiance.UI.Search.Internal
{
    internal sealed class UnitStatusDetail : IUnitStatusDetail
    {
        public Const.WeaponType WeaponType { get; set; } = Const.WeaponType.Normal;
        public Const.BossType BossType { get; set; } = Const.BossType.None;
        public int Level { get; set; } = 10;
        public int MaxHp { get; set; } = 30;
        public int Luck { get; set; } = 10;
        public int OpponentDefense { get; set; } = 10;

        public bool HasVantage => throw new NotImplementedException();

        public bool HasAdept => throw new NotImplementedException();

        public bool HasWrath => throw new NotImplementedException();

        public bool HasMiracle => throw new NotImplementedException();

        public bool HasResolve => throw new NotImplementedException();

        public bool HasCounter => throw new NotImplementedException();

        public bool HasGuard => throw new NotImplementedException();

        public bool HasCorrode => throw new NotImplementedException();

        public bool HasAether => throw new NotImplementedException();

        public bool HasAstra => throw new NotImplementedException();

        public bool HasLuna => throw new NotImplementedException();

        public bool HasSol => throw new NotImplementedException();

        public bool HasFlare => throw new NotImplementedException();

        public bool HasStun => throw new NotImplementedException();

        public bool HasColossus => throw new NotImplementedException();

        public bool HasDeadeye => throw new NotImplementedException();

        public bool HasLethality => throw new NotImplementedException();

        public bool HasCancel => throw new NotImplementedException();

        public override string ToString()
        {
            if (WeaponType != Const.WeaponType.Normal || BossType != Const.BossType.None)
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
                    case Const.WeaponType.Poison:
                        sb.Append("[状態異常]");
                        break;
                    case Const.WeaponType.Cursed:
                        sb.Append($"[呪い({Util.GetCurseRate(Luck)}%)]");
                        break;
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

                return sb.ToString();
            }
            return "設定なし";
        }
    }
}
