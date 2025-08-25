namespace FERNGSolver.Genealogy.Presentation.ViewContracts
{
    /// <summary>
    /// 闘技場チェックに関する設定のビューのインターフェースです。
    /// </summary>
    public interface IArenaCheckSettingsView
    {
        /// <summary>
        /// 闘技場チェックを使用するかどうかを取得します。
        /// </summary>
        bool UsesArenaCheck { get; }

        /// <summary>
        /// High/Lowパターンの文字列を取得します。
        /// </summary>
        string HighOrLowPatternString { get; }
    }
}
