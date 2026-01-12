namespace FERNGSolver.Radiance.Domain.RNG
{
    public static class Util
    {
        /// <summary>
        /// 乱数値が◯✕法で◯にあたるかどうかを返します。
        /// </summary>
        public static bool IsRngValueOk(ushort value)
        {
            return value <= 49; // 蒼炎は49以下で◯？
        }
    }
}
