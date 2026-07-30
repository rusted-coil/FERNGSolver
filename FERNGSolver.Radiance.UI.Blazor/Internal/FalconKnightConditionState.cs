namespace FERNGSolver.Radiance.UI.Blazor.Internal
{
    /// <summary>
    /// ファルコンナイト法条件の入力値を保持します。
    /// <para> * RadianceSearchFormとFalconKnightConditionPanelの間で共有される可変状態です。</para>
    /// </summary>
    public sealed class FalconKnightConditionState
    {
        public string CxString { get; set; } = string.Empty;
        public bool AddsCxOffset { get; set; } = true;
    }
}
