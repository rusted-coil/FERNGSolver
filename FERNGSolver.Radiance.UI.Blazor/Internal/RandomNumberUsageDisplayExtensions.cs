using FERNGSolver.Radiance.Application.RNG;

namespace FERNGSolver.Radiance.UI.Blazor.Internal
{
    /// <summary>
    /// 乱数ビューアで表示するための<see cref="RandomNumberUsage"/>の表示名を提供します。
    /// <para> * Windows版（FERNGSolver.Radiance.UI）の同名拡張メソッドを参考にしていますが、
    /// Blazor版はセル幅に余裕があるため、より説明的な表示名にしています。</para>
    /// </summary>
    internal static class RandomNumberUsageDisplayExtensions
    {
        public static string ToDisplayString(this RandomNumberUsage usage)
        {
            return usage switch
            {
                RandomNumberUsage.None => "",
                RandomNumberUsage.HpGrowth => "HP成長",
                RandomNumberUsage.StrGrowth => "力成長",
                RandomNumberUsage.MgcGrowth => "魔力成長",
                RandomNumberUsage.TecGrowth => "技成長",
                RandomNumberUsage.SpdGrowth => "速さ成長",
                RandomNumberUsage.LucGrowth => "幸運成長",
                RandomNumberUsage.DefGrowth => "守備成長",
                RandomNumberUsage.MdfGrowth => "魔防成長",
                RandomNumberUsage.PlayerHit1 => "攻撃側命中1",
                RandomNumberUsage.PlayerHit2 => "攻撃側命中2",
                RandomNumberUsage.PlayerCritical => "攻撃側必殺",
                RandomNumberUsage.PlayerAdept => "攻撃側連続",
                RandomNumberUsage.PlayerAether => "攻撃側天空",
                RandomNumberUsage.PlayerAstra => "攻撃側流星",
                RandomNumberUsage.PlayerLuna => "攻撃側月光",
                RandomNumberUsage.PlayerSol => "攻撃側太陽",
                RandomNumberUsage.PlayerFlare => "攻撃側陽光",
                RandomNumberUsage.PlayerLethality => "攻撃側瞬殺",
                RandomNumberUsage.PlayerCorrode => "攻撃側武器破壊",
                RandomNumberUsage.PlayerStun => "攻撃側衝撃",
                RandomNumberUsage.PlayerColossus => "攻撃側鳴動",
                RandomNumberUsage.PlayerCounter => "攻撃側カウンター",
                RandomNumberUsage.PlayerMiracle => "攻撃側祈り",
                RandomNumberUsage.PlayerGuard => "攻撃側キャンセル",
                RandomNumberUsage.PlayerDeadeye => "攻撃側狙撃",
                RandomNumberUsage.PlayerCancel => "攻撃側翼の守護",
                RandomNumberUsage.EnemyHit1 => "防御側命中1",
                RandomNumberUsage.EnemyHit2 => "防御側命中2",
                RandomNumberUsage.EnemyCritical => "防御側必殺",
                RandomNumberUsage.EnemyAdept => "防御側連続",
                RandomNumberUsage.EnemyAether => "防御側天空",
                RandomNumberUsage.EnemyAstra => "防御側流星",
                RandomNumberUsage.EnemyLuna => "防御側月光",
                RandomNumberUsage.EnemySol => "防御側太陽",
                RandomNumberUsage.EnemyFlare => "防御側陽光",
                RandomNumberUsage.EnemyLethality => "防御側瞬殺",
                RandomNumberUsage.EnemyCorrode => "防御側武器破壊",
                RandomNumberUsage.EnemyStun => "防御側衝撃",
                RandomNumberUsage.EnemyColossus => "防御側鳴動",
                RandomNumberUsage.EnemyCounter => "防御側カウンター",
                RandomNumberUsage.EnemyMiracle => "防御側祈り",
                RandomNumberUsage.EnemyGuard => "防御側キャンセル",
                RandomNumberUsage.EnemyDeadeye => "防御側狙撃",
                RandomNumberUsage.EnemyCancel => "防御側翼の守護",
                _ => "",
            };
        }
    }
}
