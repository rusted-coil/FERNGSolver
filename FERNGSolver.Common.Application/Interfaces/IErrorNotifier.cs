namespace FERNGSolver.Common.Application.Interfaces
{
    /// <summary>
    /// エラーを通知するためのインターフェースです。
    /// </summary>
    public interface IErrorNotifier
    {
        /// <summary>
        /// エラーメッセージを通知します。
        /// </summary>
        /// <param name="message">表示するエラーメッセージ。</param>
        void NotifyError(string message);
    }
}
