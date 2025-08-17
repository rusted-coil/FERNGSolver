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
                new Character("ノイッシュ",80,40,5,40,30,20,20,5),
                new Character("アレク",70,30,5,30,40,30,30,5),
                new Character("アーダン",90,50,5,40,10,20,10,5),
                new Character("レックス",90,40,5,50,20,20,20,5),
                new Character("キュアン",110,50,5,50,30,40,10,5),
                new Character("エスリン",60,30,5,20,30,30,20,10),
                new Character("フィン",70,30,5,30,40,30,50,5),
                new Character("ミデェール",60,30,5,30,30,40,10,5),
            ];
        }
    }
}
