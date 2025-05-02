namespace FERNGSolver.Gba.Domain.RNG
{
    public interface IRng
    {
        /// <summary>
        /// 次の乱数値(0～99)を取得します。
        /// </summary>
        int Next();

        /// <summary>
        /// 現在のRNGの状態である値を取得します。
        /// <para> * 長さ3の配列で、これをseed[0]～[2]とすることでRNGの複製ができます。</para>
        /// </summary>
        IReadOnlyList<ushort> States { get; }
    }
}
