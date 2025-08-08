using FERNGSolver.Gba.Application.RNG;

namespace FERNGSolver.Gba.Presentation.RngView
{
    /// <summary>
    /// 表示する乱数値のViewModelのインターフェースです。
    /// </summary>
    public interface IRandomNumberViewModel : Common.Presentation.ViewContracts.IRandomNumberViewModel
    {
        /// <summary>
        /// 乱数値が何に使われたかを取得します。
        /// </summary>
        RandomNumberUsage Usage { get; }
    }
}
