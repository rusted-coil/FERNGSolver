namespace FERNGSolver.Radiance.UI.Blazor.Internal
{
    /// <summary>
    /// <see cref="CombatConditionPanel"/> が編集する戦闘条件の入力値をまとめた状態です。
    /// </summary>
    public sealed class CombatConditionState
    {
        public int AttackerHp { get; set; } = 30;
        public int AttackerPower { get; set; } = 10;
        public int AttackerHitRate { get; set; } = 80;
        public int AttackerCriticalRate { get; set; } = 10;
        public bool AttackerFollowsUpAttack { get; set; }

        /// <summary>
        /// 攻撃側のキャラクター固有スキル等の詳細設定です。<see cref="UnitStatusDetailDialog"/>で編集します。
        /// </summary>
        public UnitStatusDetailState AttackerStatusDetail { get; set; } = new();

        public int DefenderHp { get; set; } = 30;
        public int DefenderPower { get; set; } = 10;
        public int DefenderHitRate { get; set; } = 80;
        public int DefenderCriticalRate { get; set; } = 10;
        public bool DefenderCountersAttack { get; set; }
        public bool DefenderFollowsUpAttack { get; set; }

        /// <summary>
        /// 防御側のキャラクター固有スキル等の詳細設定です。<see cref="UnitStatusDetailDialog"/>で編集します。
        /// </summary>
        public UnitStatusDetailState DefenderStatusDetail { get; set; } = new();

        public bool FiltersByAttackerHpPostcondition { get; set; }
        public int AttackerHpPostconditionMin { get; set; }
        public int AttackerHpPostconditionMax { get; set; } = 999;

        public bool FiltersByDefenderHpPostcondition { get; set; }
        public int DefenderHpPostconditionMin { get; set; }
        public int DefenderHpPostconditionMax { get; set; } = 999;

        /// <summary>
        /// 攻撃側の攻撃回数を取得します（追撃ありなら2回、なければ1回）。
        /// </summary>
        public int AttackerPhaseCount => AttackerFollowsUpAttack ? 2 : 1;

        /// <summary>
        /// 防御側の攻撃回数を取得します（反撃しないなら0回、反撃のみなら1回、追撃込みなら2回）。
        /// </summary>
        public int DefenderPhaseCount => DefenderCountersAttack ? (DefenderFollowsUpAttack ? 2 : 1) : 0;
    }
}
