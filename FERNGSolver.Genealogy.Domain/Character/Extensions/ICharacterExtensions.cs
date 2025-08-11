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

        class Character : ICharacter
        {
            public string Name { get; }
            public int HpGrowthRate { get; }
            public int StrGrowthRate { get; }
            public int MgcGrowthRate { get; }
            public int DefGrowthRate { get; }
            public int TecGrowthRate { get; }
            public int SpdGrowthRate { get; }
            public int LucGrowthRate { get; }
            public int MdfGrowthRate { get; }

            public Character(string name, int hp, int str, int mgc, int def, int tec, int spd, int luc, int mdf)
            {
                Name = name;
                HpGrowthRate = hp;
                StrGrowthRate = str;
                MgcGrowthRate = mgc;
                DefGrowthRate = def;
                TecGrowthRate = tec;
                SpdGrowthRate = spd;
                LucGrowthRate = luc;
                MdfGrowthRate = mdf;
            }
        }
    }
}
