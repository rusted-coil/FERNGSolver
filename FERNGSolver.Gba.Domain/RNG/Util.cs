namespace FERNGSolver.Gba.Domain.RNG
{
    public static class Util
    {
        /// <summary>
        /// 乱数値が◯✕法で◯にあたるかどうかを返します。
        /// </summary>
        public static bool IsRngValueOk(ushort value)
        {
            return value <= 49; // GBA版は49以下で◯
        }
    }
}
