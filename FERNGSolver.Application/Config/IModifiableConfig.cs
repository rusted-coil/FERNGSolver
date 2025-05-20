namespace FERNGSolver.Application.Config
{
    /// <summary>
    /// 変更可能なメインフォームの設定を表すインターフェースです。
    /// </summary>
    public interface IModifiableConfig : IConfig
    {
        /// <summary>
        /// 選択中のタイトルIDを取得・設定します。
        /// </summary>
        new string SelectingTitle { get; set; }
    }
}
