namespace FERNGSolver.Common.Domain.RNG
{
    public interface IRng
    {
        /// <summary>
        /// 次の乱数値(0～99)を取得します。
        /// </summary>
        ushort Next();

        /// <summary>
        /// count分の乱数を進めます。
        /// </summary>
        void Advance(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                Next();
            }
        }
    }
}
