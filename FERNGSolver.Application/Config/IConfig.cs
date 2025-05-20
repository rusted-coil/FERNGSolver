namespace FERNGSolver.Application.Config
{
    /// <summary>
    /// メインフォームの設定を表すインターフェースです。
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// 選択中のタイトルIDを取得します。
        /// </summary>
        string SelectingTitle { get; }
    }
}
