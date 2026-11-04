using FERNGSolver.Genealogy.Domain.Character;
using FERNGSolver.Genealogy.Domain.Repository.Stub;

namespace FERNGSolver.Genealogy.Domain.Tests.Character;

[TestClass]
public class ChildInheritanceTests
{
    [TestMethod]
    [DataRow("スカサハ", new int[] { 155, 45, 7, 40, 125, 45, 30, 7 })]
    [DataRow("ラクチェ", new int[] { 135, 45, 7, 35, 115, 45, 30, 7 })]
    public void SharedMinorBlood_BecomesMajorWithoutDoubleCountingParentBonuses(string childName, int[] expected)
    {
        var repository = new StubCharacterRepository();
        var childBase = repository.BaseCharacters.Single(character => character.Name == childName);

        var child = repository.GetChild(childBase, "ホリン");

        // Ayra and Holyn both carry minor Od blood. Both children inherit major Od.
        CollectionAssert.AreEqual(expected, GrowthRates(child));
    }

    [TestMethod]
    [DataRow("ファバル", new int[] { 175, 45, 15, 40, 95, 40, 85, 7 })]
    [DataRow("パティ", new int[] { 135, 45, 22, 35, 85, 35, 50, 7 })]
    public void BrigidChildren_ReverseBloodInheritanceButKeepNormalGrowthInheritance(string childName, int[] expected)
    {
        var repository = new StubCharacterRepository();
        var childBase = repository.BaseCharacters.Single(character => character.Name == childName);

        var child = repository.GetChild(childBase, "ホリン");

        // Faval inherits major Ull from Brigid; Patty inherits minor Ull.
        CollectionAssert.AreEqual(expected, GrowthRates(child));
    }

    [TestMethod]
    public void ChangingFather_DoesNotMutatePreviousResultOrBaseCharacters()
    {
        var repository = new StubCharacterRepository();
        var childBase = repository.BaseCharacters.Single(character => character.Name == "スカサハ");
        var mother = repository.BaseCharacters.Single(character => character.Name == "アイラ");
        var originalMotherRates = GrowthRates(mother);
        var first = repository.GetChild(childBase, "ホリン");
        var firstRates = GrowthRates(first);

        var second = repository.GetChild(childBase, "レヴィン");

        CollectionAssert.AreEqual(firstRates, GrowthRates(first));
        CollectionAssert.AreEqual(originalMotherRates, GrowthRates(mother));
        CollectionAssert.AreEqual(new int[8], GrowthRates(childBase));
        Assert.AreNotEqual(first.TecGrowthRate, second.TecGrowthRate);
        Assert.AreEqual(childBase.Name, second.Name);
    }

    private static int[] GrowthRates(ICharacter character) =>
    [
        character.HpGrowthRate, character.StrGrowthRate, character.MgcGrowthRate, character.DefGrowthRate,
        character.TecGrowthRate, character.SpdGrowthRate, character.LucGrowthRate, character.MdfGrowthRate,
    ];
}
