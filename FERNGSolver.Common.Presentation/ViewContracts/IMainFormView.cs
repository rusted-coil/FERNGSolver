using FERNGSolver.Common.Presentation.Interfaces;
using System.Reactive;

namespace FERNGSolver.Common.Presentation.ViewContracts
{
    public interface IMainFormView
    {
        /// <summary>
        /// 特定のタイトルをメインフォームのタブで選択中、「検索」ボタンがクリックされたことを通知するストリームを取得します。
        /// </summary>
        IObservable<Unit> GetSearchButtonClicked(string title);

        /// <summary>
        /// 結果を表示します。
        /// </summary>
        void ShowSearchResults(IReadOnlyList<ITableColumn> columns, Type viewModelType, IReadOnlyList<object> viewModels);

        /// <summary>
        /// 特定のタイトルをメインフォームのタブで選択中、乱数ビューアの初期化ボタンがクリックされたことを通知するストリームを取得します。
        /// </summary>
        IObservable<Unit> GetRngViewInitializeButtonClicked(string title);
    }
}
