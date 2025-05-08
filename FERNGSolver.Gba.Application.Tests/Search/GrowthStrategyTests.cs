using FERNGSolver.Gba.Application.Search.Strategy;
using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.Tests.Search
{
    [TestClass]
    public class GrowthStrategyTests
    {
        [TestMethod]
        public void CheckTest()
        {
            IRng rng = RngFactory.CreateDefault();

            var strategy = StrategyFactory.CreateGrowthStrategy(new GrowthStrategyArgs {
                HpGrowthRate = 70,
                AtkGrowthRate = 40,
                TecGrowthRate = 60,
                SpdGrowthRate = 60,
                DefGrowthRate = 30,
                MdfGrowthRate = 30,
                LucGrowthRate = 60,
            });

            // Act
            for (int i = 0; i < 260; ++i)
            {
                rng.Next();
            }
            var result = strategy.Check(rng, true);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
