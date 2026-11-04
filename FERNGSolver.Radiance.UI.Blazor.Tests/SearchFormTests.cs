using Bunit;
using FERNGSolver.Radiance.Domain.Character.Extensions;
using FERNGSolver.Radiance.UI.Blazor.Internal;
using FERNGSolver.Common.UI.Blazor;
using FERNGSolver.Common.Presentation.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MudBlazor;
using MudBlazor.Services;
using MudBlazor.Extensions;

namespace FERNGSolver.Radiance.UI.Blazor.Tests;

[TestClass]
public sealed class SearchFormTests
{
    private static BunitContext CreateContext()
    {
        var context = new BunitContext();
        context.JSInterop.Mode = JSRuntimeMode.Loose;
        context.Services.AddMudServices();
        return context;
    }

    [TestMethod]
    public async Task GrowthAndCombatEditsRefreshTheExistingRngCard()
    {
        await using var context = CreateContext();
        var form = context.Render<SearchFormHost>().FindComponent<RadianceSearchForm>();
        var card = form.FindComponent<RngViewCard>();
        var hp = form.FindComponent<GrowthConditionPanel>().FindComponents<MudNumericField<int>>()
            .Single(field => field.Instance.Label == "HP成長率");

        await form.InvokeAsync(() => hp.Instance.ValueChanged.InvokeAsync(0));
        Assert.AreEqual("失敗", card.Find(".rng-usage-result").TextContent);
        await form.InvokeAsync(() => hp.Instance.ValueChanged.InvokeAsync(100));
        Assert.AreEqual("成功", card.Find(".rng-usage-result").TextContent);

        await ChangeMode(form, SearchMode.Combat);
        Assert.AreSame(card.Instance, form.FindComponent<RngViewCard>().Instance);
        Assert.AreEqual("攻撃側命中1", card.Find(".rng-usage").TextContent);
        var hit = form.FindComponent<CombatConditionPanel>().FindComponents<MudNumericField<int>>()
            .First(field => field.Instance.Label == "命中");
        await form.InvokeAsync(() => hit.Instance.ValueChanged.InvokeAsync(0));
        Assert.AreEqual("失敗", card.Find(".rng-usage-result").TextContent);
        await form.InvokeAsync(() => hit.Instance.ValueChanged.InvokeAsync(100));
        Assert.AreEqual("成功", card.Find(".rng-usage-result").TextContent);
    }

    [TestMethod]
    public async Task ModeRoundTripKeepsCharacterBandsAndManualGrowthRates()
    {
        await using var context = CreateContext();
        var form = context.Render<SearchFormHost>().FindComponent<RadianceSearchForm>();
        var panel = form.FindComponent<GrowthConditionPanel>();
        var originalPanel = panel.Instance;
        var state = panel.Instance.State;
        Assert.AreEqual(state.Characters[0].HpGrowthRate, state.HpGrowthRate);
        var characterIndex = state.Characters.ToList().FindIndex(character => character.Name == "セネリオ");
        Assert.IsTrue(characterIndex >= 0);

        await form.InvokeAsync(() => panel.FindComponent<MudSelect<int>>().Instance.ValueChanged.InvokeAsync(characterIndex));
        await form.InvokeAsync(() => panel.FindComponents<MudCheckBox<bool>>()
            .Single(box => box.Instance.Label == "魔道士の腕輪").Instance.ValueChanged.InvokeAsync(true));
        await form.InvokeAsync(() => panel.FindComponents<MudNumericField<int>>()
            .Single(field => field.Instance.Label == "HP成長率").Instance.ValueChanged.InvokeAsync(77));

        await ChangeMode(form, SearchMode.Combat);
        Assert.AreEqual(0, form.FindComponents<GrowthConditionPanel>().Count);
        await ChangeMode(form, SearchMode.Growth);
        var recreated = form.FindComponent<GrowthConditionPanel>();
        Assert.AreNotSame(originalPanel, recreated.Instance);
        Assert.AreSame(state, recreated.Instance.State);
        Assert.AreEqual(characterIndex, recreated.FindComponent<MudSelect<int>>().Instance.GetState(component => component.Value));
        Assert.IsTrue(recreated.FindComponents<MudCheckBox<bool>>()
            .Single(box => box.Instance.Label == "魔道士の腕輪").Instance.GetState(component => component.Value));
        Assert.AreEqual(77, recreated.FindComponents<MudNumericField<int>>()
            .Single(field => field.Instance.Label == "HP成長率").Instance.GetState(component => component.Value));

        await form.InvokeAsync(() => recreated.FindComponents<MudCheckBox<bool>>()
            .Single(box => box.Instance.Label == "剣士の腕輪").Instance.ValueChanged.InvokeAsync(true));
        var expected = state.Characters[characterIndex].Boost(new ICharacterExtensions.BoostArgs
        {
            HasMageBand = true,
            HasSwordBand = true,
        });
        Assert.AreEqual(expected.HpGrowthRate, state.HpGrowthRate);
        Assert.AreEqual(expected.MgcGrowthRate, state.MgcGrowthRate);
        Assert.AreEqual(expected.SpdGrowthRate, state.SpdGrowthRate);
    }

