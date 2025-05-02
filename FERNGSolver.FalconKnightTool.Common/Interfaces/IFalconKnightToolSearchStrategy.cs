namespace FERNGSolver.FalconKnightTool.Common.Interfaces
{
    /// <summary>
    /// ファルコンナイト法ツールが呼び出す検索処理の共通ストラテジのインターフェースです。
    /// </summary>
    public interface IFalconKnightToolSearchStrategy
    {
        /// <summary>
        /// 検索処理を行います。
        /// <para> * ファルコンナイト法ツールの共通部分で入力する情報を引数として渡し、作品固有の設定などは内部で処理します。</para>
        /// </summary>
        void ExecuteSearch(string cxString);
    }
}
