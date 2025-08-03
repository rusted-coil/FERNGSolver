using FERNGSolver.Genealogy.Application.RNG;

namespace FERNGSolver.Genealogy.UI.RngList.Internal
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
                RandomNumberUsage.PlayerAstra => "流",
                RandomNumberUsage.PlayerLuna => "月",
                RandomNumberUsage.PlayerSol => "太",
                RandomNumberUsage.PlayerContinuation => "連",
                RandomNumberUsage.PlayerGreatShield => "盾",
                RandomNumberUsage.EnemyHit => "命",
                RandomNumberUsage.EnemyCritical => "必",
                RandomNumberUsage.EnemyAstra => "流",
                RandomNumberUsage.EnemyLuna => "月",
                RandomNumberUsage.EnemySol => "太",
                RandomNumberUsage.EnemyContinuation => "連",
                RandomNumberUsage.EnemyGreatShield => "盾",
                _ => "",
            };
        }
    }
}
