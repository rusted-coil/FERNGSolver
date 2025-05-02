using FERNGSolver.Gba.Domain.FalconKnight;
using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Domain.Tests.FalconKnight
{
    [TestClass]
    public class PatternSearcherTests
    {
        [TestMethod]
        public void Search_ShouldFindMatchingOffset()
        {
            IRng rng = RngFactory.CreateDefault();

            // パターンに一致するのは offset = 5 から始まる [xxcccx]
            var pattern = new List<bool> { false, false, true, true, true, false };

            // Act
            var result = PatternSearcher.Search(rng, offsetMin: 0, offsetMax: 10, falconKnightPattern: pattern);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 5 }, (List<int>)result);
        }

        [TestMethod]
        public void Search_ShouldReturnEmpty_WhenNoMatch()
        {
            IRng rng = RngFactory.CreateDefault();

            // 不可能なパターン（例えばT,T,T,T,T,T,T,T）
            var pattern = new List<bool> { true, true, true, true, true, true, true, true };

            // Act
            var result = PatternSearcher.Search(rng, 0, 20, pattern);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Search_ShouldNotAdvanceOriginalRng()
        {
            IRng rng = RngFactory.CreateDefault();
            var before = rng.States.ToArray();

            var pattern = new List<bool> { true };

            // Act
            PatternSearcher.Search(rng, 0, 5, pattern);

            // Assert
            CollectionAssert.AreEqual(before, rng.States.ToArray());
        }
    }
}
