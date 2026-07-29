using FERNGSolver.Gba.Domain.Combat;

namespace FERNGSolver.Gba.UI.Blazor.Internal
{
    /// <summary>
    /// プロトタイプ用の、戦闘機能を使用しない場合のダミー実装です。
    /// </summary>
    internal sealed class EmptyUnitStatusDetail : IUnitStatusDetail
    {
        public Const.WeaponType WeaponType => Const.WeaponType.Normal;
        public Const.SkillType SkillType => Const.SkillType.None;
        public Const.BossType BossType => Const.BossType.None;
        public int Level => 1;
        public int MaxHp => 1;
        public int Luck => 0;
        public int OpponentDefense => 0;
    }
}
