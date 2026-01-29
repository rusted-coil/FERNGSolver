namespace FERNGSolver.Common.Domain.RNG
{
    public interface IRng
    {
        /// <summary>
        /// 次の乱数値(0～100)を取得します。
        /// <para> * 基本的に「乱数値＜目標値」で判定を行うため、乱数値100は封印の剣の不具合でのみ発生します。</para>
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
