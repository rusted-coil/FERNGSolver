using FERNGSolver.Genealogy.Domain.Character;
using FERNGSolver.Genealogy.Domain.Character.Internal;

namespace FERNGSolver.Genealogy.Domain.Repository.Stub
{
    public sealed class StubCharacterRepository : ICharacterRepository
    {
        private readonly HolyBlood[] m_HolyBloods = [
            new HolyBlood("バルド", 20, 10,  0,  0, 10,  0, 10,  0),
            new HolyBlood("オード", 20,  0,  0,  0, 30,  0,  0,  0),
            new HolyBlood("ダイン", 20,  0,  0,  0,  0, 30,  0,  0),
            new HolyBlood("ウル",   20,  0,  0,  0,  0,  0, 30,  0),
            new HolyBlood("ブラギ", 10,  0, 10,  0,  0,  0, 10, 20),
            new HolyBlood("トード", 20,  0,  0,  0, 30,  0,  0,  0),
            new HolyBlood("ファラ", 20,  0, 30,  0,  0,  0,  0,  0),
            new HolyBlood("ヘズル", 20, 30,  0,  0,  0,  0,  0,  0),
            new HolyBlood("ノヴァ", 20, 10,  0, 10,  0, 10,  0,  0),
            new HolyBlood("ネール", 20,  0,  0, 30,  0,  0,  0,  0),
            new HolyBlood("ナーガ", 10,  0, 20,  0,  0,  0,  0, 20),
            new HolyBlood("フォルセティ", 20, 0, 0, 0, 0, 30, 0, 0),
            new HolyBlood("ロプトウス", 10, 0, 20, 0, 0, 0, 0, 20),
        ];

        // 聖戦士の血補正を考慮したキャラデータを計算します。
        private ICharacter CalculateWithHolyBloodsScore(ICharacter character, IReadOnlyDictionary<string, int> holyBloodsScore)
        {
            var child = new Character.Internal.Character(
                character.Name,
                character.HpGrowthRate,
                character.StrGrowthRate,
                character.MgcGrowthRate,
                character.DefGrowthRate,
                character.TecGrowthRate,
                character.SpdGrowthRate,
                character.LucGrowthRate,
                character.MdfGrowthRate);

            foreach (var blood in m_HolyBloods)
            {
                if (holyBloodsScore.ContainsKey(blood.Name))
                {
                    int multiplier = Math.Min(2, (holyBloodsScore[blood.Name] + 1) / 2);
                    child.HpGrowthRate += blood.HpGrowthRate * multiplier;
                    child.StrGrowthRate += blood.StrGrowthRate * multiplier;
                    child.MgcGrowthRate += blood.MgcGrowthRate * multiplier;
                    child.DefGrowthRate += blood.DefGrowthRate * multiplier;
                    child.TecGrowthRate += blood.TecGrowthRate * multiplier;
                    child.SpdGrowthRate += blood.SpdGrowthRate * multiplier;
                    child.LucGrowthRate += blood.LucGrowthRate * multiplier;
                    child.MdfGrowthRate += blood.MdfGrowthRate * multiplier;
                }
            }

            return child;
        }

        private int Inherit(bool isMale, int mother, int father) => isMale ? father + mother / 2 : father / 2 + mother;

