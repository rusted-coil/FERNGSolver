using FERNGSolver.Radiance.Application.RNG;

namespace FERNGSolver.Radiance.Presentation.RngView
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
