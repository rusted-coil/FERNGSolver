using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Thracia.Domain.RNG
{
    public static class RngFactory
    {
        /// <summary>
        /// トラキア776のRNGを作成します。
        /// </summary>
        public static ICloneableRng Create(int tableIndex)
        {
            return new Internal.Rng(Const.InitialTables[tableIndex]);
        }
    }
}
