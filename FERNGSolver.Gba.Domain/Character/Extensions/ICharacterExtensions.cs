namespace FERNGSolver.Gba.Domain.Character.Extensions
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

        /// <summary>
        /// キャラデータに成長率ブーストアイテムを使ったデータを取得します。
        /// </summary>
        public static ICharacter Boost(this ICharacter character)
        {
            return new Character(
                character.Name,
                character.HpGrowthRate + 5,
                character.AtkGrowthRate + 5,
                character.TecGrowthRate + 5,
                character.SpdGrowthRate + 5,
                character.DefGrowthRate + 5,
                character.MdfGrowthRate + 5,
                character.LucGrowthRate + 5);
        }

        class Character : ICharacter
        {
            public string Name { get; }
            public int HpGrowthRate { get; }
            public int AtkGrowthRate { get; }
            public int TecGrowthRate { get; }
            public int SpdGrowthRate { get; }
            public int DefGrowthRate { get; }
            public int MdfGrowthRate { get; }
            public int LucGrowthRate { get; }

            public Character(string name, int hp, int atk, int tec, int spd, int def, int mdf, int luc)
            {
                Name = name;
                HpGrowthRate = hp;
                AtkGrowthRate = atk;
                TecGrowthRate = tec;
                SpdGrowthRate = spd;
                DefGrowthRate = def;
                MdfGrowthRate = mdf;
                LucGrowthRate = luc;
            }
        }
    }
}
