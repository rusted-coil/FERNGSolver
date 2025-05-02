using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Domain.Tests.RNG
{
    [TestClass]
    public class RngTests
    {
        [TestMethod]
        public void Next_ShouldReturnExpectedSequence()
        {
            var rng = RngFactory.CreateDefault();
            var expected = new List<int>
            {
                47, 66, 60, 46, 77,
                70, 61, 29, 19, 26,
            };

            for (int i = 0; i < expected.Count; i++)
            {
                int actual = rng.Next();
                Assert.AreEqual(expected[i], actual, $"Mismatch at index {i}");
            }
        }

        [TestMethod]
        public void ClonedRng_ShouldProduceSameResults()
        {
            IRng original = RngFactory.CreateDefault();

            // 適当に進める
            for (int i = 0; i < 5; i++) original.Next();

            // クローンを作成
            var states = original.States;
            IRng clone = RngFactory.CreateFromSeeds(states[0], states[1], states[2]);

            for (int i = 0; i < 5; i++)
            {
                int expected = original.Next();
                int actual = clone.Next();
                Assert.AreEqual(expected, actual, $"Mismatch after clone at step {i}");
            }
        }
    }
}
