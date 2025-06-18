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
                _ => "",
            };
        }
    }
}
