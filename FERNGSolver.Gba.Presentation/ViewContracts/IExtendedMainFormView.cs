using FERNGSolver.Common.ViewContracts;

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
    }
}
