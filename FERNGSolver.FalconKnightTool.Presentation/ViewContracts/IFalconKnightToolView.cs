using FERNGSolver.Common.Types;
using System.Reactive;

namespace FERNGSolver.FalconKnightTool.Presentation.ViewContracts
{
    public interface IFalconKnightToolView
    {
        /// <summary>
        /// 「追加」ボタンがクリックされたことを通知するストリームです。
        /// </summary>
        IObservable<Unit> AddButtonClicked { get; }

        /// <summary>
        /// 「検索」ボタンがクリックされたことを通知するストリームです。
        /// </summary>
        IObservable<Unit> SearchButtonClicked { get; }

        /// <summary>
        /// パスの入力が完了したことを通知するストリームです。
        /// </summary>
        IObservable<IReadOnlyList<GridPosition>> PathDetermined { get; }

        /// <summary>
        /// 現在のパスのcx列文字列を設定します。
        /// </summary>
        void SetCurrentPathText(string text);

        /// <summary>
        /// 特定の文字列をcx列文字列として追加します。
        /// </summary>
        void AddCxStringText(string text);

        /// <summary>
        /// 現在入力されているcx列文字列を取得します。
        /// </summary>
        string GetCxStringText();
    }
}
