namespace FERNGSolver.Gba.Application.Config
{
    /// <summary>
    /// GBAの設定を表すインターフェースです。
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// 計算方式の設定が封印の剣かどうかを取得します。
        /// </summary>
        bool IsBindingBlade { get; }
    }
}
