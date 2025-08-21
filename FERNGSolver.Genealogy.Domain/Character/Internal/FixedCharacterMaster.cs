namespace FERNGSolver.Genealogy.Domain.Character.Internal
{
    // 親世代、固定キャラ
    internal class FixedCharacterMaster : ICharacter
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
}
