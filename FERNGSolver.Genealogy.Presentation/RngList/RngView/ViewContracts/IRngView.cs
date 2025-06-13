namespace FERNGSolver.Genealogy.Presentation.RngList.RngView.ViewContracts
{
    public interface IRngView
    {
        /// <summary>
        /// 乱数位置が変更されたときに通知されるストリームを取得します。
        /// </summary>
        IObservable<int> PositionChanged { get; }

        /// <summary>
        /// 表示する乱数列をセットします。
        /// </summary>
        void SetRandomNumbers(IReadOnlyList<ushort> values);
    }
}
