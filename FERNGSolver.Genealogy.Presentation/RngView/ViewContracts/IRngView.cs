namespace FERNGSolver.Genealogy.Presentation.RngView.ViewContracts
{
    public interface IRngView
    {
        /// <summary>
        /// 現在の乱数位置を取得します。
        /// </summary>
        int CurrentPosition { get; }

        /// <summary>
        /// 乱数位置が変更されたときに通知されるストリームを取得します。
        /// </summary>
        IObservable<int> PositionChanged { get; }

        /// <summary>
        /// 表示する乱数列をセットします。
        /// </summary>
        /// <param name="viewModels">表示したい乱数1つあたりviewModel1つを持つリスト</param>
        /// <param name="partitionPositions">区切り線を出したい位置（[n]番目のViewModelの前に出したい場合はnを指定）</param>
        void SetRandomNumbers(IReadOnlyList<IRandomNumberViewModel> viewModels, IEnumerable<int> partitionPositions);
    }
}
