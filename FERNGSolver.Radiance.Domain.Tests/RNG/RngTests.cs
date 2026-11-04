using FERNGSolver.Radiance.Domain.RNG;

namespace FERNGSolver.Radiance.Domain.Tests.RNG;

[TestClass]
public class RngTests
{
    [TestMethod]
    [DataRow(0, new int[] { 10, 32, 83, 35, 35, 57, 78, 76, 85, 5 })]
    [DataRow(6, new int[] { 88, 78, 41, 14, 56, 56, 3, 44, 84, 74 })]
    [DataRow(7, new int[] { 31, 89, 25, 12, 60, 61, 8, 98, 21, 11 })]
    public void Next_PreservesSequenceIncludingSeedTableWraparound(int table, int[] expected)
    {
        // Regression vectors calculated from the repository's seeds and recurrence;
        // these are not an independent emulator/game accuracy oracle.
        var rng = RngFactory.Create(table);

        CollectionAssert.AreEqual(expected, expected.Select(_ => (int)rng.Next()).ToArray());
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(2)]
    [DataRow(3)]
    [DataRow(4)]
    [DataRow(5)]
    [DataRow(6)]
    [DataRow(7)]
    public void Clone_PreservesAdvancedStateWithoutSharingMutableState(int table)
    {
        var original = RngFactory.Create(table);
        original.Advance(37);
        var clone = original.Clone();
        var control = RngFactory.Create(table);
        control.Advance(37);
        var expected = Enumerable.Range(0, 200).Select(_ => control.Next()).ToArray();

        // Read each complete stream separately so shared mutable state cannot pass.
        CollectionAssert.AreEqual(expected, expected.Select(_ => original.Next()).ToArray());
        CollectionAssert.AreEqual(expected, expected.Select(_ => clone.Next()).ToArray());
        Assert.IsTrue(expected.All(value => value < 100));
    }

    [TestMethod]
    [DataRow(0, true)]
    [DataRow(48, true)]
    [DataRow(49, true)]
    [DataRow(50, false)]
    [DataRow(51, false)]
    [DataRow(99, false)]
    public void IsRngValueOk_UsesInclusiveFortyNineBoundary(int value, bool expected)
    {
        Assert.AreEqual(expected, Util.IsRngValueOk((ushort)value));
    }
}
