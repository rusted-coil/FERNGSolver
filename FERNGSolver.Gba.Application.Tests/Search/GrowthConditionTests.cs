using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Gba.Application.Search.Strategy;

namespace FERNGSolver.Gba.Application.Tests.Search;

[TestClass]
public class GrowthConditionTests
{
    [DataTestMethod]
    [DataRow(0, false)]
    [DataRow(0, true)]
    [DataRow(1, false)]
    [DataRow(1, true)]
    [DataRow(2, false)]
    [DataRow(2, true)]
    [DataRow(3, false)]
    [DataRow(3, true)]
    [DataRow(4, false)]
    [DataRow(4, true)]
    [DataRow(5, false)]
    [DataRow(5, true)]
    [DataRow(6, false)]
    [DataRow(6, true)]
    public void CheckAndAdvance_AppliesEachConditionToItsOwnStat(int stat, bool grows)
    {
        foreach (var searchType in new[] { GrowthSearchType.MustUp, GrowthSearchType.MustNotUp, GrowthSearchType.NotConsidered, GrowthSearchType.Max })
        {
            var args = new GrowthStrategyArgs
            {
                HpGrowthRate = 50,
                AtkGrowthRate = 50,
                TecGrowthRate = 50,
                SpdGrowthRate = 50,
                DefGrowthRate = 50,
                MdfGrowthRate = 50,
                LucGrowthRate = 50,
            };
            switch (stat)
            {
                case 0: args.HpSearchType = searchType; break;
                case 1: args.AtkSearchType = searchType; break;
                case 2: args.TecSearchType = searchType; break;
                case 3: args.SpdSearchType = searchType; break;
                case 4: args.DefSearchType = searchType; break;
                case 5: args.MdfSearchType = searchType; break;
                case 6: args.LucSearchType = searchType; break;
            }
            // Other stats grow, so no empty-level retry can obscure the selected stat.
            var values = new ushort[7];
            values[stat] = grows ? (ushort)49 : (ushort)50;
            var rng = new SequenceRng(values);
            bool expected = searchType switch
            {
                GrowthSearchType.MustUp => grows,
                GrowthSearchType.MustNotUp => !grows,
                _ => true,
            };

            Assert.AreEqual(expected, StrategyFactory.CreateGrowthStrategy(args).CheckAndAdvance(rng), $"Stat {stat}, condition {searchType}");
            Assert.AreEqual(7, rng.Consumed, "All stats are simulated even when a search condition fails.");
        }
    }

    [TestMethod]
    public void CheckAndAdvance_MustNotUpRejectsGuaranteedGrowth()
    {
        var rng = new SequenceRng(new ushort[7]);
        var strategy = StrategyFactory.CreateGrowthStrategy(new GrowthStrategyArgs
        {
            HpGrowthRate = 100,
            HpSearchType = GrowthSearchType.MustNotUp,
        });

        Assert.IsFalse(strategy.CheckAndAdvance(rng));
        Assert.AreEqual(7, rng.Consumed);
    }

    private sealed class SequenceRng(ushort[] values) : IRng
    {
        public int Consumed { get; private set; }
        public ushort Next()
        {
            Assert.IsTrue(Consumed < values.Length, "The strategy consumed an unexpected random number.");
            return values[Consumed++];
        }
    }
}
