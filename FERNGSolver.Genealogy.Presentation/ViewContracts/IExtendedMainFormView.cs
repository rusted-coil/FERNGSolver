using FERNGSolver.Common.Presentation.ViewContracts;
using System.Reactive;

namespace FERNGSolver.Genealogy.Presentation.ViewContracts
{
    public interface IExtendedMainFormView : IMainFormView, ICombatSettingsView, IGrowthSettingsView
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
        /// 検索条件が変更されたことを通知するストリームを取得します。
        /// </summary>
        IObservable<Unit> SearchConditionChanged { get; }
    }
}
