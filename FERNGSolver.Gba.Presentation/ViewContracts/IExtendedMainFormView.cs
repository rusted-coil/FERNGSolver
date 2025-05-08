using FERNGSolver.Common.ViewContracts;

namespace FERNGSolver.Gba.Presentation.ViewContracts
{
    public interface IExtendedMainFormView : IMainFormView, IGrowthSettingsView, ICombatSettingsView
    {
        /// <summary>
        /// ファルコンナイト法による検索を行うかどうかを取得します。
        /// <para> * この検索が有効な時、戦闘やレベルアップは考慮しません。</para>
        /// </summary>
        bool UsesFalconKnightMethod { get; }

        /// <summary>
        /// 入力されたcx列を取得します。
        /// <para> * 文字列のValidationは行われていません。</para>
        /// </summary>
        string CxString { get; }

        /// <summary>
        /// 検索条件のSeedを取得します。
        /// </summary>
        IReadOnlyList<ushort> Seeds { get; }

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
