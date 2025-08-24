namespace FERNGSolver.Genealogy.Presentation.Search
{
    /// <summary>
    /// RNGの状態を含む結果のビューモデルインターフェースです。
    /// </summary>
    public interface IRngStateResultViewModel
    {
        /// <summary>
        /// 乱数の消費数を表す文字列を取得します。
        /// </summary>
        string Position { get; }
    }
}
