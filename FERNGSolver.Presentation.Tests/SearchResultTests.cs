using System.Reactive;
using FERNGSolver.Gba.Application.Config;

namespace FERNGSolver.Presentation.Tests;

[TestClass]
public class SearchResultTests
{
    public static IEnumerable<object[]> SearchCases()
    {
        string[] modes = ["GbaGrowth", "GbaFalcon", "GenealogyGrowth", "GenealogyArenaPattern", "RadianceGrowth", "RadianceFalcon", "ThraciaFalcon"];
        foreach (var mode in modes)
        foreach (var count in new[] { 0, 1, 99, 100, 101 })
            yield return [mode, count];
    }

    [TestMethod]
    [DynamicData(nameof(SearchCases), DynamicDataSourceType.Method)]
    public void Search_ReturnsOnlyPopulatedRowsAndReportsFullCount(string mode, int positionCount)
    {
        var errors = new ErrorNotifier();
        CaptureView capture;
        IDisposable presenter;
        switch (mode)
        {
            case "GbaGrowth":
            case "GbaFalcon":
                var gba = CaptureView.Create<Gba.Presentation.ViewContracts.IExtendedMainFormView>(out capture);
                presenter = Gba.Presentation.Search.PresenterFactory.Create(gba, new ConfigService(), errors);
                break;
            case "GenealogyGrowth":
            case "GenealogyArenaPattern":
                var genealogy = CaptureView.Create<Genealogy.Presentation.ViewContracts.IExtendedMainFormView>(out capture);
                presenter = Genealogy.Presentation.Search.PresenterFactory.Create(genealogy, errors);
                break;
            case "RadianceGrowth":
            case "RadianceFalcon":
                var radiance = CaptureView.Create<Radiance.Presentation.ViewContracts.IExtendedMainFormView>(out capture);
                presenter = Radiance.Presentation.Search.PresenterFactory.Create(radiance, errors);
                break;
            default:
                var thracia = CaptureView.Create<Thracia.Presentation.ViewContracts.IExtendedMainFormView>(out capture);
                presenter = Thracia.Presentation.Search.PresenterFactory.Create(thracia, errors);
                break;
        }

        using (presenter)
        using (capture)
        {
            capture.Values["ContainsGrowth"] = mode.EndsWith("Growth");
            capture.Values["UsesFalconKnightMethod"] = mode.EndsWith("Falcon");
            capture.Values["UsesArenaCheck"] = mode == "GenealogyArenaPattern";
            capture.Values["OffsetMax"] = positionCount - 1;
            capture.Values["SearchTableIndex"] = 0;
            capture.Values["FalconKnightMethodMove"] = 9;
            capture.SearchClicked.OnNext(Unit.Default);

            int total = positionCount;
            Assert.AreEqual(0, errors.Messages.Count);
            Assert.AreEqual(total, capture.TotalCount);
            Assert.AreEqual(Math.Min(total, 100), capture.Rows.Count);
            Assert.IsTrue(capture.Rows.All(row => row != null && capture.RowType!.IsInstanceOfType(row)));
            if (total > 0)
                Assert.AreEqual("0", capture.Rows[0].GetType().GetProperty("Position")!.GetValue(capture.Rows[0])!.ToString());
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
