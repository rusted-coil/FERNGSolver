namespace FERNGSolver.Genealogy.Application.RNG
{
    /// <summary>
    /// 乱数値が何に使われたかを示す列挙型です。
    /// </summary>
    public enum RandomNumberUsage
    {
        None = 0, // 使用されていない

        HpGrowth, // HP成長
        StrGrowth, // 力成長
        MgcGrowth, // 魔力成長
        TecGrowth, // 技成長
        SpdGrowth, // 速さ成長
        LucGrowth, // 幸運成長
        DefGrowth, // 守備成長
        MdfGrowth, // 魔防成長

        GrowthStart = HpGrowth,
        GrowthEnd = MdfGrowth,
    }
}
