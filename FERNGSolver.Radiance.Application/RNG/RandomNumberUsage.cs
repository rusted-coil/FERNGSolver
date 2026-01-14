using FERNGSolver.Radiance.Domain.Combat.Service;

namespace FERNGSolver.Radiance.Application.RNG
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

        PlayerHit1, // 実効命中率その1
        PlayerHit2, // 実効命中率その2
        PlayerCritical, // 必殺
        PlayerAdept, // 連続判定
        PlayerAether, // 天空判定
        PlayerAstra, // 流星判定
        PlayerLuna, // 月光判定
        PlayerSol, // 太陽判定
        PlayerFlare, // 陽光判定
        PlayerLethality, // 瞬殺判定
        PlayerCorrode, // 武器破壊判定
        PlayerStun, // 衝撃判定
        PlayerColossus, // 鳴動判定
        PlayerCounter, // カウンター判定
        PlayerMiracle, // 祈り判定
        PlayerGuard, // キャンセル判定
        PlayerDeadeye, // 狙撃判定
        PlayerCancel, // 翼の守護判定

        PlayerStart = PlayerHit1,
        PlayerEnd = PlayerCancel,

        EnemyHit1, // 実効命中率その1
        EnemyHit2, // 実効命中率その2
        EnemyCritical, // 必殺
        EnemyAdept, // 連続判定
        EnemyAether, // 天空判定
        EnemyAstra, // 流星判定
        EnemyLuna, // 月光判定
        EnemySol, // 太陽判定
        EnemyFlare, // 陽光判定
        EnemyLethality, // 瞬殺判定
        EnemyCorrode, // 武器破壊判定
        EnemyStun, // 衝撃判定
        EnemyColossus, // 鳴動判定
        EnemyCounter, // カウンター判定
        EnemyMiracle, // 祈り判定
        EnemyGuard, // キャンセル判定
        EnemyDeadeye, // 狙撃判定
        EnemyCancel, // 翼の守護判定

        EnemyStart = EnemyHit1,
        EnemyEnd = EnemyCancel,
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
