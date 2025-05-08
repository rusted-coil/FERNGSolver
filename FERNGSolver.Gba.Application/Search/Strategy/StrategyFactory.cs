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
        /// 戦闘を判定するストラテジを作成します。
        /// </summary>
        public static ISearchStrategy CreateCombatStrategy(CombatStrategyArgs args)
        {
            return new Internal.CombatStrategy(args);
        }

        /// <summary>
        /// 成長を判定するストラテジを作成します。
        /// </summary>
        public static ISearchStrategy CreateGrowthStrategy(GrowthStrategyArgs args)
        {
            return new Internal.GrowthStrategy(args);
        }

        /// <summary>
        /// 複数のストラテジを順番に実行するストラテジを作成します。
        /// <para> * 全てが条件を満たす時のみcheckでtrueを返します。</para>
        /// </summary>
        public static ISearchStrategy CreateSequentialStrategy(params ISearchStrategy[] strategies)
        {
            return new Internal.SequentialStrategy(strategies);
        }
    }
}
