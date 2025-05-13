using FERNGSolver.Common.Interfaces;
using System.Reactive;

namespace FERNGSolver.Common.ViewContracts
{
    public interface IMainFormView
    {
        /// <summary>
        /// 「検索」ボタンがクリックされたことを通知するストリームです。
        /// </summary>
        IObservable<Unit> SearchButtonClicked { get; }

        /// <summary>
        /// 結果を表示します。
        /// </summary>
        void ShowSearchResults(IReadOnlyList<ITableColumn> columns, Type viewModelType, IReadOnlyList<object> viewModels);
    }
}
