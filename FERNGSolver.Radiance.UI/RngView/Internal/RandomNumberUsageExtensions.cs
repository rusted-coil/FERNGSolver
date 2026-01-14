using FERNGSolver.Radiance.Application.RNG;

namespace FERNGSolver.Radiance.UI.RngView.Internal
{
    internal static class RandomNumberUsageExtensions
    {
        public static string ToDisplayString(this RandomNumberUsage usage)
        {
            return usage switch
            {
                RandomNumberUsage.None => "",
                RandomNumberUsage.HpGrowth => "HP",
                RandomNumberUsage.StrGrowth => "力",
                RandomNumberUsage.MgcGrowth => "魔",
                RandomNumberUsage.TecGrowth => "技",
                RandomNumberUsage.SpdGrowth => "速",
                RandomNumberUsage.LucGrowth => "運",
                RandomNumberUsage.DefGrowth => "守",
                RandomNumberUsage.MdfGrowth => "防",
                RandomNumberUsage.PlayerCritical => "必",
                RandomNumberUsage.PlayerAdept => "連",
                RandomNumberUsage.PlayerAether => "天",
                RandomNumberUsage.PlayerAstra => "流",
                RandomNumberUsage.PlayerLuna => "月",
                RandomNumberUsage.PlayerSol => "太",
                RandomNumberUsage.PlayerFlare => "陽",
                RandomNumberUsage.PlayerLethality => "瞬",
                RandomNumberUsage.PlayerCorrode => "武",
                RandomNumberUsage.PlayerStun => "衝",
                RandomNumberUsage.PlayerColossus => "鳴",
                RandomNumberUsage.PlayerCounter => "反",
                RandomNumberUsage.PlayerMiracle => "祈",
                RandomNumberUsage.PlayerGuard => "キ",
                RandomNumberUsage.PlayerDeadeye => "狙",
                RandomNumberUsage.PlayerCancel => "翼",
                RandomNumberUsage.EnemyCritical => "必",
                RandomNumberUsage.EnemyAdept => "連",
                RandomNumberUsage.EnemyAether => "天",
                RandomNumberUsage.EnemyAstra => "流",
                RandomNumberUsage.EnemyLuna => "月",
                RandomNumberUsage.EnemySol => "太",
                RandomNumberUsage.EnemyFlare => "陽",
                RandomNumberUsage.EnemyLethality => "瞬",
                RandomNumberUsage.EnemyCorrode => "武",
                RandomNumberUsage.EnemyStun => "衝",
                RandomNumberUsage.EnemyColossus => "鳴",
                RandomNumberUsage.EnemyCounter => "反",
                RandomNumberUsage.EnemyMiracle => "祈",
                RandomNumberUsage.EnemyGuard => "キ",
                RandomNumberUsage.EnemyDeadeye => "狙",
                RandomNumberUsage.EnemyCancel => "翼",
                _ => "",
            };
        }

        public static string ToSpecialDisplayString(this RandomNumberUsage usage)
        {
            return usage switch
            {
                RandomNumberUsage.PlayerHit1 => "命中",
                RandomNumberUsage.EnemyHit1 => "命中",
                _ => "",
            };
        }
    }
}
