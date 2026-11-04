using Bunit;
using FERNGSolver.Common.Presentation.Interfaces;
using FERNGSolver.Common.UI.Blazor;
using FERNGSolver.Radiance.Presentation.Search;
using FERNGSolver.Radiance.UI.Blazor.Internal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MudBlazor;
using MudBlazor.Services;

namespace FERNGSolver.Radiance.UI.Blazor.Tests;

[TestClass]
public class SearchInteractionTests
{
    [TestMethod]
    public async Task ClickingAResultAddsOneViewerAtItsTableAndPositionAndRemovingItPreservesTheOriginal()
    {
        await using var context = CreateContext();
        var form = context.Render<SearchFormTests.SearchFormHost>().FindComponent<RadianceSearchForm>();
        var original = form.FindComponent<RngViewCard>().Instance;
        var result = new ResultRow("#3", "42");
        await form.InvokeAsync(() => form.Instance.ShowSearchResults([new PositionColumn()], typeof(ResultRow), [result]));

        await form.FindComponent<ResultsTable>().Find("tbody tr").ClickAsync(new MouseEventArgs());

        var cards = form.FindComponents<RngViewCard>();
        Assert.AreEqual(2, cards.Count);
        Assert.AreEqual(3, cards[0].Instance.TableIndex);
        Assert.AreEqual(42, cards[0].Instance.CurrentPosition);
        Assert.AreEqual(40, cards[0].FindAll(".rng-value-cell").Count);
        Assert.AreSame(original, cards[1].Instance);

        await cards[0].FindComponent<MudIconButton>().Find("button").ClickAsync(new MouseEventArgs());

        Assert.AreSame(original, form.FindComponent<RngViewCard>().Instance);
        await form.FindAll("button").Single(button => button.TextContent.Trim() == "+ 追加").ClickAsync(new MouseEventArgs());
        cards = form.FindComponents<RngViewCard>();
        Assert.AreEqual(2, cards.Count);
        Assert.AreEqual(0, cards[0].Instance.TableIndex);
        Assert.AreEqual(0, cards[0].Instance.CurrentPosition);
        Assert.AreSame(original, cards[1].Instance);
    }

    [TestMethod]
    public async Task InvalidPatternReplacesOldResultsWithAnErrorAndCorrectingItRecovers()
    {
        await using var context = CreateContext();
        var form = context.Render<SearchFormTests.SearchFormHost>().FindComponent<RadianceSearchForm>();
        await ChangeMode(form, SearchMode.FalconKnightMethod);
        await SetNumber(form, "最大消費数（オフセット）", 0);
        await Search(form);
        Assert.AreEqual(Domain.RNG.Const.TableCount, form.FindComponent<ResultsTable>().FindAll("tbody tr").Count);

        var pattern = form.FindComponent<FalconKnightConditionPanel>().FindComponent<MudTextField<string>>();
        await form.InvokeAsync(() => pattern.Instance.ValueChanged.InvokeAsync("?"));
        await Search(form);

        Assert.AreEqual(0, form.FindComponent<ResultsTable>().FindAll("tbody tr").Count);
        var error = form.FindComponents<MudAlert>().Single(alert => alert.Instance.Severity == Severity.Error);
        StringAssert.Contains(error.Markup, "パースに失敗");

        await form.InvokeAsync(() => pattern.Instance.ValueChanged.InvokeAsync(string.Empty));
        await Search(form);
        Assert.AreEqual(0, form.FindComponents<MudAlert>().Count(alert => alert.Instance.Severity == Severity.Error));
        Assert.AreEqual(Domain.RNG.Const.TableCount, form.FindComponent<ResultsTable>().FindAll("tbody tr").Count);
    }

