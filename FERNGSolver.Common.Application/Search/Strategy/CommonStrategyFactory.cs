namespace FERNGSolver.Common.Application.Search.Strategy
{
    /// <summary>
    /// 各作品で共通して使用する想定のストラテジを作成するファクトリクラスです。
    /// </summary>
    public static class CommonStrategyFactory
    {
        /// <summary>
        /// ファルコンナイト法のパターンを判定するストラテジを作成します。
        /// </summary>
        /// <param name="falconKnightPattern">判定するファルコンナイト法パターンのリスト。○の場合true、×の場合falseをとる</param>
        /// <param name="isRngValueOk">乱数値を入力として受け取り、その乱数値が○か×かを判定する関数</param>
        /// <returns></returns>
        public static ISearchStrategy CreateFalconKnightPatternStrategy(IReadOnlyList<bool> falconKnightPattern, Func<ushort, bool> isRngValueOk)
        {
            return new Internal.FalconKnightPatternStrategy(falconKnightPattern, isRngValueOk);
        }

        /// <summary>
        /// 乱数列が特定の判定に成功するか失敗するかのパターンを判定するストラテジを作成します。
        /// </summary>
        /// <param name="highOrLowPattern">判定するパターンのリスト。第一引数に判定値を、第二引数に成功の場合はtrueを指定します。</param>
        /// <returns></returns>
        public static ISearchStrategy CreateHighOrLowPatternStrategy(IReadOnlyList<(ushort, bool)> highOrLowPattern)
        {
            return new Internal.HighOrLowPatternStrategy(highOrLowPattern);
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
