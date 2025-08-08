namespace FERNGSolver.Common.Presentation.ViewContracts
{
    /// <summary>
    /// 乱数ビューアに表示するための乱数値の共通のViewModelインターフェースです。
    /// </summary>
    public interface IRandomNumberViewModel
    {
        /// <summary>
        /// 乱数値を取得します。
        /// </summary>
        ushort Value { get; }

        /// <summary>
        /// 判定が成功したかどうかを取得します。
        /// <para> * 判定に使われなかった場合、nullを返します。</para>
        /// </summary>
        bool? IsOk { get; }
    }
}
