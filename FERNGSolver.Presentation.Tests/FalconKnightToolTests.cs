using System.Reactive;
using System.Reactive.Subjects;
using FERNGSolver.Common.Domain.Types;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;

namespace FERNGSolver.Presentation.Tests;

[TestClass]
public class FalconKnightToolTests
{
    [TestMethod]
    [DataRow("Gba", 1, 1)]
    [DataRow("Gba", -1, 1)]
    [DataRow("Gba", 1, -1)]
    [DataRow("Gba", -1, -1)]
    [DataRow("Radiance", 1, 1)]
    [DataRow("Radiance", -1, 1)]
    [DataRow("Radiance", 1, -1)]
    [DataRow("Radiance", -1, -1)]
    public void PathConversionRecordsChoicesInReverseTraversalOrderInEveryQuadrant(string game, int xSign, int ySign)
    {
        var entry = CreateEntry(game, _ => { });
        // From the final point back toward the first: vertical, horizontal, vertical,
        // then a forced horizontal move, which consumes no random number.
        GridPosition[] path = [new(10, 10), new(10 + xSign, 10), new(10 + xSign, 10 + ySign),
            new(10 + 2 * xSign, 10 + ySign), new(10 + 2 * xSign, 10 + 2 * ySign)];

        CollectionAssert.AreEqual(new[] { false, true, false }, entry.PathConverter.PathToCx(path).ToArray());
    }

    [TestMethod]
    [DataRow("Gba")]
    [DataRow("Radiance")]
    public void EmptySinglePointAndStraightPathsNeedNoRandomChoices(string game)
    {
        var converter = CreateEntry(game, _ => { }).PathConverter;
        GridPosition[][] paths = [[], [new(0, 0)], [new(0, 0), new(1, 0), new(2, 0)],
            [new(0, 0), new(0, 1), new(0, 2)]];

        foreach (var path in paths)
            Assert.AreEqual(0, converter.PathToCx(path).Count);
    }

    [TestMethod]
    [DataRow("Gba")]
    [DataRow("Radiance")]
    public void PresenterAddsOnlyTheCurrentPathAndClearsItWhenThereAreNoChoices(string game)
    {
        var added = new List<string>();
        using var view = new ToolView();
        using var presenter = FalconKnightTool.Presentation.Presenter.PresenterFactory.Create(view, CreateEntry(game, added.Add));
        Assert.AreEqual("現在の入力: -", view.Text);

        view.Path.OnNext([new(0, 0), new(1, 0), new(1, 1), new(2, 1), new(2, 2)]);
        Assert.AreEqual("現在の入力: xcx", view.Text);
        Assert.AreEqual(0, added.Count, "Drawing a path alone must not append it to the search condition.");
        view.Add.OnNext(Unit.Default);

        view.Path.OnNext([new(0, 0), new(1, 0)]);
        Assert.AreEqual("現在の入力: -", view.Text);
        view.Add.OnNext(Unit.Default);
        CollectionAssert.AreEqual(new[] { "xcx", "" }, added);

        presenter.Dispose();
        view.Path.OnNext([new(0, 0), new(1, 0), new(1, 1)]);
        view.Add.OnNext(Unit.Default);
        Assert.AreEqual("現在の入力: -", view.Text);
        Assert.AreEqual(2, added.Count);
    }

    private static IFalconKnightToolEntry CreateEntry(string game, Action<string> add) => game == "Gba"
        ? Gba.Presentation.FalconKnight.FalconKnightToolEntryFactory.Create("test", add)
        : Radiance.Presentation.FalconKnight.FalconKnightToolEntryFactory.Create("test", add);

    private sealed class ToolView : IFalconKnightToolView, IDisposable
    {
        public Subject<Unit> Add { get; } = new();
        public Subject<IReadOnlyList<GridPosition>> Path { get; } = new();
        public IObservable<Unit> AddButtonClicked => Add;
        public IObservable<IReadOnlyList<GridPosition>> PathDetermined => Path;
        public string? Text { get; private set; }
        public void SetCurrentPathText(string text) => Text = text;
        public void Dispose()
        {
            Add.Dispose();
            Path.Dispose();
        }
    }
}
