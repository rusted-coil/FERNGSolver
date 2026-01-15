namespace FERNGSolver.Radiance.Domain.Character.Extensions
{
    public static class ICharacterExtensions
    {
        public class BoostArgs
        {
            public bool HasSwordBand { get; set; } = false;
            public bool HasFighterBand { get; set; } = false;
            public bool HasArcherBand { get; set; } = false;
            public bool HasKnightBand { get; set; } = false;
            public bool HasPaladinBand { get; set; } = false;
            public bool HasPegasusBand { get; set; } = false;
            public bool HasWyvernBand { get; set; } = false;
            public bool HasMageBand { get; set; } = false;
            public bool HasPriestBand { get; set; } = false;
            public bool HasThiefBand { get; set; } = false;
            public bool HasKnightWard { get; set; } = false;
        }

        /// <summary>
        /// キャラデータにブーストアイテムを適用したデータを取得します。
        /// </summary>
        public static ICharacter Boost(this ICharacter character, BoostArgs args)
        {
            return new Character(
                character.Name,
                character.HpGrowthRate + (args.HasFighterBand ? 5 : 0) + (args.HasPaladinBand ? 5 : 0),
                character.StrGrowthRate + (args.HasFighterBand ? 5 : 0) + (args.HasKnightBand ? 5 : 0) + (args.HasWyvernBand ? 5 : 0),
                character.MgcGrowthRate + (args.HasMageBand ? 10 : 0),
                character.TecGrowthRate + (args.HasSwordBand ? 5 : 0) + (args.HasArcherBand ? 5 : 0) + (args.HasThiefBand ? 5 : 0),
                character.SpdGrowthRate + (args.HasArcherBand ? 5 : 0) + (args.HasPaladinBand ? 5 : 0) + (args.HasThiefBand ? 5 : 0) + (args.HasKnightWard ? 30 : 0),
                character.LucGrowthRate + (args.HasSwordBand ? 5 : 0) + (args.HasPegasusBand ? 5 : 0) + (args.HasPriestBand ? 5 : 0),
                character.DefGrowthRate + (args.HasKnightBand ? 5 : 0) + (args.HasWyvernBand ? 5 : 0),
                character.MdfGrowthRate + (args.HasPegasusBand ? 5 : 0) + (args.HasPriestBand ? 5 : 0)
            );
        }

        class Character : ICharacter
        {
            public string Name { get; }
            public int HpGrowthRate { get; }
            public int StrGrowthRate { get; }
            public int MgcGrowthRate { get; }
            public int TecGrowthRate { get; }
            public int SpdGrowthRate { get; }
            public int LucGrowthRate { get; }
            public int DefGrowthRate { get; }
            public int MdfGrowthRate { get; }

            public Character(string name, int hp, int str, int mgc, int tec, int spd, int luc, int def, int mdf)
            {
                Name = name;
                HpGrowthRate = hp;
                StrGrowthRate = str;
                MgcGrowthRate = mgc;
                TecGrowthRate = tec;
                LucGrowthRate = luc;
                SpdGrowthRate = spd;
                DefGrowthRate = def;
                MdfGrowthRate = mdf;
            }
        }
    }
}
