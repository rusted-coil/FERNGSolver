namespace FERNGSolver.Radiance.UI.Blazor.Internal
{
    /// <summary>
    /// Web版で検索条件ペイン上部のコンボボックスから選択する、検索モードを表します。
    /// <para> * 選択されたモードに応じて、必要な条件アコーディオンのみを表示します。</para>
    /// </summary>
    internal enum SearchMode
    {
        /// <summary>
        /// ファルコンナイト法検索。
        /// </summary>
        FalconKnightMethod,

        /// <summary>
        /// 戦闘検索。
        /// </summary>
        Combat,

        /// <summary>
        /// レベルアップ検索。
        /// </summary>
        Growth,

        /// <summary>
        /// 戦闘＋レベルアップ検索。
        /// </summary>
        CombatAndGrowth,
    }
}