    [TestMethod]
    public async Task RngCardRejectsInvalidInputsAndStillAcceptsValidChanges()
    {
        await using var context = CreateContext();
        var form = context.Render<SearchFormHost>().FindComponent<RadianceSearchForm>();
        var card = form.FindComponent<RngViewCard>();
        var table = card.FindComponents<MudNumericField<int>>().Single(field => field.Instance.Label == "テーブル番号");
        var position = card.FindComponents<MudNumericField<int>>().Single(field => field.Instance.Label == "消費数");
        Assert.AreEqual(0, table.Instance.Min);
        Assert.AreEqual(7, table.Instance.Max);
        Assert.AreEqual(0, position.Instance.Min);

        foreach (var invalid in new[] { -1, 8 })
        {
            await form.InvokeAsync(() => table.Instance.ValueChanged.InvokeAsync(invalid));
            Assert.AreEqual(0, card.Instance.TableIndex);
            Assert.AreEqual(1, card.FindComponents<MudAlert>().Count);
        }
        await form.InvokeAsync(() => position.Instance.ValueChanged.InvokeAsync(-1));
        Assert.AreEqual(0, card.Instance.CurrentPosition);

        await form.InvokeAsync(() => table.Instance.ValueChanged.InvokeAsync(7));
        await form.InvokeAsync(() => position.Instance.ValueChanged.InvokeAsync(42));
        Assert.AreEqual(7, card.Instance.TableIndex);
        Assert.AreEqual(42, card.Instance.CurrentPosition);
        Assert.AreEqual(0, card.FindComponents<MudAlert>().Count);
        Assert.AreEqual(40, card.FindAll(".rng-value-cell").Count);
    }

    [TestMethod]
    public async Task AcceptingSkillDialogRefreshesPreviewWhileCancelKeepsPreviousState()
    {
        await using var context = CreateContext();
        var host = context.Render<SearchFormHost>();
        var dialogs = host.FindComponent<MudDialogProvider>();
        var form = host.FindComponent<RadianceSearchForm>();
        await ChangeMode(form, SearchMode.Combat);
        var panel = form.FindComponent<CombatConditionPanel>();
        var card = form.FindComponent<RngViewCard>();

        var opening = panel.FindAll("button").First(button => button.TextContent.Trim() == "詳細設定")
            .ClickAsync(new MouseEventArgs());
        await dialogs.WaitForAssertionAsync(() =>
        {
            Assert.IsFalse(opening.IsFaulted, opening.Exception?.ToString());
            Assert.AreEqual(1, dialogs.FindComponents<UnitStatusDetailDialog>().Count);
        });
        var dialog = dialogs.FindComponent<UnitStatusDetailDialog>();
        await dialog.InvokeAsync(() => dialog.FindComponents<MudCheckBox<bool>>()
            .Single(box => box.Instance.Label == "連続").Instance.ValueChanged.InvokeAsync(true));
        await dialog.FindAll("button").Single(button => button.TextContent.Trim() == "OK")
            .ClickAsync(new MouseEventArgs());
        await opening;
        Assert.IsTrue(panel.Instance.State.AttackerStatusDetail.HasAdept);
        Assert.AreEqual("攻撃側連続", card.Find(".rng-usage").TextContent);

        opening = panel.FindAll("button").First(button => button.TextContent.Trim() == "詳細設定")
            .ClickAsync(new MouseEventArgs());
        await dialogs.WaitForAssertionAsync(() =>
        {
            Assert.IsFalse(opening.IsFaulted, opening.Exception?.ToString());
            Assert.AreEqual(1, dialogs.FindComponents<UnitStatusDetailDialog>().Count);
        });
        dialog = dialogs.FindComponent<UnitStatusDetailDialog>();
        await dialog.InvokeAsync(() => dialog.FindComponents<MudCheckBox<bool>>()
            .Single(box => box.Instance.Label == "連続").Instance.ValueChanged.InvokeAsync(false));
        await dialog.FindAll("button").Single(button => button.TextContent.Trim() == "キャンセル")
            .ClickAsync(new MouseEventArgs());
        await opening;
        Assert.IsTrue(panel.Instance.State.AttackerStatusDetail.HasAdept);
        Assert.AreEqual("攻撃側連続", card.Find(".rng-usage").TextContent);
    }

    private static Task ChangeMode(IRenderedComponent<RadianceSearchForm> form, SearchMode mode) =>
        form.InvokeAsync(() => form.FindComponent<MudSelect<SearchMode>>().Instance.ValueChanged.InvokeAsync(mode));

    [TestMethod]
    public async Task ResultsTableShowsTheTotalCountWhenOnlyFirstHundredRowsAreDisplayed()
    {
        await using var context = CreateContext();
        var rows = Enumerable.Range(0, 100).Select(index => (object)new ResultRow(index)).ToArray();
        var table = context.Render<ResultsTable>(parameters => parameters
            .Add(component => component.Columns, new ITableColumn[] { new ResultColumn() })
            .Add(component => component.Rows, rows)
            .Add(component => component.TotalCount, 101));

        var summary = table.FindComponents<MudText>().Single().Markup;
        StringAssert.Contains(summary, "101");
        StringAssert.Contains(summary, "先頭 100");
        Assert.AreEqual(100, table.FindAll("tbody tr").Count);
    }

    public sealed record ResultRow(int Position);

    public sealed class SearchFormHost : ComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<MudPopoverProvider>(0);
            builder.CloseComponent();
            builder.OpenComponent<MudDialogProvider>(1);
            builder.CloseComponent();
            builder.OpenComponent<RadianceSearchForm>(2);
            builder.CloseComponent();
        }
    }

    private sealed class ResultColumn : ITableColumn
    {
        public string HeaderText => "消費数";
        public string PropertyName => nameof(ResultRow.Position);
        public int Width => 50;
    }
}
