namespace FERNGSolver.Gba.Application.Search.Strategy
{
    /// <summary>
    /// レベルアップ時の能力ごとの検索タイプを定義するenumです。
    /// </summary>
    public enum GrowthSearchType
    {
        NotConsidered, // どちらでもいい
        MustUp, // 上がらないとだめ
        MustNotUp, // 上がっちゃだめ
        Max, // 既に限界
    }

    /// <summary>
    /// GrowthStrategyに必要な引数をまとめたクラスです。
    /// </summary>
    public sealed class GrowthStrategyArgs
    {
        // それぞれの実際の成長率を指定します。
        public int HpGrowthRate { get; set; }
        public int AtkGrowthRate { get; set; }
        public int TecGrowthRate { get; set; }
        public int SpdGrowthRate { get; set; }
        public int DefGrowthRate { get; set; }
        public int MdfGrowthRate { get; set; }
        public int LucGrowthRate { get; set; }
        // それぞれの能力値の検索タイプを指定します。
        public GrowthSearchType HpSearchType { get; set; }
        public GrowthSearchType AtkSearchType { get; set; }
        public GrowthSearchType TecSearchType { get; set; }
        public GrowthSearchType SpdSearchType { get; set; }
        public GrowthSearchType DefSearchType { get; set; }
        public GrowthSearchType MdfSearchType { get; set; }
        public GrowthSearchType LucSearchType { get; set; }
    }
}
