using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Genealogy.Domain.Growth;

namespace FERNGSolver.Genealogy.Domain.Tests.Growth;

[TestClass]
public class GrowthSimulatorTests
{
    [TestMethod]
    [DataRow(0, 0, 0)]
    [DataRow(1, 0, 1)]
    [DataRow(1, 1, 0)]
    [DataRow(99, 98, 1)]
    [DataRow(99, 99, 0)]
    [DataRow(100, 0, 1)]
    [DataRow(100, 99, 1)]
    [DataRow(101, 0, 2)]
    [DataRow(101, 1, 1)]
    [DataRow(250, 49, 3)]
    [DataRow(250, 50, 2)]
    [DataRow(300, 99, 3)]
    public void Simulate_CombinesGuaranteedGrowthWithStrictRemainderThreshold(int rate, int value, int expected)
    {
        var rng = new SequenceRng((ushort)value);

        CollectionAssert.AreEqual(new[] { expected }, GrowthSimulator.Simulate(rng, rate).ToArray());
        Assert.AreEqual(1, rng.Calls, "Zero and guaranteed growth still consume one random number.");
    }

    [TestMethod]
    public void Simulate_PreservesStatOrderAndConsumesOneValuePerStat()
    {
        var rng = new SequenceRng(20, 90, 0, 99);

        CollectionAssert.AreEqual(new[] { 1, 0, 0, 2 }, GrowthSimulator.Simulate(rng, 25, 90, 0, 200).ToArray());
        Assert.AreEqual(4, rng.Calls);
    }

    [TestMethod]
    public void Simulate_AllFailedGrowthDoesNotReroll()
    {
        var rng = new SequenceRng(99, 99, 99, 99, 99, 99, 99, 99);

        CollectionAssert.AreEqual(new int[8], GrowthSimulator.Simulate(rng, 50, 50, 50, 50, 50, 50, 50, 50).ToArray());
        Assert.AreEqual(8, rng.Calls);
    }

    [TestMethod]
    public void Simulate_NoStatsDoesNotConsumeRng()
    {
        var rng = new SequenceRng();

        Assert.AreEqual(0, GrowthSimulator.Simulate(rng).Count);
        Assert.AreEqual(0, rng.Calls);
    }

    private sealed class SequenceRng(params ushort[] values) : IRng
    {
        public int Calls { get; private set; }

        public ushort Next()
        {
            Assert.IsTrue(Calls < values.Length, "Unexpected additional random number consumption.");
            return values[Calls++];
        }
    }
}
