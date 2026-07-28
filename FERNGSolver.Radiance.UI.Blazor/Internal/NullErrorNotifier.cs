using FERNGSolver.Common.Application.Interfaces;

namespace FERNGSolver.Radiance.UI.Blazor.Internal
{
    /// <summary>
    /// プロトタイプ用の簡易エラー通知実装です。
    /// <para> * ブラウザのコンソールへの出力に加え、<see cref="OnError"/>経由でコンポーネントに通知します。</para>
    /// </summary>
    internal sealed class NullErrorNotifier : IErrorNotifier
    {
        public Action<string>? OnError { get; set; }

        public void NotifyError(string message)
        {
            Console.WriteLine($"[Error] {message}");
            OnError?.Invoke(message);
        }
    }
}
