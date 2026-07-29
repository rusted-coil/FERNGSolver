using FERNGSolver.Genealogy.Domain.Combat;

namespace FERNGSolver.Genealogy.UI.Blazor.Internal
{
    /// <summary>
    /// プロトタイプ用の、戦闘機能を使用しない場合のダミー実装です。
    /// </summary>
    internal sealed class EmptyUnitStatusDetail : IUnitStatusDetail
    {
        public Const.WeaponType WeaponType => Const.WeaponType.Normal;
        public bool HasVantage => false;
        public bool HasAstra => false;
        public bool HasLuna => false;
        public bool HasSol => false;
        public bool HasContinuation => false;
        public bool HasAssault => false;
        public bool HasGreatShield => false;
        public bool HasWrath => false;
        public bool HasPray => false;
        public int Level => 1;
        public int MaxHp => 1;
        public int Tec => 0;
        public int AttackSpeed => 0;
        public int OpponentAttackSpeed => 0;
        public int OpponentMdf => 0;
    }
}
