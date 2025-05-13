namespace FERNGSolver.Thracia.Application.Search.Strategy
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
        /// 複数のストラテジを順番に実行するストラテジを作成します。
        /// <para> * 全てが条件を満たす時のみcheckでtrueを返します。</para>
        /// </summary>
        public static ISearchStrategy CreateSequentialStrategy(params ISearchStrategy[] strategies)
        {
            return new Internal.SequentialStrategy(strategies);
        }
    }
}
