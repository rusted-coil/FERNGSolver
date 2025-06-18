using FERNGSolver.Genealogy.Application.RNG;

namespace FERNGSolver.Genealogy.Presentation.RngList.RngView
{
    /// <summary>
    /// 表示する乱数値のViewModelのインターフェースです。
    /// </summary>
    public interface IRandomNumberViewModel
    {
        /// <summary>
        /// 乱数値を取得します。
        /// </summary>
        ushort Value { get; }

        /// <summary>
        /// 乱数値が何に使われたかを取得します。
        /// </summary>
        RandomNumberUsage Usage { get; }

        /// <summary>
        /// 判定が成功したかどうかを取得します。
        /// </summary>
        bool IsOk { get; }
    }
}
