using FERNGSolver.Common.Types;

namespace FERNGSolver.FalconKnightTool.Domain.Path
{
    /// <summary>
    /// パスから乱数判定の◯✕に変換する処理を提供するインターフェースです。
    /// </summary>
    public interface IPathConverter
    {
        /// <summary>
        /// 座標のリストから、乱数のcx列に変換します。
        /// <para> * ◯(c)の時trueを返します。</para>
        /// </summary>
        IReadOnlyList<bool> PathToCx(IReadOnlyList<GridPosition> path);
    }
}