    [TestMethod]
    [DataRow(-1, -5, 0)]
    [DataRow(8, -1, 7)]
    public async Task ViewerClampsInvalidInitialStateAndCanContinueFromAValidPosition(int table, int position, int expectedTable)
    {
        await using var context = CreateContext();
        var form = context.Render<SearchFormTests.SearchFormHost>().FindComponent<RadianceSearchForm>();
        await form.InvokeAsync(() => form.Instance.AddView(form.Instance, table, position));
        var card = form.FindComponents<RngViewCard>()[0];
        Assert.AreEqual(expectedTable, card.Instance.TableIndex);
        Assert.AreEqual(0, card.Instance.CurrentPosition);
        Assert.AreEqual(1, card.FindComponents<MudAlert>().Count);
        Assert.AreEqual(40, card.FindAll(".rng-value-cell").Count);

        var input = card.FindComponents<MudNumericField<int>>().Single(field => field.Instance.Label == "消費数");
        await card.InvokeAsync(() => input.Instance.ValueChanged.InvokeAsync(12));
        Assert.AreEqual(12, card.Instance.CurrentPosition);
        Assert.AreEqual(0, card.FindComponents<MudAlert>().Count);
    }

    [TestMethod]
    public async Task DisablingHpFilterIgnoresItsBoundsAndReenablingRestoresThemAfterModeRoundTrip()
    {
        await using var context = CreateContext();
        var form = context.Render<SearchFormTests.SearchFormHost>().FindComponent<RadianceSearchForm>();
        await ChangeMode(form, SearchMode.Combat);
        var panel = form.FindComponent<CombatConditionPanel>();
        await Toggle(panel, "攻撃側の戦闘終了後HPで絞り込み", true);
        await SetNumber(form, "最小", 7);
        await SetNumber(form, "最大", 15);
        Assert.AreEqual(7, form.Instance.AttackerHpPostconditionMin);
        Assert.AreEqual(15, form.Instance.AttackerHpPostconditionMax);

        await Toggle(panel, "攻撃側の戦闘終了後HPで絞り込み", false);
        Assert.AreEqual(0, form.Instance.AttackerHpPostconditionMin);
        Assert.AreEqual(999, form.Instance.AttackerHpPostconditionMax);
        var state = panel.Instance.State;
        await ChangeMode(form, SearchMode.Growth);
        await ChangeMode(form, SearchMode.CombatAndGrowth);
        panel = form.FindComponent<CombatConditionPanel>();
        Assert.AreSame(state, panel.Instance.State);
        await Toggle(panel, "攻撃側の戦闘終了後HPで絞り込み", true);
        Assert.AreEqual(7, form.Instance.AttackerHpPostconditionMin);
        Assert.AreEqual(15, form.Instance.AttackerHpPostconditionMax);
    }

    private static BunitContext CreateContext()
    {
        var context = new BunitContext();
        context.JSInterop.Mode = JSRuntimeMode.Loose;
        context.Services.AddMudServices();
        return context;
    }

    private static Task ChangeMode(IRenderedComponent<RadianceSearchForm> form, SearchMode mode) =>
        form.InvokeAsync(() => form.FindComponent<MudSelect<SearchMode>>().Instance.ValueChanged.InvokeAsync(mode));

    private static Task SetNumber(IRenderedComponent<RadianceSearchForm> form, string label, int value) =>
        form.InvokeAsync(() => form.FindComponents<MudNumericField<int>>().Single(field => field.Instance.Label == label).Instance.ValueChanged.InvokeAsync(value));

    private static Task Toggle(IRenderedComponent<CombatConditionPanel> panel, string label, bool value) =>
        panel.InvokeAsync(() => panel.FindComponents<MudCheckBox<bool>>().Single(box => box.Instance.Label == label).Instance.ValueChanged.InvokeAsync(value));

    private static Task Search(IRenderedComponent<RadianceSearchForm> form) =>
        form.FindAll("button").Single(button => button.TextContent.Trim() == "検索").ClickAsync(new MouseEventArgs());

    public sealed record ResultRow(string TableIndex, string Position) : IRngStateResultViewModel;

    private sealed class PositionColumn : ITableColumn
    {
        public string HeaderText => "消費数";
        public string PropertyName => nameof(ResultRow.Position);
        public int Width => 50;
    }
}
