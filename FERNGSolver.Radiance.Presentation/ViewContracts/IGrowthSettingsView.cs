using FERNGSolver.Radiance.Application.Search.Strategy;

namespace FERNGSolver.Radiance.Presentation.ViewContracts
{
    public interface IGrowthSettingsView
    {
        /// <summary>
        /// レベルアップを行うかどうかを取得します。
        /// </summary>
        bool ContainsGrowth { get; }

        /// <summary>
        /// HPの実際の成長率を取得します。
        /// </summary>
        int HpGrowthRate { get; }

        /// <summary>
        /// 力の実際の成長率を取得します。
        /// </summary>
        int StrGrowthRate { get; }

        /// <summary>
        /// 魔力の実際の成長率を取得します。
        /// </summary>
        int MgcGrowthRate { get; }

        /// <summary>
        /// 技の実際の成長率を取得します。
        /// </summary>
        int TecGrowthRate { get; }

        /// <summary>
        /// 速さの実際の成長率を取得します。
        /// </summary>
        int SpdGrowthRate { get; }

        /// <summary>
        /// 幸運の実際の成長率を取得します。
        /// </summary>
        int LucGrowthRate { get; }

        /// <summary>
        /// 守備の実際の成長率を取得します。
        /// </summary>
        int DefGrowthRate { get; }

        /// <summary>
        /// 魔防の実際の成長率を取得します。
        /// </summary>
        int MdfGrowthRate { get; }

        /// <summary>
        /// HPの検索タイプを取得します。
        /// </summary>
        GrowthSearchType HpSearchType { get; }

        /// <summary>
        /// 力の検索タイプを取得します。
        /// </summary>
        GrowthSearchType StrSearchType { get; }

        /// <summary>
        /// 魔力の検索タイプを取得します。
        /// </summary>
        GrowthSearchType MgcSearchType { get; }

        /// <summary>
        /// 技の検索タイプを取得します。
        /// </summary>
        GrowthSearchType TecSearchType { get; }

        /// <summary>
        /// 速さの検索タイプを取得します。
        /// </summary>
        GrowthSearchType SpdSearchType { get; }

        /// <summary>
        /// 幸運の検索タイプを取得します。
        /// </summary>
        GrowthSearchType LucSearchType { get; }

        /// <summary>
        /// 守備の検索タイプを取得します。
        /// </summary>
        GrowthSearchType DefSearchType { get; }

        /// <summary>
        /// 魔防の検索タイプを取得します。
        /// </summary>
        GrowthSearchType MdfSearchType { get; }
    }
}
