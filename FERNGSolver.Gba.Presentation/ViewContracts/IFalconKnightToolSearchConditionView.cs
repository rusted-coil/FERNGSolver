namespace FERNGSolver.Gba.Presentation.ViewContracts
{
    public interface IFalconKnightToolSearchConditionView
    {
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
