using FERNGSolver.Gba.Domain.Character;

namespace FERNGSolver.Gba.Domain.Repository.Stub
{
    public sealed class StubCharacterRepository : ICharacterRepository
    {
        private readonly ICharacter[] m_Characters;
        public IReadOnlyList<ICharacter> AllCharacters => m_Characters;

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

        public StubCharacterRepository()
        {
            var commonSeparator = new ICharacter[] { new Character("――――――", -1, -1, -1, -1, -1, -1, -1) };

            var sacredStoneSeparator = new ICharacter[] { new Character("――【聖魔】――", -1, -1, -1, -1, -1, -1, -1) };
            ICharacter[] sacredStone1 = [
                new Character("エイリーク",70,40,60,60,30,30,60),
                new Character("ゼト",85,50,45,45,40,30,25),
                new Character("ギリアム",90,40,30,30,55,20,30),
                new Character("フランツ",80,40,40,50,25,20,40),
                new Character("モルダ",85,40,50,45,25,25,20),
                new Character("ヴァネッサ",50,35,55,60,20,30,50),
                new Character("ロス",70,50,35,25,25,20,40),
                new Character("ガルシア",80,65,40,20,25,15,40),
                new Character("ネイミー",55,45,50,60,15,35,50),
                new Character("コーマ",75,40,40,65,25,20,45),
                new Character("アスレイ",55,60,50,40,15,60,25),
                new Character("ルーテ",45,70,30,45,15,45,45),
                new Character("ナターシャ",50,60,25,40,15,55,60),
                new Character("ヨシュア",80,30,55,55,20,20,30),
                new Character("エフラム",80,55,55,45,35,25,50),
                new Character("フォルデ",80,40,50,45,20,25,35),
                new Character("カイル",85,50,40,40,25,20,20),
                new Character("ターナ",65,45,40,65,20,25,60),
                new Character("アメリア",70,40,40,40,30,15,50),
                new Character("ヒーニアス",60,40,40,45,20,25,45),
                new Character("ジスト",90,45,40,30,35,25,30),
                new Character("テティス",85,5,10,70,30,75,80),
                new Character("マリカ",75,25,50,55,15,20,50),
                new Character("ラーチェル",45,60,45,50,15,50,65),
                new Character("ドズラ",85,50,35,40,30,25,30),
                new Character("サレフ",50,30,25,40,30,35,40),
                new Character("ユアン",50,55,40,35,15,40,50),
                new Character("クーガー",85,55,40,45,25,15,35),
                new Character("レナック",60,25,45,60,25,25,25),
                new Character("デュッセル",85,55,40,30,45,30,20),
                new Character("ノール",70,50,40,35,10,45,20),
                new Character("ミルラ",130,90,85,65,150,30,30),
                new Character("シレーネ",70,35,50,60,20,50,30),
            ];
            ICharacter[] sacredStone2 = [
                new Character("ケセルダ",85,50,45,45,30,20,20),
                new Character("オルソン",80,55,45,40,45,30,25),
                new Character("アーヴ",75,45,50,40,20,45,15),
                new Character("イシュメア",75,30,60,55,20,25,30),
                new Character("セライナ",85,40,55,40,20,25,25),
                new Character("グレン",85,40,50,45,25,40,20),
                new Character("ヘイデン",70,40,40,45,25,25,40),
                new Character("ヴァルター",80,40,55,50,20,20,15),
                new Character("ファード",85,55,40,30,45,25,25),
                new Character("リオン",85,50,10,10,10,15,30),
            ];

            var blazingBladeSeparator = new ICharacter[] { new Character("――【烈火】――", -1, -1, -1, -1, -1, -1, -1) };
            ICharacter[] blazingBlade = [
                new Character("エリウッド",80,45,50,40,30,35,45),
                new Character("ロウエン",90,30,30,30,40,30,50),
                new Character("マーカス",65,30,50,25,15,35,30),
                new Character("レベッカ",60,40,50,60,15,30,50),
                new Character("ドルカス",80,60,40,20,25,15,45),
                new Character("バアトル",85,50,35,40,30,25,30),
                new Character("ヘクトル",90,60,45,35,50,25,30),
                new Character("オズイン",90,40,30,30,55,30,35),
                new Character("セーラ",50,50,30,40,15,55,60),
                new Character("マシュー",75,30,40,70,25,20,50),
                new Character("ギィ",75,30,50,70,15,25,45),
                new Character("マリナス",120,0,90,90,30,15,100),
                new Character("エルク",65,40,40,50,20,40,30),
                new Character("プリシラ",45,40,50,40,15,50,65),
                new Character("リン",70,40,60,60,20,30,55),
                new Character("ウィル",75,50,50,40,20,25,40),
                new Character("ケント",85,40,50,45,25,25,20),
                new Character("セイン",80,60,35,40,20,20,35),
                new Character("フロリーナ",60,40,50,55,15,35,50),
                new Character("レイヴァン",85,55,40,45,25,15,35),
                new Character("ルセア",55,60,50,40,10,60,20),
                new Character("カナス",70,45,40,35,25,45,25),
                new Character("ダーツ",70,65,20,60,20,15,35),
                new Character("フィオーラ",70,35,60,50,20,50,30),
                new Character("ラガルト",60,25,45,60,25,25,60),
                new Character("ニニアン",85,5,5,70,30,70,80),
                new Character("イサドラ",75,30,35,50,20,25,45),
                new Character("ヒース",80,50,50,45,30,20,20),
                new Character("ラス",80,50,40,50,10,25,30),
                new Character("ホークアイ",50,40,30,25,20,35,40),
                new Character("ガイツ",85,50,30,40,20,20,40),
                new Character("ワレス",70,45,40,20,35,35,30),
                new Character("ファリナ",75,50,40,45,25,30,45),
                new Character("パント",50,30,20,40,30,35,40),
                new Character("ルイーズ",60,40,40,40,20,30,30),
                new Character("カレル",70,30,50,50,10,15,30),
                new Character("ハーケン",80,35,30,40,30,25,20),
                new Character("ニノ",55,50,55,60,15,50,45),
                new Character("ジャファル",65,15,40,35,30,30,20),
                new Character("ヴァイダ",60,45,25,40,25,15,30),
                new Character("カアラ",60,25,45,55,10,20,40),
                new Character("ニルス",85,5,5,70,30,70,80),
                new Character("レナート",60,40,30,35,20,40,15),
                new Character("アトス",0,0,0,0,0,0,0),
            ];

            var bindingBladeSeparator = new ICharacter[] { new Character("――【封印】――", -1, -1, -1, -1, -1, -1, -1) };
            ICharacter[] bindingBlade = [
                new Character("ロイ",80,40,50,40,25,30,60),
                new Character("マーカス",60,25,20,25,15,20,20),
                new Character("アレン",85,45,40,45,25,10,40),
                new Character("ランス",80,40,45,50,20,15,35),
                new Character("ウォルト",80,40,50,40,20,10,40),
                new Character("ボールス",90,30,30,40,35,10,50),
                new Character("マリナス",100,0,50,50,20,5,100),
                new Character("エレン",45,50,30,20,5,60,70),
                new Character("ディーク",90,40,40,30,20,15,35),
                new Character("ワード",75,50,45,20,30,5,45),
                new Character("ロット",80,30,30,35,40,15,30),
                new Character("シャニー",45,30,55,60,10,25,60),
                new Character("チャド",85,50,50,80,25,15,60),
                new Character("ルゥ",50,40,50,50,15,30,35),
                new Character("クラリーネ",40,30,40,50,10,40,65),
                new Character("ルトガー",80,30,60,50,20,20,30),
                new Character("サウル",60,40,45,45,15,50,15),
                new Character("ドロシー",85,50,45,45,15,15,35),
                new Character("スー",55,30,55,65,10,15,50),
                new Character("ゼロット",75,25,20,20,30,15,15),
                new Character("トレック",85,40,30,35,30,5,50),
                new Character("ノア",75,30,45,30,30,10,40),
                new Character("アストール",90,35,40,50,20,20,15),
                new Character("リリーナ",45,75,20,35,10,35,50),
                new Character("ウェンディ",85,40,40,40,30,10,45),
                new Character("バース",100,60,25,20,40,2,20),
                new Character("オージェ",85,40,30,45,20,15,55),
                new Character("フィル",75,25,50,55,15,20,50),
                new Character("シン",75,45,50,50,10,15,25),
                new Character("ゴンザレス",90,60,15,50,25,5,35),
                new Character("ギース",85,50,30,40,20,10,40),
                new Character("クレイン",60,35,40,45,15,25,50),
                new Character("ティト",60,40,45,55,15,20,40),
                new Character("ララム",70,10,5,70,20,30,80),
                new Character("エキドナ",75,30,25,30,15,15,20),
                new Character("エルフィン",80,5,5,65,25,55,65),
                new Character("バアトル",70,40,20,30,20,5,20),
                new Character("レイ",55,45,55,40,15,35,15),
                new Character("キャス",80,40,45,85,15,20,50),
                new Character("ミレディ",75,50,50,45,20,5,25),
                new Character("パーシバル",75,30,25,35,20,10,20),
                new Character("セシリア",60,35,45,25,20,25,25),
                new Character("ソフィーヤ",60,55,40,30,20,55,20),
                new Character("イグレーヌ",70,35,25,35,10,5,20),
                new Character("ガレット",70,45,25,25,15,5,15),
                new Character("ファ",130,90,85,65,30,50,150),
                new Character("ヒュウ",75,30,30,45,20,15,25),
                new Character("ツァイス",80,60,50,35,25,5,20),
                new Character("ダグラス",60,30,30,30,30,5,20),
                new Character("ニイメ",25,15,15,15,15,20,5),
                new Character("ダヤン",55,20,20,15,10,10,20),
                new Character("ユーノ",50,20,35,30,10,10,45),
                new Character("ヨーデル",20,30,15,10,10,20,20),
                new Character("カレル",210,130,140,140,110,100,120),
            ];

            m_Characters =
                sacredStoneSeparator
                .Concat(sacredStone1.OrderBy(character => character.Name))
                .Concat(commonSeparator)
                .Concat(sacredStone2)
                .Concat(blazingBladeSeparator)
                .Concat(blazingBlade.OrderBy(character => character.Name))
                .Concat(bindingBladeSeparator)
                .Concat(bindingBlade.OrderBy(character => character.Name))
                .ToArray();
        }
    }
}
