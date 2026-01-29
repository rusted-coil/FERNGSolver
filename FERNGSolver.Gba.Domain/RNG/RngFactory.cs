using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Gba.Domain.RNG
{
    public static class RngFactory
    {
        /// <summary>
        /// GBA作品のRNGを作成します。
        /// </summary>
        public static ICloneableRng CreateDefault(bool isBindingBlade)
        {
            // 初期seedはゲームの固定値を使う
            var seeds = Const.DefaultSeeds;
            return new Internal.Rng(seeds[0], seeds[1], seeds[2], isBindingBlade);
        }

        /// <summary>
        /// seedを指定してRNGを作成します。
        /// </summary>
        public static ICloneableRng CreateFromSeeds(ushort seed0, ushort seed1, ushort seed2, bool isBindingBlade)
        {
            return new Internal.Rng(seed0, seed1, seed2, isBindingBlade);
        }
    }
}
