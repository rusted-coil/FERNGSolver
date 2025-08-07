using FERNGSolver.Common.Presentation.Interfaces;
using System.Reactive;

namespace FERNGSolver.Common.Presentation.ViewContracts
{
    public interface IMainFormView
    {
        /// <summary>
        /// 「検索」ボタンがクリックされたことを通知するストリームを取得します。
        /// </summary>
        IObservable<Unit> SearchButtonClicked { get; }

        /// <summary>
        /// 結果を表示します。
        /// </summary>
        void ShowSearchResults(IReadOnlyList<ITableColumn> columns, Type viewModelType, IReadOnlyList<object> viewModels);

        /// <summary>
        /// 乱数ビューの追加ボタンがクリックされたことを通知するストリームを取得します。
        /// </summary>
        IObservable<Unit> AddRngViewButtonClicked { get; }

        /// <summary>
        /// 検索結果欄から、特定の検索結果を乱数ビューに追加することを要求するイベントが発行されるストリームを取得します。
        /// <para> * 引数はShowSearchResultsで渡したViewModelの型です。</para>
        /// </summary>
        IObservable<IEnumerable<object>> AddRngViewRequestedFromSearchResults { get; }
    }
}
