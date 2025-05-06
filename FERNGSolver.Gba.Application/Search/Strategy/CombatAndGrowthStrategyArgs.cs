namespace FERNGSolver.Gba.Application.Search.Strategy
{
    /// <summary>
    /// CombatAndGrowthStrategyに必要な引数をまとめたクラスです。
    /// </summary>
    public sealed class CombatAndGrowthStrategyArgs
    {
        /// <summary>
        /// 戦闘を行うかどうかを取得します。
        /// </summary>
        public bool ContainsCombat { get; set; }

        /// <summary>
        /// レベルアップするかどうかを取得します。
        /// </summary>
        public bool ContainsGrowth { get; set; }
    }
}
