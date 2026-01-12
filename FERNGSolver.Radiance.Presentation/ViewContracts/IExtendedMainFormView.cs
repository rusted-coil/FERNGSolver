using FERNGSolver.Common.Presentation.ViewContracts;
using System.Reactive;

namespace FERNGSolver.Radiance.Presentation.ViewContracts
{
    public interface IExtendedMainFormView : IMainFormView, IFalconKnightMethodSettingsView, ICombatSettingsView, IGrowthSettingsView
    {
        /// <summary>
        /// 検索条件が変更されたことを通知するストリームを取得します。
        /// </summary>
        IObservable<Unit> SearchConditionChanged { get; }
    }
}
