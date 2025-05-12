namespace FERNGSolver.Gba.Domain.RNG
{
    public static class Extensions
    {
        /// <summary>
        /// 乱数値が◯✕法で◯にあたるかどうかを返します。
        /// </summary>
        public static bool ToCx(this int value)
        {
            return value <= 49; // GBA版は49以下で◯
        }

        /// <summary>
        /// offset回分、乱数を進めます。
        /// </summary>
        public static void Advance(this IRng rng, int offset)
        {
            for (int i = 0; i < offset; ++i)
            {
                rng.Next();
            }
        }
    }
}
