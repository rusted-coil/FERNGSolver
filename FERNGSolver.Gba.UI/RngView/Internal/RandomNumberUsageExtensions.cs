using FERNGSolver.Gba.Application.RNG;

namespace FERNGSolver.Gba.UI.RngView.Internal
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
                RandomNumberUsage.PlayerHit => "命",
                RandomNumberUsage.PlayerCritical => "必",
                RandomNumberUsage.PlayerSureStrike => "的",
                RandomNumberUsage.PlayerPierce => "貫",
                RandomNumberUsage.PlayerGreatShield => "盾",
                RandomNumberUsage.PlayerSilencer => "瞬",
                RandomNumberUsage.PlayerCurse => "呪",
                RandomNumberUsage.EnemyHit => "命",
                RandomNumberUsage.EnemyCritical => "必",
                RandomNumberUsage.EnemySureStrike => "的",
                RandomNumberUsage.EnemyPierce => "貫",
                RandomNumberUsage.EnemyGreatShield => "盾",
                RandomNumberUsage.EnemySilencer => "瞬",
                RandomNumberUsage.EnemyCurse => "呪",
                _ => "",
            };
        }
    }
}
