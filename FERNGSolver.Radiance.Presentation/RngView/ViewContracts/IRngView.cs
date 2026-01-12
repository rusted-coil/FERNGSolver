using System.Reactive;

namespace FERNGSolver.Radiance.Presentation.RngView.ViewContracts
{
    public interface IRngView
    {
        /// <summary>
        /// テーブル番号を取得します。
        /// </summary>
        int TableIndex { get; }

        /// <summary>
        /// 現在の乱数位置を取得します。
        /// </summary>
        int CurrentPosition { get; }

        /// <summary>
        /// 乱数位置が変更されたときに通知されるストリームを取得します。
        /// </summary>
        IObservable<(int, int)> PositionChanged { get; }

        /// <summary>
        /// 表示する乱数列をセットします。
        /// </summary>
        void SetRandomNumbers(IReadOnlyList<IRandomNumberViewModel> viewModels);
    }
}
