using FERNGSolver.Gba.Domain.Combat;

namespace FERNGSolver.Gba.Application.Search.Strategy
{
    /// <summary>
    /// CombatStrategyに必要な引数をまとめたクラスです。
    /// </summary>
    public sealed class CombatStrategyArgs
    {
        /// <summary>
        /// 計算方式が封印の剣かどうかを取得します。
        /// </summary>
        public required bool IsBindingBlade { get; init; }

        /// <summary>
        /// 攻撃側の情報を取得します。
        /// </summary>
        public required ICombatUnit Attacker { get; init; }

        /// <summary>
        /// 防御側の情報を取得します。
        /// </summary>
        public required ICombatUnit Defender { get; init; }

        /// <summary>
        /// 攻撃側のHP事後条件の最低値を取得します。
        /// </summary>
        public int AttackerHpPostconditionMin { get; init; }

        /// <summary>
        /// 攻撃側のHP事後条件の最大値を取得します。
        /// </summary>
        public int AttackerHpPostconditionMax { get; init; }

        /// <summary>
        /// 防御側のHP事後条件の最低値を取得します。
        /// </summary>
        public int DefenderHpPostconditionMin { get; init; }

        /// <summary>
        /// 防御側のHP事後条件の最大値を取得します。
        /// </summary>
        public int DefenderHpPostconditionMax { get; init; }
    }
}
