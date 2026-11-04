using FERNGSolver.Genealogy.Domain.Repository.Stub;

namespace FERNGSolver.Genealogy.Domain.Tests.Character
{
    [TestClass]
    public class HolyBloodGrowthTests
    {
        [TestMethod]
        public void LewynReceivesMajorCedBloodGrowthBonuses()
        {
            var lewyn = new StubCharacterRepository().BaseCharacters.Single(character => character.Name == "レヴィン");

            Assert.AreEqual(90, lewyn.HpGrowthRate);
            Assert.AreEqual(90, lewyn.SpdGrowthRate);
            Assert.AreEqual(30, lewyn.MgcGrowthRate);
        }

        [TestMethod]
        [DataRow("セティ", 115, 105)]
        [DataRow("フィー", 95, 75)]
        public void LewynChildrenReceiveMajorOrMinorBloodBonuses(string name, int hpRate, int speedRate)
        {
            var repository = new StubCharacterRepository();
            var child = repository.GetChild(repository.BaseCharacters.Single(character => character.Name == name), "レヴィン");

            Assert.AreEqual(hpRate, child.HpGrowthRate);
            Assert.AreEqual(speedRate, child.SpdGrowthRate);
        }
    }
}
