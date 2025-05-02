namespace FERNGSolver.Gba.Domain.RNG
{
    public static class RngFactory
    {
        /// <summary>
        /// GBA作品のRNGを作成します。
        /// </summary>
        public static IRng CreateDefault()
        {
            // 初期seedはゲームの固定値を使う
            return new Internal.Rng(0x3671, 0x90ea, 0x1496);
        }

        /// <summary>
        /// seedを指定してRNGを作成します。
        /// </summary>
        public static IRng CreateFromSeeds(ushort seed0, ushort seed1, ushort seed2)
        {
            return new Internal.Rng(seed0, seed1, seed2);
        }

        /// <summary>
        /// Rngを複製してRNGを作成します。
        /// </summary>
        public static IRng CreateFromRng(IRng origin)
        {
            return new Internal.Rng(origin.States[0], origin.States[1], origin.States[2]);
        }
    }
}
