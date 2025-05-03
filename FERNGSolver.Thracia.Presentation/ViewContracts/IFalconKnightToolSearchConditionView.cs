namespace FERNGSolver.Thracia.Presentation.ViewContracts
{
    public interface IFalconKnightToolSearchConditionView
    {
        /// <summary>
        /// テーブルの指定を取得します。
        /// <para> * テーブルの指定が無い場合はnullを返します。</para>
        /// </summary>
        int? TableIndex { get; }

        /// <summary>
        /// 検索条件の最小消費数を取得します。
        /// </summary>
        int OffsetMin { get; }

        /// <summary>
        /// 検索条件の最大消費数を取得します。
        /// </summary>
        int OffsetMax { get; }
    }
}
