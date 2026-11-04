using System.Reactive;
using FERNGSolver.Gba.Application.Config;

namespace FERNGSolver.Presentation.Tests;

[TestClass]
public class SearchPresenterBehaviorTests
{
    [TestMethod]
    [DataRow("Gba")]
    [DataRow("Genealogy")]
    [DataRow("Radiance")]
    [DataRow("Thracia")]
    public void MissingConditionIsReportedAndDoesNotPreventAValidSearch(string game)
    {
        using var search = new SearchHarness(game);

        search.Click();

        CollectionAssert.AreEqual(new[] { "検索条件が選択されていません。" }, search.Errors.Messages);
        Assert.IsNull(search.Capture.RowType, "Validation must stop before publishing search results.");

        search.UsePatternSearch();
        search.Click();

        Assert.AreEqual(1, search.Capture.TotalCount);
        Assert.AreEqual(1, search.Errors.Messages.Count);
    }

    [TestMethod]
    [DataRow("Gba")]
    [DataRow("Genealogy")]
    [DataRow("Radiance")]
    [DataRow("Thracia")]
    public void InvalidPatternClearsPreviousResultsAndSearchCanRecover(string game)
    {
        using var search = new SearchHarness(game);
        search.UsePatternSearch();
        search.Click();
        Assert.AreEqual(1, search.Capture.TotalCount);

        var patternProperty = game == "Genealogy" ? "HighOrLowPatternString" : "CxString";
        search.Capture.Values[patternProperty] = "?";
        search.Click();

        Assert.AreEqual(0, search.Capture.Rows.Count);
        Assert.AreEqual(0, search.Capture.TotalCount);
        Assert.AreEqual(1, search.Errors.Messages.Count);
        StringAssert.Contains(search.Errors.Messages[0], "パースに失敗");

        search.Capture.Values[patternProperty] = string.Empty;
        search.Click();
        Assert.AreEqual(1, search.Capture.TotalCount);
        Assert.AreEqual(1, search.Errors.Messages.Count);
    }

    [TestMethod]
    [DataRow("Gba")]
    [DataRow("Genealogy")]
    [DataRow("Radiance")]
    [DataRow("Thracia")]
    public void DisposingPresenterUnsubscribesFromSearchClicks(string game)
    {
        using var search = new SearchHarness(game);
        search.UsePatternSearch();
        search.Click();
        var previousRows = search.Capture.Rows;

        search.Presenter.Dispose();
        search.Capture.Values["CxString"] = "?";
        search.Capture.Values["HighOrLowPatternString"] = "?";
        search.Click();

        Assert.AreSame(previousRows, search.Capture.Rows);
        Assert.AreEqual(0, search.Errors.Messages.Count);
    }

    [TestMethod]
    [DataRow("Gba")]
    [DataRow("Genealogy")]
    [DataRow("Radiance")]
    public void GrowthSearchUsesCurrentPositionAndBothOffsetEndpoints(string game)
    {
        using var search = new SearchHarness(game);
        search.Capture.Values["ContainsGrowth"] = true;
        search.Capture.Values["CurrentPosition"] = 10;
        search.Capture.Values["OffsetMin"] = 3;
        search.Capture.Values["OffsetMax"] = 5;

        search.Click();

        Assert.AreEqual(3, search.Capture.TotalCount);
        CollectionAssert.AreEqual(new[] { "13", "14", "15" }, search.Capture.Rows.Select(row => Property(row, "Position")).ToArray());
        CollectionAssert.AreEqual(new[] { "+3", "+4", "+5" }, search.Capture.Rows.Select(row => Property(row, "Offset")).ToArray());
        if (game == "Genealogy")
            CollectionAssert.AreEqual(new[] { "21", "22", "23" }, search.Capture.Rows.Select(row => Property(row, "AfterPosition")).ToArray());
    }

    [TestMethod]
    [DataRow("Radiance", false)]
    [DataRow("Radiance", true)]
    [DataRow("Thracia", true)]
    public void TableSelectionRestrictsResultsAndNullSearchesEveryTable(string game, bool patternSearch)
    {
        using var search = new SearchHarness(game);
        if (patternSearch) search.UsePatternSearch();
        else search.Capture.Values["ContainsGrowth"] = true;
        search.Capture.Values["SearchTableIndex"] = 2;
        search.Capture.Values["OffsetMin"] = 3;
        search.Capture.Values["OffsetMax"] = 4;

        search.Click();

        Assert.AreEqual(2, search.Capture.TotalCount);
        CollectionAssert.AreEqual(new[] { "3", "4" }, search.Capture.Rows.Select(row => Property(row, "Position")).ToArray());
        Assert.IsTrue(search.Capture.Rows.All(row => int.Parse(Property(row, "TableIndex")[1..]) == 2));

        search.Capture.Values["SearchTableIndex"] = null;
        search.Capture.Values["OffsetMax"] = 3;
        search.Click();

        var tableCount = game == "Radiance" ? Radiance.Domain.RNG.Const.TableCount : Thracia.Domain.RNG.Const.TableCount;
        Assert.AreEqual(tableCount, search.Capture.TotalCount);
        CollectionAssert.AreEqual(Enumerable.Range(0, tableCount).ToArray(),
            search.Capture.Rows.Select(row => int.Parse(Property(row, "TableIndex")[1..])).ToArray());

        search.Capture.Values["OffsetMax"] = 2;
        search.Click();
        Assert.AreEqual(0, search.Capture.TotalCount);
        Assert.AreEqual(0, search.Capture.Rows.Count);
    }

