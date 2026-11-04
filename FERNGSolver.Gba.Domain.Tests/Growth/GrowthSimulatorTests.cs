using FERNGSolver.Gba.Domain.Growth;

namespace FERNGSolver.Gba.Domain.Tests.Growth;

[TestClass]
public class GrowthSimulatorTests
{
    [TestMethod]
    public void Simulate_UsesStrictThresholdsAndGuaranteedGrowth_ConsumingOneNumberPerStat()
    {
        var rng = new SequenceRng(0, 49, 50, 99, 0, 49, 50);

        var result = GrowthSimulator.Simulate(rng, 0, 50, 50, 100, 200, 250, 250);

        CollectionAssert.AreEqual(new[] { 0, 1, 0, 1, 2, 3, 2 }, result.ToArray());
        Assert.AreEqual(7, rng.Consumed);
    }

    [TestMethod]
    public void Simulate_WhenFirstAttemptIsEmpty_RerollsEveryStatAndStopsAtFirstGrowth()
    {
        var rng = new SequenceRng(99, 99, 49, 99);

        var result = GrowthSimulator.Simulate(rng, 50, 50);

        CollectionAssert.AreEqual(new[] { 1, 0 }, result.ToArray());
        Assert.AreEqual(4, rng.Consumed);
    }

    [TestMethod]
    public void Simulate_WhenFirstTwoAttemptsAreEmpty_UsesThirdAttempt()
    {
        var rng = new SequenceRng(99, 99, 99, 99, 99, 49);

        var result = GrowthSimulator.Simulate(rng, 50, 50);

        CollectionAssert.AreEqual(new[] { 0, 1 }, result.ToArray());
        Assert.AreEqual(6, rng.Consumed);
    }

    [TestMethod]
    public void Simulate_WhenAllAttemptsAreEmpty_StopsAfterTwoRetries()
    {
        var rng = new SequenceRng(0, 0, 0, 0, 0, 0);

        var result = GrowthSimulator.Simulate(rng, 0, 0);

        CollectionAssert.AreEqual(new[] { 0, 0 }, result.ToArray());
        Assert.AreEqual(6, rng.Consumed);
    }

    [TestMethod]
    public void Simulate_WithNoStats_ReturnsEmptyWithoutConsumingRandomNumbers()
    {
        var rng = new SequenceRng();

        Assert.AreEqual(0, GrowthSimulator.Simulate(rng).Count);
        Assert.AreEqual(0, rng.Consumed);
    }
}
