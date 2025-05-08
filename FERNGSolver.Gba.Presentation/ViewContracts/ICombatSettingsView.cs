namespace FERNGSolver.Gba.Presentation.ViewContracts
{
    public interface ICombatSettingsView
    {
        /// <summary>
        /// 戦闘を行うかどうかを取得します。
        /// </summary>
        bool ContainsCombat { get; }

        /// <summary>
        /// 攻撃側の命中率を取得します。
        /// </summary>
        int AttackerHitRate { get; }

        /// <summary>
        /// 攻撃側の必殺率を取得します。
        /// </summary>
        int AttackerCriticalRate { get; }

        /// <summary>
        /// 攻撃側の攻撃フェーズ回数を取得します。
        /// </summary>
        int AttackerPhaseCount { get; }

        /// <summary>
        /// 攻撃側が2回攻撃（勇者武器）を行うかどうかを取得します。
        /// </summary>
        bool IsAttackerDoubleAttack { get; }

        /// <summary>
        /// 反撃側の命中率を取得します。
        /// </summary>
        int DefenderHitRate { get; }

        /// <summary>
        /// 反撃側の必殺率を取得します。
        /// </summary>
        int DefenderCriticalRate { get; }

        /// <summary>
        /// 反撃側の攻撃フェーズ回数を取得します。
        /// </summary>
        int DefenderPhaseCount { get; }

        /// <summary>
        /// 反撃側が2回攻撃（勇者武器）を行うかどうかを取得します。
        /// </summary>
        bool IsDefenderDoubleAttack { get; }
    }
}
