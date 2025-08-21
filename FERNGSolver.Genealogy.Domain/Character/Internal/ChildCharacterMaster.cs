namespace FERNGSolver.Genealogy.Domain.Character.Internal
{
    // 子世代
    internal class ChildCharacterMaster
    {
        public string Name { get; }
        public string MotherName { get; }
        public IReadOnlyList<string> FatherCandidatesName { get; }
        public bool IsBloodMale { get; }
        public bool IsGrowthMale { get; }

        public ChildCharacterMaster(string name, string motherName, bool isBloodMale, bool isGrowthMale, params string[] fatherCandidatesName)
        {
            Name = name;
            MotherName = motherName;
            FatherCandidatesName = fatherCandidatesName;
            IsBloodMale = isBloodMale;
            IsGrowthMale = isGrowthMale;
        }
    }
}
