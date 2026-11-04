using FERNGSolver.Genealogy.Domain.RNG;

namespace FERNGSolver.Genealogy.Domain.Tests.RNG;

[TestClass]
public class RngCloneTests
{
    [TestMethod]
    [DataRow(0)]
    [DataRow(53)]
    [DataRow(54)]
    [DataRow(55)]
    [DataRow(109)]
    public void Clone_RemainsIndependentAcrossTableRefreshes(int offset)
    {
        var original = RngFactory.Create();
        original.Advance(offset);
        var clone = original.Clone();
        var control = RngFactory.Create();
        control.Advance(offset);
        var expected = Enumerable.Range(0, 150).Select(_ => control.Next()).ToArray();

        // Reading the original first must not refresh the clone's table.
        CollectionAssert.AreEqual(expected, expected.Select(_ => original.Next()).ToArray());
        CollectionAssert.AreEqual(expected, expected.Select(_ => clone.Next()).ToArray());
    }
}
