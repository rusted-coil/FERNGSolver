namespace FERNGSolver.Genealogy.Domain.Character.Extensions
{
    public static class ICharacterExtensions
    {
        /// <summary>
        /// キャラデータが表示用のダミーデータかどうかを取得します。
        /// </summary>
        public static bool IsPartitionData(this ICharacter character)
        {
            return character.HpGrowthRate < 0;
        }
    }
}