        // 2人の両親から生まれる子供のデータを生成します。
        private ICharacter GetChild(string name, bool isBloodMale, bool isGrowthMale, FixedCharacterMaster mother, FixedCharacterMaster father)
        {
            // 血の遺伝について
            // 親世代は直系=4、傍系=2とする。
            // 同性の子供に100%、異性の子供に50%を加算する。（ただしパティとファバルのみ男女逆として扱う）
            // 子世代のスコアが1～2の時傍系、3以上の時直系とする。

            var childHolyBloods = new Dictionary<string, int>();
            foreach (var parentBlood in mother.HolyBloodsScore)
            {
                if (!childHolyBloods.ContainsKey(parentBlood.Key))
                {
                    childHolyBloods.Add(parentBlood.Key, 0);
                }
                childHolyBloods[parentBlood.Key] += Inherit(isBloodMale, parentBlood.Value, 0);
            }
            foreach (var parentBlood in father.HolyBloodsScore)
            {
                if (!childHolyBloods.ContainsKey(parentBlood.Key))
                {
                    childHolyBloods.Add(parentBlood.Key, 0);
                }
                childHolyBloods[parentBlood.Key] += Inherit(isBloodMale, 0, parentBlood.Value);
            }

            var childBase = new Character.Internal.Character(
                name,
                Inherit(isGrowthMale, mother.HpGrowthRate, father.HpGrowthRate),
                Inherit(isGrowthMale, mother.StrGrowthRate, father.StrGrowthRate),
                Inherit(isGrowthMale, mother.MgcGrowthRate, father.MgcGrowthRate),
                Inherit(isGrowthMale, mother.DefGrowthRate, father.DefGrowthRate),
                Inherit(isGrowthMale, mother.TecGrowthRate, father.TecGrowthRate),
                Inherit(isGrowthMale, mother.SpdGrowthRate, father.SpdGrowthRate),
                Inherit(isGrowthMale, mother.LucGrowthRate, father.LucGrowthRate),
                Inherit(isGrowthMale, mother.MdfGrowthRate, father.MdfGrowthRate));

            return CalculateWithHolyBloodsScore(childBase, childHolyBloods);
        }

