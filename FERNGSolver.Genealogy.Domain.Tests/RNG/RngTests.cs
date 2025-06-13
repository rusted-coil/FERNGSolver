using FERNGSolver.Genealogy.Domain.RNG;

namespace FERNGSolver.Genealogy.Domain.Tests.RNG
{
    [TestClass]
    public class RngTests
    {
        [TestMethod]
        public void NextTable_ShouldReturnExpectedSequence()
        {
            var rng = RngFactory.Create();
            var expected = new List<int>
            {
                10, 61, 34, 6, 19,
                57, 0, 95, 65, 64,
            };

            rng.Advance(54);

            for (int i = 0; i < expected.Count; i++)
            {
                int actual = rng.Next();
                Assert.AreEqual(expected[i], actual, $"Mismatch at index {i}");
            }
        }
    }
}
