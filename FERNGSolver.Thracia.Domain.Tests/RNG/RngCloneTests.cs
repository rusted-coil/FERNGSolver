using FERNGSolver.Thracia.Domain.RNG;

namespace FERNGSolver.Thracia.Domain.Tests.RNG;

[TestClass]
public class RngCloneTests
{
    [TestMethod]
    [DataRow(0, 53)]
    [DataRow(0, 54)]
    [DataRow(7, 54)]
    [DataRow(7, 55)]
    [DataRow(30, 0)]
    [DataRow(30, 109)]
    [DataRow(63, 53)]
    [DataRow(63, 55)]
    public void Clone_RemainsIndependentAcrossTableRefreshes(int table, int offset)
    {
        var original = RngFactory.Create(table);
        original.Advance(offset);
        var clone = original.Clone();
        var control = RngFactory.Create(table);
        control.Advance(offset);
        var expected = Enumerable.Range(0, 150).Select(_ => control.Next()).ToArray();

        CollectionAssert.AreEqual(expected, expected.Select(_ => original.Next()).ToArray());
        CollectionAssert.AreEqual(expected, expected.Select(_ => clone.Next()).ToArray());
    }
}