        private Dictionary<string, FixedCharacterMaster> m_FixedCharacters = new Dictionary<string, FixedCharacterMaster>();
        private Dictionary<string, ChildCharacterMaster> m_ChildCharacters = new Dictionary<string, ChildCharacterMaster>();
        private ICharacter AddFixedCharacter(FixedCharacterMaster master)
        {
            m_FixedCharacters.Add(master.Name, master);
            return CalculateWithHolyBloodsScore(master, master.HolyBloodsScore);
        }
        private ICharacter AddChildCharacter(ChildCharacterMaster master)
        {
            m_ChildCharacters.Add(master.Name, master);
            return new Character.Internal.Character(master.Name, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        public StubCharacterRepository()
        {
            string[] fatherCandidates = [
                "ノイッシュ", "アレク", "アーダン", "フィン", "ミデェール", "レヴィン", "ホリン",
                "アゼル", "ジャムカ", "クロード", "ベオウルフ", "レックス", "デュー",
            ];
            ICharacter[] parents = [
                AddFixedCharacter(new FixedCharacterMaster("シグルド", 70, 30, 5, 40, 30, 30, 20, 5, ("バルド", 4))),
                AddFixedCharacter(new FixedCharacterMaster("ノイッシュ", 80, 40, 5, 40, 30, 20, 20, 5)),
                AddFixedCharacter(new FixedCharacterMaster("アレク", 70, 30, 5, 30, 40, 30, 30, 5)),
                AddFixedCharacter(new FixedCharacterMaster("アーダン", 90, 50, 5, 40, 10, 20, 10, 5)),
                AddFixedCharacter(new FixedCharacterMaster("アゼル", 50, 10, 10, 20, 20, 50, 20, 10, ("ファラ", 2))),
                AddFixedCharacter(new FixedCharacterMaster("レックス", 70, 40, 5, 20, 20, 20, 20, 5, ("ネール", 2))),
                AddFixedCharacter(new FixedCharacterMaster("キュアン", 70, 30, 5, 30, 30, 20, 10, 5, ("ノヴァ", 4))),
                AddFixedCharacter(new FixedCharacterMaster("エスリン", 40, 20, 5, 20, 20, 30, 10, 10, ("バルド", 2))),
                AddFixedCharacter(new FixedCharacterMaster("フィン", 70, 30, 5, 30, 40, 30, 50, 5)),
                AddFixedCharacter(new FixedCharacterMaster("ミデェール", 60, 30, 5, 30, 30, 40, 10, 5)),
                AddFixedCharacter(new FixedCharacterMaster("エーディン", 50, 20, 30, 20, 20, 30, 30, 5, ("ウル", 2))),
                AddFixedCharacter(new FixedCharacterMaster("デュー", 50, 40, 10, 40, 40, 40, 40, 10)),
                AddFixedCharacter(new FixedCharacterMaster("アイラ", 50, 30, 5, 20, 30, 30, 20, 5, ("オード", 2))),
                AddFixedCharacter(new FixedCharacterMaster("ジャムカ", 90, 50, 0, 30, 10, 30, 40, 5)),
                AddFixedCharacter(new FixedCharacterMaster("ディアドラ", 40, 10, 10, 10, 20, 10, 10, 10, ("ナーガ", 4), ("ロプトウス", 2))),
                AddFixedCharacter(new FixedCharacterMaster("ホリン", 90, 30, 5, 30, 50, 30, 20, 5, ("オード", 2))),
                AddFixedCharacter(new FixedCharacterMaster("ラケシス", 40, 20, 5, 20, 10, 20, 40, 10, ("ヘズル", 2))),
                AddFixedCharacter(new FixedCharacterMaster("レヴィン", 50, 10, 30, 20, 40, 30, 20, 10, ("セティ", 4))),
                AddFixedCharacter(new FixedCharacterMaster("シルヴィア", 40, 10, 20, 10, 10, 10, 20, 20, ("ブラギ", 2))),
                AddFixedCharacter(new FixedCharacterMaster("ベオウルフ", 80, 40, 0, 30, 40, 30, 20, 5)),
                AddFixedCharacter(new FixedCharacterMaster("フュリー", 50, 20, 10, 30, 20, 30, 20, 10)),
                AddFixedCharacter(new FixedCharacterMaster("クロード", 50, 10, 20, 20, 20, 30, 30, 10, ("ブラギ", 4))),
                AddFixedCharacter(new FixedCharacterMaster("ティルテュ", 40, 10, 20, 10, 30, 40, 50, 10, ("トード", 2))),
                AddFixedCharacter(new FixedCharacterMaster("ブリギッド", 50, 30, 20, 20, 30, 20, 10, 5, ("ウル", 4))),
            ];
            ICharacter[] children = [
                // 子世代の固定成長率データは血統ボーナスを反映したもの
                AddFixedCharacter(new FixedCharacterMaster("セリス",140,55,30,45,60,35,45,30)),
                AddFixedCharacter(new FixedCharacterMaster("オイフェ",100,40,5,30,50,30,40,10)),
                AddFixedCharacter(new FixedCharacterMaster("ユリア",90,10,100,10,20,30,30,50)),
                AddFixedCharacter(new FixedCharacterMaster("ヨハルヴァ",110,40,0,60,50,10,10,5)),
                AddFixedCharacter(new FixedCharacterMaster("ヨハン",110,40,5,60,20,50,10,5)),
                AddFixedCharacter(new FixedCharacterMaster("シャナン",120,30,5,40,80,20,20,5)),
                AddFixedCharacter(new FixedCharacterMaster("アレス",130,90,5,40,20,30,50,30)),
                AddFixedCharacter(new FixedCharacterMaster("リーフ",130,60,7,50,50,45,25,10)),
                AddFixedCharacter(new FixedCharacterMaster("ハンニバル",60,50,5,30,10,10,10,5)),
                AddFixedCharacter(new FixedCharacterMaster("アルテナ",135,65,7,55,45,60,25,12)),
                AddChildCharacter(new ChildCharacterMaster("デルムッド", "ラケシス", true, true, fatherCandidates)),
                AddChildCharacter(new ChildCharacterMaster("ナンナ", "ラケシス", false, false, fatherCandidates)),
                AddChildCharacter(new ChildCharacterMaster("スカサハ", "アイラ", true, true, fatherCandidates)),
                AddChildCharacter(new ChildCharacterMaster("ラクチェ", "アイラ", false, false, fatherCandidates)),
                AddChildCharacter(new ChildCharacterMaster("セティ", "フュリー", true, true, fatherCandidates)),
                AddChildCharacter(new ChildCharacterMaster("フィー", "フュリー", false, false, fatherCandidates)),
                AddChildCharacter(new ChildCharacterMaster("アーサー", "ティルテュ", true, true, fatherCandidates)),
                AddChildCharacter(new ChildCharacterMaster("ティニー", "ティルテュ", false, false, fatherCandidates)),
                AddChildCharacter(new ChildCharacterMaster("コープル", "シルヴィア", true, true, fatherCandidates)),
                AddChildCharacter(new ChildCharacterMaster("リーン", "シルヴィア", false, false, fatherCandidates)),
                AddChildCharacter(new ChildCharacterMaster("レスター", "エーディン", true, true, fatherCandidates)),
                AddChildCharacter(new ChildCharacterMaster("ラナ", "エーディン", false, false, fatherCandidates)),
                AddChildCharacter(new ChildCharacterMaster("ファバル", "ブリギッド", false, true, fatherCandidates)), // ファバルとパティは血統のみ遺伝計算上の性別が逆になっている
                AddChildCharacter(new ChildCharacterMaster("パティ", "ブリギッド", true, false, fatherCandidates)),
            ];
            ICharacter[] alter = [
                AddFixedCharacter(new FixedCharacterMaster("マナ",50,10,30,10,20,20,40,20)),
                AddFixedCharacter(new FixedCharacterMaster("ラドネイ",70,40,5,30,30,40,20,20)),
                AddFixedCharacter(new FixedCharacterMaster("ロドルバン",80,30,5,30,50,30,20,5)),
                AddFixedCharacter(new FixedCharacterMaster("ディムナ",90,30,5,40,50,20,30,5)),
                AddFixedCharacter(new FixedCharacterMaster("トリスタン",130,30,5,30,30,20,10,5)),
                AddFixedCharacter(new FixedCharacterMaster("アミッド",90,20,40,20,50,40,20,20)),
                AddFixedCharacter(new FixedCharacterMaster("フェミナ",60,30,10,20,20,50,50,5)),
                AddFixedCharacter(new FixedCharacterMaster("デイジー",50,10,10,20,30,50,30,10)),
                AddFixedCharacter(new FixedCharacterMaster("レイリア",50,50,10,20,20,40,30,20)),
                AddFixedCharacter(new FixedCharacterMaster("ジャンヌ",60,20,20,30,50,20,10,20)),
                AddFixedCharacter(new FixedCharacterMaster("リンダ",90,10,40,10,40,30,20,20)),
                AddFixedCharacter(new FixedCharacterMaster("アサエロ",90,40,5,30,10,20,60,5)),
                AddFixedCharacter(new FixedCharacterMaster("ホーク",60,10,20,20,20,50,20,10)),
                AddFixedCharacter(new FixedCharacterMaster("シャルロー",70,10,50,10,20,20,30,30)),
            ];

            BaseCharacters =
                new ICharacter[] { new Character.Internal.Character("――【親世代】――", -1, -1, -1, -1, -1, -1, -1, -1) }
                .Concat(parents.OrderBy(character => character.Name))
                .Concat([ new Character.Internal.Character("――【子世代】――", -1, -1, -1, -1, -1, -1, -1, -1) ])
                .Concat(children.OrderBy(character => character.Name))
                .Concat([ new Character.Internal.Character("――【代替】――", -1, -1, -1, -1, -1, -1, -1, -1) ])
                .Concat(alter.OrderBy(character => character.Name))
                .ToArray();
        }

        public IReadOnlyList<ICharacter> BaseCharacters { get; }

        public IReadOnlyList<string> GetFatherCandidates(ICharacter child)
        {
            if (m_ChildCharacters.TryGetValue(child.Name, out var childMaster))
            {
                return childMaster.FatherCandidatesName;
            }
            return Array.Empty<string>();
        }

        public ICharacter GetChild(ICharacter childBase, string fatherName)
        {
            if (m_ChildCharacters.TryGetValue(childBase.Name, out var childMaster) &&
                m_FixedCharacters.TryGetValue(fatherName, out var fatherMaster) &&
                m_FixedCharacters.TryGetValue(childMaster.MotherName, out var motherMaster))
            {
                return GetChild(childMaster.Name, childMaster.IsBloodMale, childMaster.IsGrowthMale, motherMaster, fatherMaster);
            }
            throw new KeyNotFoundException($"キャラクター '{childBase.Name}' または '{fatherName}' が見つかりません。");
        }
    }
}
