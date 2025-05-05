using FERNGSolver.Common.ViewContracts;

namespace FERNGSolver.Gba.Presentation.ViewContracts
{
    public interface IExtendedMainFormView : IMainFormView
    {
        /// <summary>
        /// 戦闘を行うかどうかを取得します。
        /// </summary>
        bool ContainsCombat { get; }

        /// <summary>
        /// レベルアップを行うかどうかを取得します。
        /// </summary>
        bool ContainsGrowth { get; }

        /// <summary>
        /// 検索条件のSeedを取得します。
        /// </summary>
        IReadOnlyList<ushort> Seeds { get; }

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
