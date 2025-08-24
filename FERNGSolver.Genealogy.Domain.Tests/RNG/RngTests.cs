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

        [TestMethod]
        public void Advance_ShouldSkipValuesCorrectly()
        {
            var expected = new List<int>
            {
                24, 29, 25, 7, 3
            };

            var rng = RngFactory.Create();
            var cloneRng = rng.Clone();

            int count = 1800;

            for (int i = 0; i < 1800; ++i)
            {
                rng.Next();
            }
            cloneRng.Advance(count);

            for (int i = 0; i < 5; i++)
            {
                int actual = rng.Next();
                int target = cloneRng.Next();
                Assert.AreEqual(target, actual, $"Mismatch at index {i}");
                Assert.AreEqual(expected[i], actual, $"Mismatch at index {i}");
                Assert.AreEqual(expected[i], target, $"Mismatch at index {i}");
            }
        }
    }
}
