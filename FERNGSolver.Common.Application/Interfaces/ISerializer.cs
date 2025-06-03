namespace FERNGSolver.Common.Application.Interfaces
{
    /// <summary>
    /// ファイルへの保存を行うためのインターフェースです。
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// 指定したパスにデータを保存します。
        /// <para> * 保存に成功した場合はtrueを返し、失敗した場合はfalseを返してerrorMessageにエラーメッセージを格納します。</para>
        /// </summary>
        bool Serialize<T>(string filePath, T data, out string errorMessage);
    }
}