    [TestMethod]
    public void ArenaOffsetCountsParsedTokensIncludingWildcardsRatherThanTextLength()
    {
        using var search = new SearchHarness("Genealogy");
        search.UsePatternSearch();
        search.Capture.Values["CurrentPosition"] = 10;
        search.Capture.Values["OffsetMin"] = 2;
        search.Capture.Values["OffsetMax"] = 2;
        search.Capture.Values["HighOrLowPatternString"] = " x, X, 0+,";
        search.Capture.Values["AddsOffset"] = false;
        search.Click();
        Assert.AreEqual("12", Property(search.Capture.Rows.Single(), "Position"));

        search.Capture.Values["AddsOffset"] = true;
        search.Click();
        Assert.AreEqual("15", Property(search.Capture.Rows.Single(), "Position"));
        Assert.AreEqual(0, search.Errors.Messages.Count);
    }

    private static string Property(object row, string name) => (string)row.GetType().GetProperty(name)!.GetValue(row)!;

    [TestMethod]
    [DataRow("Gba", 50)]
    [DataRow("Radiance", 20)]
    [DataRow("Genealogy", 50)]
    public void NegativeOffsetReplaysGrowthAtTheMatchedAbsolutePosition(string game, int hpRate)
    {
        using var search = new SearchHarness(game);
        search.Capture.Values["ContainsGrowth"] = true;
        search.Capture.Values["CurrentPosition"] = 1;
        search.Capture.Values["OffsetMin"] = -1;
        search.Capture.Values["OffsetMax"] = -1;
        search.Capture.Values["HpGrowthRate"] = hpRate;
        search.Capture.Values[game == "Gba" ? "AtkGrowthRate" : "StrGrowthRate"] = 100;
        search.Capture.Values["HpSearchType"] = game switch
        {
            "Gba" => (object)Gba.Application.Search.Strategy.GrowthSearchType.MustUp,
            "Genealogy" => Genealogy.Application.Search.Strategy.GrowthSearchType.MustUp,
            _ => Radiance.Application.Search.Strategy.GrowthSearchType.MustUp,
        };

        search.Click();

        // GBA's first two RNs are 47,66; Radiance table 0 starts 10,32.
        // For GBA/Radiance, HP must rise at position 0 and would fail if replay started at position 1.
        // Genealogy's first RN is 16, so its HP rise also satisfies the probabilistic MustUp condition.
        Assert.AreEqual(1, search.Capture.TotalCount);
        var row = search.Capture.Rows.Single();
        Assert.AreEqual("0", Property(row, "Position"));
        Assert.AreEqual("-1", Property(row, "Offset"));
        Assert.AreEqual("HP+1、力+1", Property(row, "GrowthResult"));

        search.Capture.Values["CurrentPosition"] = 0;
        search.Capture.Values["OffsetMin"] = 0;
        search.Capture.Values["OffsetMax"] = 0;
        search.Click();
        Assert.AreEqual("+0", Property(search.Capture.Rows.Single(), "Offset"));
        Assert.AreEqual("HP+1、力+1", Property(search.Capture.Rows.Single(), "GrowthResult"));
    }

    private sealed class SearchHarness : IDisposable
    {
        private readonly string m_Game;
        public CaptureView Capture { get; }
        public ErrorNotifier Errors { get; } = new();
        public IDisposable Presenter { get; }

        public SearchHarness(string game)
        {
            m_Game = game;
            CaptureView capture;
            Presenter = game switch
            {
                "Gba" => Gba.Presentation.Search.PresenterFactory.Create(
                    CaptureView.Create<Gba.Presentation.ViewContracts.IExtendedMainFormView>(out capture), new ConfigService(), Errors),
                "Genealogy" => Genealogy.Presentation.Search.PresenterFactory.Create(
                    CaptureView.Create<Genealogy.Presentation.ViewContracts.IExtendedMainFormView>(out capture), Errors),
                "Radiance" => Radiance.Presentation.Search.PresenterFactory.Create(
                    CaptureView.Create<Radiance.Presentation.ViewContracts.IExtendedMainFormView>(out capture), Errors),
                "Thracia" => Thracia.Presentation.Search.PresenterFactory.Create(
                    CaptureView.Create<Thracia.Presentation.ViewContracts.IExtendedMainFormView>(out capture), Errors),
                _ => throw new ArgumentOutOfRangeException(nameof(game)),
            };
            Capture = capture;
            Capture.Values["SearchTableIndex"] = 0;
            Capture.Values["FalconKnightMethodMove"] = 9;
        }

        public void UsePatternSearch() => Capture.Values[m_Game == "Genealogy" ? "UsesArenaCheck" : "UsesFalconKnightMethod"] = true;
        public void Click() => Capture.SearchClicked.OnNext(Unit.Default);
        public void Dispose()
        {
            Presenter.Dispose();
            Capture.Dispose();
        }
    }

    private sealed class ConfigService : IConfigService
    {
        public IModifiableConfig Config { get; } = new Config();
        public void Serialize() { }
    }

    private sealed class Config : IModifiableConfig
    {
        public bool IsBindingBlade { get; set; }
    }
}
