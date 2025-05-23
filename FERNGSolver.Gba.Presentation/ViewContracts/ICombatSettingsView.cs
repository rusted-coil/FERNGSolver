using FERNGSolver.Gba.Domain.Combat;

namespace FERNGSolver.Gba.Presentation.ViewContracts
{
    public interface ICombatSettingsView
    {
        /// <summary>
        /// 戦闘を行うかどうかを取得します。
        /// </summary>
        bool ContainsCombat { get; }

        /// <summary>
        /// 計算方式が封印の剣かどうかを取得します。
        /// </summary>
        bool IsBindingBlade { get; }

        /// <summary>
        /// 攻撃側のHPを取得します。
        /// </summary>
        int AttackerHp { get; }

        /// <summary>
        /// 攻撃側の威力を取得します。
        /// </summary>
        int AttackerPower { get; }

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
        /// 攻撃側の詳細設定を取得します。
        /// </summary>
        IUnitStatusDetail AttackerStatusDetail { get; }

        /// <summary>
        /// 防御側のHPを取得します。
        /// </summary>
        int DefenderHp { get; }

        /// <summary>
        /// 防御側の威力を取得します。
        /// </summary>
        int DefenderPower { get; }

        /// <summary>
        /// 防御側の命中率を取得します。
        /// </summary>
        int DefenderHitRate { get; }

        /// <summary>
        /// 防御側の必殺率を取得します。
        /// </summary>
        int DefenderCriticalRate { get; }

        /// <summary>
        /// 防御側の攻撃フェーズ回数を取得します。
        /// </summary>
        int DefenderPhaseCount { get; }

        /// <summary>
        /// 防御側の詳細設定を取得します。
        /// </summary>
        IUnitStatusDetail DefenderStatusDetail { get; }

        /// <summary>
        /// 攻撃側のHP事後条件の最低値を取得します。
        /// </summary>
        int AttackerHpPostconditionMin { get; }

        /// <summary>
        /// 攻撃側のHP事後条件の最高値を取得します。
        /// </summary>
        int AttackerHpPostconditionMax { get; }

        /// <summary>
        /// 防御側のHP事後条件の最低値を取得します。
        /// </summary>
        int DefenderHpPostconditionMin { get; }

        /// <summary>
        /// 防御側のHP事後条件の最高値を取得します。
        /// </summary>
        int DefenderHpPostconditionMax { get; }
    }
}
