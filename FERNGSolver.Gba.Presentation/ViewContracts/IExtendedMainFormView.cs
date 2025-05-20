using FERNGSolver.Common.ViewContracts;
using FERNGSolver.Gba.Application.Config;
using System.Reactive;

namespace FERNGSolver.Gba.Presentation.ViewContracts
{
    public interface IExtendedMainFormView : IMainFormView, IFalconKnightMethodSettingsView, ICombatSettingsView, IGrowthSettingsView
    {
        /// <summary>
        /// 現在の消費数を取得します。
        /// </summary>
        int CurrentPosition { get; }

        /// <summary>
        /// 検索条件の最小消費数を取得します。
        /// </summary>
        int OffsetMin { get; }

        /// <summary>
        /// 検索条件の最大消費数を取得します。
        /// </summary>
        int OffsetMax { get; }

        /// <summary>
        /// ファルコンナイト法消費回数計算用の移動力を取得します。
        /// </summary>
        int FalconKnightMethodMove { get; }

        /// <summary>
        /// コンフィグをViewに反映します。
        /// </summary>
        void ReflectConfig(IConfig config);

        /// <summary>
        /// 保存が必要なコンフィグが変更されたことを通知するストリームを取得します。
        /// </summary>
        IObservable<Unit> PersistentConfigChanged { get; }
    }
}
