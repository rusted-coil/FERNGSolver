using FERNGSolver.Common.Application.Search.Strategy;

namespace FERNGSolver.Gba.Application.Search.Strategy
{
    public static class StrategyFactory
    {
        /// <summary>
        /// 戦闘を判定するストラテジを作成します。
        /// </summary>
        public static ISearchStrategy CreateCombatStrategy(CombatStrategyArgs args)
        {
            return new Internal.CombatStrategy(args);
        }

        /// <summary>
        /// 成長を判定するストラテジを作成します。
        /// <para> * 指定した成長率で、全ての能力が1以上上昇する場合にcheckでtrueを返します。</para>
        /// <para> * 判定を除外したいステータスがある場合は、成長率100を指定してください。</para>
        /// </summary>
        public static ISearchStrategy CreateGrowthStrategy(GrowthStrategyArgs args)
        {
            return new Internal.GrowthStrategy(args);
        }
    }
}
