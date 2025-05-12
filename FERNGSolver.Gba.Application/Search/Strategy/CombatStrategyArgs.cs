using FERNGSolver.Gba.Domain.Combat;

namespace FERNGSolver.Gba.Application.Search.Strategy
{
    /// <summary>
    /// CombatStrategyに必要な引数をまとめたクラスです。
    /// </summary>
    public sealed class CombatStrategyArgs
    {
        /// <summary>
        /// 攻撃側の情報を取得します。
        /// </summary>
        public ICombatUnit Attacker { get; set; }

        /// <summary>
        /// 防御側の情報を取得します。
        /// </summary>
        public ICombatUnit Defender { get; set; }

        /// <summary>
        /// 攻撃側のHP事後条件の最低値を取得します。
        /// </summary>
        public int AttackerHpPostconditionMin { get; set; }

        /// <summary>
        /// 攻撃側のHP事後条件の最大値を取得します。
        /// </summary>
        public int AttackerHpPostconditionMax { get; set; }

        /// <summary>
        /// 防御側のHP事後条件の最低値を取得します。
        /// </summary>
        public int DefenderHpPostconditionMin { get; set; }

        /// <summary>
        /// 防御側のHP事後条件の最大値を取得します。
        /// </summary>
        public int DefenderHpPostconditionMax { get; set; }
    }
}
