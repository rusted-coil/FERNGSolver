using FERNGSolver.Radiance.Domain.Character;

namespace FERNGSolver.Radiance.Domain.Repository.Stub
{
    public sealed class StubCharacterRepository : ICharacterRepository
    {
        private ICharacter[] Characters { get; init; }
        public IReadOnlyList<ICharacter> AllCharacters => Characters;

        private class Character : ICharacter
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
                SpdGrowthRate = spd;
                LucGrowthRate = luc;
                DefGrowthRate = def;
                MdfGrowthRate = mdf;
            }
        }

        public StubCharacterRepository()
        {
            ICharacter[] characters = [
                new Character("アイク", 75, 50, 20, 50, 55, 35, 40, 40),
                new Character("ティアマト", 80, 45, 25, 60, 50, 45, 40, 45),
                new Character("オスカー", 55, 45, 20, 50, 45, 30, 35, 30),
                new Character("ボーレ", 75, 60, 5, 50, 45, 35, 25, 25),
                new Character("キルロイ", 40, 5, 60, 50, 40, 50, 25, 55),
                new Character("シノン", 75, 65, 20, 70, 65, 35, 50, 40),
                new Character("ガトリー", 80, 55, 5, 55, 25, 25, 60, 30),
                new Character("セネリオ", 45, 5, 60, 55, 40, 30, 15, 55),
                new Character("ワユ", 50, 40, 30, 45, 60, 45, 20, 25),
                new Character("イレース", 45, 25, 50, 45, 30, 45, 15, 50),
                new Character("マーシャ", 55, 40, 20, 50, 55, 40, 25, 30),
                new Character("ミスト", 50, 35, 50, 25, 40, 60, 15, 40),
                new Character("ヨファ", 60, 40, 20, 45, 50, 40, 30, 25),
                new Character("レテ", 130, 50, 5, 65, 70, 50, 40, 25),
                new Character("モゥディ", 150, 65, 0, 55, 50, 40, 40, 20),
                new Character("フォルカ", 65, 50, 5, 55, 65, 35, 20, 10),
                new Character("ケビン", 60, 50, 15, 50, 40, 25, 40, 30),
                new Character("チャップ", 75, 45, 10, 50, 25, 20, 55, 25),
                new Character("ネフェニー", 55, 40, 20, 55, 55, 25, 35, 25),
                new Character("ツイハーク", 55, 45, 15, 50, 60, 40, 30, 20),
                new Character("サザ", 60, 55, 10, 70, 65, 55, 35, 30),
                new Character("ジル", 60, 40, 30, 45, 45, 25, 35, 30),
                new Character("ステラ", 45, 40, 20, 55, 50, 40, 30, 25),
                new Character("マカロフ", 60, 55, 5, 45, 50, 25, 45, 20),
                new Character("ソーンバルケ", 70, 50, 20, 40, 55, 25, 35, 30),
                new Character("トパック", 50, 20, 45, 40, 45, 35, 25, 45),
                new Character("ムワリム", 145, 70, 5, 70, 55, 35, 60, 45),
                new Character("ダラハウ", 75, 60, 30, 40, 35, 40, 45, 25),
                new Character("リュシオン", 65, 5, 40, 50, 50, 60, 15, 50),
                new Character("ウルキ", 140, 60, 10, 65, 60, 35, 35, 25),
                new Character("ヤナフ", 130, 55, 10, 70, 65, 40, 30, 25),
                new Character("タニス", 60, 40, 35, 70, 40, 30, 25, 30),
                new Character("カリル", 50, 25, 45, 45, 45, 30, 40, 35),
                new Character("タウロニオ", 60, 55, 5, 50, 30, 15, 60, 40),
                new Character("ライ", 130, 50, 0, 55, 55, 35, 35, 20),
                new Character("ハール", 65, 60, 5, 60, 35, 15, 45, 20),
                new Character("ルキノ", 70, 50, 30, 70, 65, 50, 40, 40),
                new Character("ユリシーズ", 55, 40, 65, 65, 55, 30, 35, 50),
                new Character("ジョフレ", 65, 50, 25, 55, 55, 20, 45, 45),
                new Character("ラルゴ", 80, 70, 5, 45, 45, 30, 25, 20),
                new Character("エリンシア", 60, 30, 80, 45, 40, 60, 25, 35),
                new Character("イナ", 145, 35, 5, 50, 60, 40, 40, 30),
                new Character("ナーシル", 150, 50, 10, 55, 45, 35, 60, 25),
                new Character("ティバーン", 145, 70, 5, 70, 65, 50, 60, 25),
                new Character("ネサラ", 135, 60, 40, 70, 75, 20, 55, 35),
                new Character("ジフカ", 160, 75, 5, 70, 60, 40, 50, 30),
            ];

            Characters = characters.OrderBy(character => character.Name).ToArray();
        }
    }
}
