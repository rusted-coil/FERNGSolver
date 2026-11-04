using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Domain.Tests.RNG
{
    [TestClass]
    public class RngTests
    {
        [TestMethod]
        public void Next_ShouldReturnExpectedSequence()
        {
            var rng = RngFactory.CreateDefault(isBindingBlade: false);
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
        [DataRow(false)]
        [DataRow(true)]
        public void ClonedRng_ShouldProduceSameResults(bool isBindingBlade)
        {
            var original = RngFactory.CreateDefault(isBindingBlade);

            // 適当に進める
            for (int i = 0; i < 5; i++) original.Next();

            // クローンを作成
            var clone = original.Clone();

            for (int i = 0; i < 5; i++)
            {
                int expected = original.Next();
                int actual = clone.Next();
                Assert.AreEqual(expected, actual, $"Mismatch after clone at step {i}");
            }
        }

        [TestMethod]
        [DataRow(false, 99)]
        [DataRow(true, 100)]
        public void ClonedRng_ShouldPreserveTitleSpecificConversion(bool isBindingBlade, int expected)
        {
            // 次の内部乱数が65535になる状態。封印と烈火・聖魔で変換結果が異なる。
            var original = RngFactory.CreateFromSeeds(65504, 31, 0, isBindingBlade);
            var clone = original.Clone();

            Assert.AreEqual(expected, (int)original.Next());
            Assert.AreEqual(expected, (int)clone.Next());
        }
    }
}
