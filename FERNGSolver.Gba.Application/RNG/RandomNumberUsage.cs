using FERNGSolver.Gba.Domain.Combat.Service;

namespace FERNGSolver.Gba.Application.RNG
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

        PlayerHit, // 命中
        PlayerCritical, // 必殺
        PlayerAstra, // 流星剣判定
        PlayerLuna, // 月光剣判定
        PlayerSol, // 太陽剣判定
        PlayerContinuation, // 連続判定
        PlayerGreatShield, // 大盾判定

        PlayerStart = PlayerHit,
        PlayerEnd = PlayerGreatShield,

        EnemyHit, // 命中
        EnemyCritical, // 必殺
        EnemyAstra, // 流星剣判定
        EnemyLuna, // 月光剣判定
        EnemySol, // 太陽剣判定
        EnemyContinuation, // 連続判定
        EnemyGreatShield, // 大盾判定

        EnemyStart = EnemyHit,
        EnemyEnd = EnemyGreatShield,
    }

    public static class RandomNumberUsageExtensions
    {
        /// <summary>
        /// 乱数値が成長に使用されたかどうかを判定します。
        /// </summary>
        public static bool IsGrowth(this RandomNumberUsage usage) => usage >= RandomNumberUsage.GrowthStart && usage <= RandomNumberUsage.GrowthEnd;

        /// <summary>
        /// 乱数値の使用された陣営を取得します。
        /// </summary>
        public static UnitSide GetUnitSide(this RandomNumberUsage usage)
        {
            if (usage >= RandomNumberUsage.PlayerStart && usage <= RandomNumberUsage.PlayerEnd)
            {
                return UnitSide.Player;
            }
            if (usage >= RandomNumberUsage.EnemyStart && usage <= RandomNumberUsage.EnemyEnd)
            {
                return UnitSide.Enemy;
            }
            throw new ArgumentOutOfRangeException(nameof(usage), usage, "Invalid RandomNumberUsage value for unit side determination.");
        }
    }
}
