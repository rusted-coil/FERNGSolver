using FERNGSolver.Thracia.Domain.RNG;

namespace FERNGSolver.Thracia.Domain.Tests.RNG
{
    [TestClass]
    public class RngTests
    {
        [TestMethod]
        public void Next_ShouldReturnExpectedSequence()
        {
            var rng = RngFactory.Create(30);
            var expected = new List<int>
            {
                56, 64, 02, 44, 92,
                10, 19, 87, 39, 89,
            };

            for (int i = 0; i < expected.Count; i++)
            {
                int actual = rng.Next();
                Assert.AreEqual(expected[i], actual, $"Mismatch at index {i}");
            }
        }

        [TestMethod]
        public void NextTable_ShouldReturnExpectedSequence()
        {
            var rng = RngFactory.Create(30);
            var expected = new List<int>
            {
                00, 41, 54, 16, 49,
                37, 70, 25, 95, 04,
            };

            for (int i = 0; i < 54; ++i)
            {
                rng.Next();
            }

            for (int i = 0; i < expected.Count; i++)
            {
                int actual = rng.Next();
                Assert.AreEqual(expected[i], actual, $"Mismatch at index {i}");
            }
        }

        [TestMethod]
        public void ClonedRng_ShouldProduceSameResults()
        {
            IRng original = RngFactory.Create(7);

            // 適当に進める
            for (int i = 0; i < 50; i++) original.Next();

            // クローンを作成
            IRng clone = RngFactory.CreateFromRng(original);

            for (int i = 0; i < 10; i++)
            {
                int expected = original.Next();
                int actual = clone.Next();
                Assert.AreEqual(expected, actual, $"Mismatch after clone at step {i}");
            }
        }
    }
}
