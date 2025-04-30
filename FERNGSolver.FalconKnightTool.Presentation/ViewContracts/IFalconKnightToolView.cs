using System.Reactive;

namespace FERNGSolver.FalconKnightTool.Presentation.ViewContracts
{
    public interface IFalconKnightToolView
    {
        /// <summary>
        /// 「追加」ボタンがクリックされたことを通知するストリームです。
        /// </summary>
        IObservable<Unit> AddButtonClicked { get; }
    }
}
