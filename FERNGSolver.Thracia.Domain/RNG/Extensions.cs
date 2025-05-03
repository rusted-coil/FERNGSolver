namespace FERNGSolver.Thracia.Domain.RNG
{
    public static class Extensions
    {
        private static bool[] s_CxTable = [true, true, false, true, false, false, true, false, true, true, false, true, true, false, true, false, false, true, false, false, true, false, true, true, false];

        /// <summary>
        /// 乱数値が◯✕法で◯にあたるかどうかを返します。
        /// </summary>
        public static bool ToCx(this int value)
        {
            return s_CxTable[(value + 1) % 25];
        }
    }
}
