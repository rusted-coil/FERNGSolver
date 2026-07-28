using FERNGSolver.Radiance.Domain.Combat;

namespace FERNGSolver.Radiance.UI.Blazor.Internal
{
    /// <summary>
    /// プロトタイプ用の、戦闘機能を使用しない場合のダミー実装です。
    /// </summary>
    internal sealed class EmptyUnitStatusDetail : IUnitStatusDetail
    {
        public Const.WeaponType WeaponType => Const.WeaponType.Normal;
        public Const.BossType BossType => Const.BossType.None;
        public bool HasVantage => false;
        public bool HasAdept => false;
        public bool HasWrath => false;
        public bool HasMiracle => false;
        public bool HasResolve => false;
        public bool HasCounter => false;
        public bool HasGuard => false;
        public bool HasCorrode => false;
        public bool HasAether => false;
        public bool HasAstra => false;
        public bool HasLuna => false;
        public bool HasSol => false;
        public bool HasFlare => false;
        public bool HasStun => false;
        public bool HasColossus => false;
        public bool HasDeadeye => false;
        public bool HasLethality => false;
        public bool HasCancel => false;
        public int WeaponUses => 0;
        public int Level => 1;
        public int MaxHp => 1;
        public int Str => 0;
        public int Tec => 0;
        public int Luck => 0;
        public int OpponentDefense => 0;
    }
}
