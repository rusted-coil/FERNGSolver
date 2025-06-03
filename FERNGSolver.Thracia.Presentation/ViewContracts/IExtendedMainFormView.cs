using FERNGSolver.Common.Presentation.ViewContracts;

namespace FERNGSolver.Thracia.Presentation.ViewContracts
{
    public interface IExtendedMainFormView : IMainFormView, IFalconKnightMethodSettingsView, ICombatSettingsView, IGrowthSettingsView
    {
        /// <summary>
        /// テーブル指定で検索する場合の番号を取得します。
        /// <para> * nullの時、全てのテーブルから検索します。</para>
        /// </summary>
        int? SearchTableIndex { get; }

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
