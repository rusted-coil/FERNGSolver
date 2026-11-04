using FERNGSolver.Common.Application.Search.Strategy;
using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Tests.Search;

[TestClass]
public class SearcherTests
{
    // All four searchers promise absolute, inclusive positions and an unchanged input RNG.
    [DataTestMethod]
    [DataRow("Gba")]
    [DataRow("Genealogy")]
    [DataRow("Radiance")]
    [DataRow("Thracia")]
    public void Search_NonzeroRange_IncludesBothEndpointsAndPreservesTable(string game)
    {
        var rng = new CountingRng();
        var strategy = CommonStrategyFactory.CreateSequentialStrategy();

        var results = Search(game, rng, 3, 5, strategy);

        CollectionAssert.AreEqual(new[] { 3, 4, 5 }, results.Select(x => x.Position).ToArray());
        Assert.IsTrue(results.All(x => x.TableIndex == 7));
        Assert.AreEqual(0, rng.Position);
    }

    [DataTestMethod]
    [DataRow("Gba")]
    [DataRow("Genealogy")]
    [DataRow("Radiance")]
    [DataRow("Thracia")]
    public void Search_StrategyConsumesMultipleValues_CandidatesRemainIndependent(string game)
    {
        var rng = new CountingRng();
        var strategy = new RecordingStrategy();

        var results = Search(game, rng, 2, 5, strategy);

        // A failed candidate and a successful candidate both consume three values.
        // The next candidate must still start just one value later.
        CollectionAssert.AreEqual(new ushort[] { 2, 3, 4, 5 }, strategy.Starts.ToArray());
        CollectionAssert.AreEqual(new[] { 2, 4 }, results.Select(x => x.Position).ToArray());
        Assert.AreEqual(0, rng.Position);
    }

    [DataTestMethod]
    [DataRow("Gba")]
    [DataRow("Genealogy")]
    [DataRow("Radiance")]
    [DataRow("Thracia")]
    public void Search_SinglePosition_ChecksExactlyOnce(string game)
    {
        var strategy = new RecordingStrategy();

        var results = Search(game, new CountingRng(), 4, 4, strategy);

        CollectionAssert.AreEqual(new ushort[] { 4 }, strategy.Starts.ToArray());
        CollectionAssert.AreEqual(new[] { 4 }, results.Select(x => x.Position).ToArray());
    }

    [DataTestMethod]
    [DataRow("Gba")]
    [DataRow("Genealogy")]
    [DataRow("Radiance")]
    [DataRow("Thracia")]
    public void Search_ReversedRange_DoesNotCheckAnyCandidates(string game)
    {
        var strategy = new RecordingStrategy();

        var results = Search(game, new CountingRng(), 5, 4, strategy);

        Assert.AreEqual(0, results.Length);
        Assert.AreEqual(0, strategy.Starts.Count);
    }

    [DataTestMethod]
    [DataRow("Gba")]
    [DataRow("Genealogy")]
    [DataRow("Radiance")]
    [DataRow("Thracia")]
    public void Search_NoMatches_ReturnsEmptyResult(string game)
    {
        var strategy = CommonStrategyFactory.CreateHighOrLowPatternStrategy(new[] { ((ushort)0, true) });

        Assert.AreEqual(0, Search(game, new CountingRng(), 0, 3, strategy).Length);
    }

    [DataTestMethod]
    [DataRow("Gba", -1)]
    [DataRow("Gba", 2)]
    [DataRow("Genealogy", -1)]
    [DataRow("Genealogy", 2)]
    [DataRow("Radiance", -1)]
    [DataRow("Radiance", 2)]
    [DataRow("Thracia", -1)]
    [DataRow("Thracia", 2)]
    public void Search_RangeStartsBeforeInitialState_OnlyChecksNonnegativePositions(string game, int max)
    {
        var rng = new CountingRng();
        var strategy = new RecordingStrategy();

        var results = Search(game, rng, -2, max, strategy);

        var validPositions = Enumerable.Range(0, max + 1).ToArray();
        CollectionAssert.AreEqual(validPositions.Select(x => (ushort)x).ToArray(), strategy.Starts.ToArray());
        CollectionAssert.AreEqual(validPositions.Where(x => x % 2 == 0).ToArray(), results.Select(x => x.Position).ToArray());
        Assert.AreEqual(0, rng.Position);
    }

    private static (int TableIndex, int Position)[] Search(string game, ICloneableRng rng,
        int min, int max, ISearchStrategy strategy) => game switch
    {
        "Gba" => Gba.Application.Search.Searcher.Search(rng, min, max, strategy)
            .Select(x => (7, x.Position)).ToArray(),
        "Genealogy" => Genealogy.Application.Search.Searcher.Search(rng, min, max, strategy)
            .Select(x => (7, x.Position)).ToArray(),
        "Radiance" => Radiance.Application.Search.Searcher.Search(7, rng, min, max, strategy)
            .Select(x => (x.TableIndex, x.Position)).ToArray(),
        "Thracia" => Thracia.Application.Search.Searcher.Search(7, rng, min, max, strategy)
            .Select(x => (x.TableIndex, x.Position)).ToArray(),
        _ => throw new ArgumentOutOfRangeException(nameof(game))
    };

    private sealed class CountingRng(int position = 0) : ICloneableRng
    {
        public int Position { get; private set; } = position;
        public ushort Next() => checked((ushort)Position++);
        public ICloneableRng Clone() => new CountingRng(Position);
    }

    private sealed class RecordingStrategy : ISearchStrategy
    {
        public List<ushort> Starts { get; } = new();
        public bool CheckAndAdvance(IRng rng)
        {
            var start = rng.Next();
            Starts.Add(start);
            rng.Next();
            rng.Next();
            return start % 2 == 0;
        }
    }
}
