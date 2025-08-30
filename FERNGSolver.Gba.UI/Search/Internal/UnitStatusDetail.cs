using FERNGSolver.Gba.Domain.Combat;
using System.Text;

namespace FERNGSolver.Gba.UI.Search.Internal
{
    internal sealed class UnitStatusDetail : IUnitStatusDetail
    {
        public Const.WeaponType WeaponType { get; set; } = Const.WeaponType.Normal;
        public Const.SkillType SkillType { get; set; } = Const.SkillType.None;
        public Const.BossType BossType { get; set; } = Const.BossType.None;
        public int Level { get; set; } = 10;
        public int MaxHp { get; set; } = 30;
        public int Luck { get; set; } = 10;
        public int OpponentDefense { get; set; } = 10;

        public override string ToString()
        {
            if (WeaponType != Const.WeaponType.Normal || SkillType != Const.SkillType.None || BossType != Const.BossType.None)
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

                switch (SkillType)
                {
                    case Const.SkillType.SureStrike:
                        sb.Append($"[必的({Level}%)]");
                        break;
                    case Const.SkillType.Pierce:
                        sb.Append($"[貫通({Level}%、敵の守備:{OpponentDefense})]");
                        break;
                    case Const.SkillType.GreatShield:
                        sb.Append($"[大盾({Level}%)]");
                        break;
                    case Const.SkillType.Silencer:
                        sb.Append($"[瞬殺]");
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
