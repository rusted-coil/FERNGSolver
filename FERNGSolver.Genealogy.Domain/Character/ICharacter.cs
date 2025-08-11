namespace FERNGSolver.Genealogy.Domain.Character
{
    public interface ICharacter
    {
        /// <summary>
        /// キャラ名を取得します。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// HP成長率を取得します。
        /// </summary>
        int HpGrowthRate { get; }

        /// <summary>
        /// 力成長率を取得します。
        /// </summary>
        int StrGrowthRate { get; }

        /// <summary>
        /// 魔力成長率を取得します。
        /// </summary>
        int MgcGrowthRate { get; }

        /// <summary>
        /// 守備成長率を取得します。
        /// </summary>
        int DefGrowthRate { get; }

        /// <summary>
        /// 技成長率を取得します。
        /// </summary>
        int TecGrowthRate { get; }

        /// <summary>
        /// 速さ成長率を取得します。
        /// </summary>
        int SpdGrowthRate { get; }

        /// <summary>
        /// 幸運成長率を取得します。
        /// </summary>
        int LucGrowthRate { get; }

        /// <summary>
        /// 魔防成長率を取得します。
        /// </summary>
        int MdfGrowthRate { get; }
    }
}
