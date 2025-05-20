using FERNGSolver.Application.Config;
using System.Reactive;

namespace FERNGSolver.Presentation.ViewContracts
{
    public interface IMainFormView
    {
        /// <summary>
        /// メインフォームの初期化が完了したことを通知するストリームを取得します。
        /// </summary>
        IObservable<Unit> Initialized { get; }

        /// <summary>
        /// コンフィグをViewに反映します。
        /// <para> * 初期化が完了されている必要があります。</para>
        /// </summary>
        void ReflectConfig(IConfig config);

        /// <summary>
        /// 保存が必要なコンフィグが変更されたことを通知するストリームを取得します。
        /// </summary>
        IObservable<Unit> PersistentConfigChanged { get; }
    }
}
