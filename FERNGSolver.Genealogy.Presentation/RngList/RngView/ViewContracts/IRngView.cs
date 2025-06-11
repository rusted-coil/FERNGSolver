namespace FERNGSolver.Genealogy.Presentation.RngList.RngView.ViewContracts
{
    public interface IRngView
    {
        /// <summary>
        /// 表示する乱数列をセットします。
        /// </summary>
        void SetRandomNumbers(IReadOnlyList<int> values);
    }
}
