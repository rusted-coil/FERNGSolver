namespace FERNGSolver.Gba.Application.Search.Strategy
{
    public static class StrategyFactory
    {
        /// <summary>
        /// ファルコンナイト法のパターンを判定するストラテジを作成します。
        /// </summary>
        public static ISearchStrategy CreateFalconKnightPatternStrategy(IReadOnlyList<bool> falconKnightPattern)
        {
            return new Internal.FalconKnightPatternStrategy(falconKnightPattern);
        }

        /// <summary>
        /// 戦闘とレベルアップを判定するストラテジを作成します。
        /// </summary>
        public static ISearchStrategy CreateCombatAndGrowthStrategy()
        {
            return new Internal.CombatAndGrowthStrategy();
        }
    }
}
