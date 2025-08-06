namespace FERNGSolver.Gba.Presentation.RngView
{
    /// <summary>
    /// 乱数ビューア全体を管理するPresenterのインターフェースです。
    /// </summary>
    public interface IRngViewListPresenter : IDisposable
    {
        /// <summary>
        /// 乱数の初期位置を指定して乱数ビューを追加します。
        /// </summary>
        void AddRngView(int initialPosition);
    }
}
