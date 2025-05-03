namespace FERNGSolver.Gba.Domain.RNG
{
    public static class Extensions
    {
        /// <summary>
        /// 乱数値が◯✕法で◯にあたるかどうかを返します。
        /// </summary>
        public static bool ToCx(this int value)
        {
            return value <= 49;
        }
    }
}
