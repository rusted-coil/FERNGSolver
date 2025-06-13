using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Genealogy.Domain.RNG
{
    public static class RngFactory
    {
        /// <summary>
        /// 聖戦の系譜のRNGを作成します。
        /// </summary>
        public static ICloneableRng Create()
        {
            return new Internal.Rng(Const.InitialTable);
        }
    }
}
