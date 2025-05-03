namespace FERNGSolver.Thracia.Domain.RNG
{
    public interface IRng
    {
        /// <summary>
        /// 次の乱数値(0～99)を取得します。
        /// </summary>
        int Next();

        /// <summary>
        /// 現在のRNGの状態であるテーブルの値を取得します。
        /// <para> * 長さ55の配列です。</para>
        /// </summary>
        IReadOnlyList<int> States { get; }

        /// <summary>
        /// 現在のRNGの状態であるテーブル内の位置を取得します。
        /// </summary>
        int CurrentIndex { get; }
    }
}
