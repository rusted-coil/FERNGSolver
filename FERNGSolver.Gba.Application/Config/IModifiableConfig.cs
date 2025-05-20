namespace FERNGSolver.Gba.Application.Config
{
    /// <summary>
    /// 変更可能なGBAの設定を表すインターフェースです。
    /// </summary>
    public interface IModifiableConfig : IConfig
    {
        /// <summary>
        /// 計算方式の設定が封印の剣かどうかを取得・設定します。
        /// </summary>
        new bool IsBindingBlade { get; set; }
    }
}
