namespace FERNGSolver.Application.Config
{
    /// <summary>
    /// メインフォームの設定関連のサービスを提供するインターフェースです。
    /// </summary>
    public interface IConfigService
    {
        /// <summary>
        /// 変更可能なコンフィグを取得します。
        /// </summary>
        IModifiableConfig Config { get; }

        /// <summary>
        /// Configオブジェクトのシリアライズ処理を実行します。
        /// </summary>
        void Serialize();
    }
}
