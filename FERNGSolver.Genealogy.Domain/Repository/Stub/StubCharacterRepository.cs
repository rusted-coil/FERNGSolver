using FERNGSolver.Genealogy.Domain.Character;

namespace FERNGSolver.Genealogy.Domain.Repository.Stub
{
    public sealed class StubCharacterRepository : ICharacterRepository
    {
        private readonly ICharacter[] m_Characters;
        public IReadOnlyList<ICharacter> AllCharacters => m_Characters;

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

        public StubCharacterRepository()
        {
            m_Characters = [
                new Character("シグルド",110,50,5,40,50,30,40,5),
            ];
        }
    }
}
