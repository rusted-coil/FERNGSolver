namespace FERNGSolver.Genealogy.Domain.Character.Internal
{
    internal class Character : ICharacter
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
}
