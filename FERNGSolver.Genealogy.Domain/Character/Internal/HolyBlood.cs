namespace FERNGSolver.Genealogy.Domain.Character.Internal
{
    internal class HolyBlood
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
}
