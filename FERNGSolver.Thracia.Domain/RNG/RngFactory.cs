namespace FERNGSolver.Thracia.Domain.RNG
{
    public static class RngFactory
    {
        /// <summary>
        /// トラキア776のRNGを作成します。
        /// </summary>
        public static IRng Create(int tableIndex)
        {
            return new Internal.Rng(Const.InitialTables[tableIndex]);
        }

        /// <summary>
        /// Rngを複製してRNGを作成します。
        /// </summary>
        public static IRng CreateFromRng(IRng origin)
        {
            return new Internal.Rng(origin.States, origin.CurrentIndex);
        }
    }
}
