namespace FERNGSolver.Gba.Application.Search.Strategy
{
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
    }
}
