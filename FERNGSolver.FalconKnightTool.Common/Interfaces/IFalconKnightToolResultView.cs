namespace FERNGSolver.FalconKnightTool.Common.Interfaces
{
    public interface IFalconKnightToolResultView
    {
        /// <summary>
        /// 結果を表示します。
        /// </summary>
        void ShowSearchResults(Type viewModelType, IReadOnlyList<object> viewModels);
    }
}
