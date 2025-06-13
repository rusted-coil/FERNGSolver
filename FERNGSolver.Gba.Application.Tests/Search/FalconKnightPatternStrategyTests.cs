using FERNGSolver.Common.Application.Search.Strategy;
using FERNGSolver.Gba.Application.Search;
using FERNGSolver.Gba.Application.Search.Strategy;
using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Tests.Search
{
    [TestClass]
    public class FalconKnightPatternStrategyTests
    {
        [TestMethod]
        public void Search_ShouldFindMatchingOffset()
        {
            var rng = RngFactory.CreateDefault();

            // パターンに一致するのは offset = 5 から始まる [xxcccx]
            var pattern = new List<bool> { false, false, true, true, true, false };
            var strategy = CommonStrategyFactory.CreateFalconKnightPatternStrategy(pattern, Util.IsRngValueOk);

            // Act
            var result = Searcher.Search(rng, positionMin: 0, positionMax: 10, strategy: strategy);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 5 }, result.Select(item => item.Position).ToList<int>());
        }

        [TestMethod]
        public void Search_ShouldReturnEmpty_WhenNoMatch()
        {
            var rng = RngFactory.CreateDefault();

            // 不可能なパターン（例えばT,T,T,T,T,T,T,T）
            var pattern = new List<bool> { true, true, true, true, true, true, true, true };
            var strategy = CommonStrategyFactory.CreateFalconKnightPatternStrategy(pattern, Util.IsRngValueOk);

            // Act
            var result = Searcher.Search(rng, 0, 20, strategy);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Search_ShouldNotAdvanceOriginalRng()
        {
            var rng = RngFactory.CreateDefault();
            var before = rng.Clone();

            var pattern = new List<bool> { true };
            var strategy = CommonStrategyFactory.CreateFalconKnightPatternStrategy(pattern, Util.IsRngValueOk);

            // Act
            Searcher.Search(rng, 0, 5, strategy);

            // Assert
            Assert.AreEqual(before.Next(), rng.Next());
        }
    }
}
