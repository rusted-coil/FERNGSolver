using FERNGSolver.Gba.Presentation.ViewContracts;

namespace FERNGSolver.Gba.Presentation.RngView.ViewContracts
{
    /// <summary>
    /// 乱数ビューアのリスト表示を管理するView制約のインターフェースです。
    /// </summary>
    public interface IRngViewListView
    {
        /// <summary>
        /// 乱数ビューアを一つ追加します。
        /// </summary>
        void AddView(IExtendedMainFormView mainFormView, int initialPosition);
    }
}
