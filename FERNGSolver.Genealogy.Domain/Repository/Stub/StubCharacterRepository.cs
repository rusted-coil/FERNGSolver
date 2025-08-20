using FERNGSolver.Genealogy.Domain.Character;

namespace FERNGSolver.Genealogy.Domain.Repository.Stub
{
    public sealed class StubCharacterRepository : ICharacterRepository
    {
        class HolyBlood
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

            public HolyBlood(string name, int hp, int str, int mgc, int def, int tec, int spd, int luc, int mdf)
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

        private readonly HolyBlood[] m_HolyBloods = [
            new HolyBlood("バルド", 20, 10,  0,  0, 10,  0, 10,  0),
            new HolyBlood("オード", 20,  0,  0,  0, 30,  0,  0,  0),
            new HolyBlood("ダイン", 20,  0,  0,  0,  0, 30,  0,  0),
            new HolyBlood("ウル",   20,  0,  0,  0,  0, 30,  0,  0),
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

        class Character : ICharacter
        {
            public string Name { get; }
            public int HpGrowthRate { get; set; } = 0;
            public int StrGrowthRate { get; set; } = 0;
            public int MgcGrowthRate { get; set; } = 0;
            public int DefGrowthRate { get; set; } = 0;
            public int TecGrowthRate { get; set; } = 0;
            public int SpdGrowthRate { get; set; } = 0;
            public int LucGrowthRate { get; set; } = 0;
            public int MdfGrowthRate { get; set; } = 0;

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

        // 親世代、固定キャラ
        class FixedCharacterMaster : ICharacter
        {
            public string Name { get; }

            // 成長率は聖戦士補正加算前の値を保持
            public int HpGrowthRate { get; }
            public int StrGrowthRate { get; }
            public int MgcGrowthRate { get; }
            public int DefGrowthRate { get; }
            public int TecGrowthRate { get; }
            public int SpdGrowthRate { get; }
            public int LucGrowthRate { get; }
            public int MdfGrowthRate { get; }

            public IReadOnlyDictionary<string, int> HolyBloodsScore { get; }

            public FixedCharacterMaster(string name, int hp, int str, int mgc, int def, int tec, int spd, int luc, int mdf,
                params (string, int)[] holyBloodsScore)
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
                HolyBloodsScore = holyBloodsScore != null ? holyBloodsScore.ToDictionary() : new Dictionary<string, int>();
            }
        }

        // 子世代
        class ChildCharacterMaster
        {
            public string Name { get; }
            public string MotherName { get; }
            public IReadOnlyList<string> FatherCandidatesName { get; }
            public bool IsMale { get; }

            public ChildCharacterMaster(string name, string motherName, bool isMale, params string[] fatherCandidatesName)
            {
                Name = name;
                MotherName = motherName;
                FatherCandidatesName = fatherCandidatesName;
                IsMale = isMale;
            }
        }

        // 聖戦士の血補正を考慮したキャラデータを計算します。
        private ICharacter CalculateWithHolyBloodsScore(ICharacter character, IReadOnlyDictionary<string, int> holyBloodsScore)
        {
            var child = new Character(
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
                    int multiplier = holyBloodsScore[blood.Name] >= 4 ? 2 : 1;
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
        private ICharacter GetChild(string name, bool isMale, FixedCharacterMaster mother, FixedCharacterMaster father)
        {
            // 血の遺伝について
            // 親世代は直系=4、傍系=2とする。
            // 同性の子供に100%、異性の子供に50%を加算する。（ただしパティとファバルのみ男女逆として扱う）
            // 子世代のスコアが1～3の時傍系、4以上の時直系とする。

            var childHolyBloods = new Dictionary<string, int>();
            foreach (var parentBlood in mother.HolyBloodsScore)
            {
                if (!childHolyBloods.ContainsKey(parentBlood.Key))
                {
                    childHolyBloods.Add(parentBlood.Key, 0);
                }
                childHolyBloods[parentBlood.Key] += Inherit(isMale, parentBlood.Value, 0);
            }
            foreach (var parentBlood in father.HolyBloodsScore)
            {
                if (!childHolyBloods.ContainsKey(parentBlood.Key))
                {
                    childHolyBloods.Add(parentBlood.Key, 0);
                }
                childHolyBloods[parentBlood.Key] += Inherit(isMale, 0, parentBlood.Value);
            }

            var childBase = new Character(
                name,
                Inherit(isMale, mother.HpGrowthRate, father.HpGrowthRate),
                Inherit(isMale, mother.StrGrowthRate, father.StrGrowthRate),
                Inherit(isMale, mother.MgcGrowthRate, father.MgcGrowthRate),
                Inherit(isMale, mother.DefGrowthRate, father.DefGrowthRate),
                Inherit(isMale, mother.TecGrowthRate, father.TecGrowthRate),
                Inherit(isMale, mother.SpdGrowthRate, father.SpdGrowthRate),
                Inherit(isMale, mother.LucGrowthRate, father.LucGrowthRate),
                Inherit(isMale, mother.MdfGrowthRate, father.MdfGrowthRate));

            return CalculateWithHolyBloodsScore(childBase, childHolyBloods);
        }

        private Dictionary<string, FixedCharacterMaster> m_FixedCharacters = new Dictionary<string, FixedCharacterMaster>();
        private Dictionary<string, ChildCharacterMaster> m_ChildCharacters = new Dictionary<string, ChildCharacterMaster>();
        private void AddFixedCharacter(FixedCharacterMaster master) => m_FixedCharacters.Add(master.Name, master);
        private void AddChildCharacter(ChildCharacterMaster master) => m_ChildCharacters.Add(master.Name, master);

        public StubCharacterRepository()
        {
            AddFixedCharacter(new FixedCharacterMaster("シグルド", 70, 30, 5, 40, 30, 30, 20, 5, ("バルド", 4)));
            AddFixedCharacter(new FixedCharacterMaster("ノイッシュ", 80, 40, 5, 40, 30, 20, 20, 5));
            AddFixedCharacter(new FixedCharacterMaster("アレク", 70, 30, 5, 30, 40, 30, 30, 5));
            AddFixedCharacter(new FixedCharacterMaster("アーダン", 90, 50, 5, 40, 10, 20, 10, 5));
            AddFixedCharacter(new FixedCharacterMaster("レックス", 90, 40, 5, 50, 20, 20, 20, 5));
            AddFixedCharacter(new FixedCharacterMaster("キュアン", 110, 50, 5, 50, 30, 40, 10, 5));
            AddFixedCharacter(new FixedCharacterMaster("エスリン", 60, 30, 5, 20, 30, 30, 20, 10));
            AddFixedCharacter(new FixedCharacterMaster("フィン", 70, 30, 5, 30, 40, 30, 50, 5));
            AddFixedCharacter(new FixedCharacterMaster("ミデェール", 60, 30, 5, 30, 30, 40, 10, 5));
        }

        public IReadOnlyList<ICharacter> BaseCharacters => m_FixedCharacters.Values.Select(master => CalculateWithHolyBloodsScore(master, master.HolyBloodsScore)).ToArray();


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
                return GetChild(childMaster.Name, childMaster.IsMale, motherMaster, fatherMaster);
            }
            throw new KeyNotFoundException($"キャラクター '{childBase.Name}' または '{fatherName}' が見つかりません。");
        }


        public IReadOnlyList<ICharacter> AllCharacters => m_FixedCharacters.Values.Select(master => CalculateWithHolyBloodsScore(master, master.HolyBloodsScore)).ToArray();

    }
}
