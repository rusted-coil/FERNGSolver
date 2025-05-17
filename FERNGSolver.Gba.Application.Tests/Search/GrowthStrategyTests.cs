using FERNGSolver.Gba.Application.Search.Strategy;
using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Tests.Search
{
    [TestClass]
    public class GrowthStrategyTests
    {
        [TestMethod]
        [DataRow(260, false)]
        [DataRow(643, true)]
        [DataRow(756, true)]
        public void Check_ShouldReturnExpectedResult(int offset, bool expected)
        {
            IRng rng = RngFactory.CreateDefault();

            var strategy = StrategyFactory.CreateGrowthStrategy(new GrowthStrategyArgs
            {
                HpGrowthRate = 70,
                AtkGrowthRate = 40,
                TecGrowthRate = 60,
                SpdGrowthRate = 60,
                DefGrowthRate = 30,
                MdfGrowthRate = 30,
                LucGrowthRate = 60,
                HpSearchType = GrowthSearchType.MustUp,
                AtkSearchType = GrowthSearchType.MustUp,
                TecSearchType = GrowthSearchType.MustUp,
                SpdSearchType = GrowthSearchType.MustUp,
                DefSearchType = GrowthSearchType.MustUp,
                MdfSearchType = GrowthSearchType.MustUp,
                LucSearchType = GrowthSearchType.MustUp,
            });

            // Act
            rng.Advance(offset);
            var result = strategy.CheckAndAdvance(rng);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(260, false)]
        [DataRow(261, true)]
        [DataRow(420, false)]
        [DataRow(643, true)]
        [DataRow(756, true)]
        public void Check_WithFilterSkip_ShouldReturnExpectedResult(int offset, bool expected)
        {
            IRng rng = RngFactory.CreateDefault();

            var strategy = StrategyFactory.CreateGrowthStrategy(new GrowthStrategyArgs
            {
                HpGrowthRate = 70,
                AtkGrowthRate = 40,
                TecGrowthRate = 60,
                SpdGrowthRate = 60,
                DefGrowthRate = 30,
                MdfGrowthRate = 30,
                LucGrowthRate = 60,
                HpSearchType = GrowthSearchType.MustUp,
                AtkSearchType = GrowthSearchType.MustUp,
                TecSearchType = GrowthSearchType.MustUp,
                SpdSearchType = GrowthSearchType.MustUp,
                DefSearchType = GrowthSearchType.MustUp,
                MdfSearchType = GrowthSearchType.NotConsidered,
                LucSearchType = GrowthSearchType.MustUp,
            });

            // Act
            rng.Advance(offset);
            var result = strategy.CheckAndAdvance(rng);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(260, false)]
        [DataRow(643, true)]
        [DataRow(756, true)]
        public void Check_OverHundred_ShouldReturnExpectedResult(int offset, bool expected)
        {
            IRng rng = RngFactory.CreateDefault();

            var strategy = StrategyFactory.CreateGrowthStrategy(new GrowthStrategyArgs
            {
                HpGrowthRate = 170,
                AtkGrowthRate = 140,
                TecGrowthRate = 160,
                SpdGrowthRate = 160,
                DefGrowthRate = 130,
                MdfGrowthRate = 130,
                LucGrowthRate = 160,
                HpSearchType = GrowthSearchType.MustUp,
                AtkSearchType = GrowthSearchType.MustUp,
                TecSearchType = GrowthSearchType.MustUp,
                SpdSearchType = GrowthSearchType.MustUp,
                DefSearchType = GrowthSearchType.MustUp,
                MdfSearchType = GrowthSearchType.MustUp,
                LucSearchType = GrowthSearchType.MustUp,
            });

            // Act
            rng.Advance(offset);
            var result = strategy.CheckAndAdvance(rng);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
