using FERNGSolver.Common.Presentation.ViewContracts;
using System.Reactive;

namespace FERNGSolver.Radiance.Presentation.ViewContracts
{
    public interface IExtendedMainFormView : IMainFormView, IFalconKnightMethodSettingsView, ICombatSettingsView, IGrowthSettingsView
    {
        /// <summary>
        /// テーブル指定で検索する場合の番号を取得します。
        /// <para> * nullの時、全てのテーブルから検索します。</para>
        /// </summary>
        int? SearchTableIndex { get; }

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
        /// 検索条件が変更されたことを通知するストリームを取得します。
        /// </summary>
        IObservable<Unit> SearchConditionChanged { get; }
    }
}
