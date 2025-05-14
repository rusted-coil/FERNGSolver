namespace FERNGSolver.Gba.Presentation.ViewContracts
{
    public interface IFalconKnightMethodSettingsView
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
        /// cx列による消費分を消費数に加算するかどうかを取得します。
        /// </summary>
        bool AddsCxOffset { get; }
    }
}
