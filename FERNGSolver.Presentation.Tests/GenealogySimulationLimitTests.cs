using System.Reactive;
using System.Reactive.Subjects;
using FERNGSolver.Genealogy.Domain.Combat;
using FERNGSolver.Genealogy.Presentation.RngView;
using FERNGSolver.Genealogy.Presentation.RngView.ViewContracts;
using FERNGSolver.Genealogy.Presentation.ViewContracts;

namespace FERNGSolver.Presentation.Tests;

[TestClass]
public class GenealogySimulationLimitTests
{
    [TestMethod]
    public void Search_NonterminatingCombatClearsPreviousResultsAndCanRecover()
    {
        var view = CaptureView.Create<IExtendedMainFormView>(out var capture);
        using var capturedView = capture;
        var errors = new ErrorNotifier();
        using var presenter = Genealogy.Presentation.Search.PresenterFactory.Create(view, errors);
        capture.Values["ContainsGrowth"] = true;
        capture.SearchClicked.OnNext(Unit.Default);
        Assert.AreEqual(1, capture.Rows.Count);

        ConfigureNonterminatingCombat(capture);
        capture.SearchClicked.OnNext(Unit.Default);

        Assert.AreEqual(0, capture.Rows.Count);
        Assert.AreEqual(0, capture.TotalCount);
        Assert.AreEqual(1, errors.Messages.Count);
        StringAssert.Contains(errors.Messages[0], "計算を中断");

        capture.Values["ContainsCombat"] = false;
        capture.SearchClicked.OnNext(Unit.Default);
        Assert.AreEqual(1, capture.Rows.Count);
    }

    [TestMethod]
    public void Preview_NonterminatingCombatClearsStaleValuesAndCanRecover()
    {
        var view = CaptureView.Create<IExtendedMainFormView>(out var capture);
        using var capturedView = capture;
        using var rngView = new RngView();
        using var presenter = Genealogy.Presentation.RngView.PresenterFactory.CreateViewPresenter(view, rngView);
        rngView.Position.OnNext(0);
        Assert.AreEqual(40, rngView.Rows.Count);

        ConfigureNonterminatingCombat(capture);
        capture.ConditionChanged.OnNext(Unit.Default);
        Assert.AreEqual(0, rngView.Rows.Count);
        Assert.IsNotNull(rngView.Error);

        capture.Values["ContainsCombat"] = false;
        capture.ConditionChanged.OnNext(Unit.Default);
        Assert.AreEqual(40, rngView.Rows.Count);
        Assert.IsNull(rngView.Error);
    }

    private static void ConfigureNonterminatingCombat(CaptureView capture)
    {
        capture.Values["ContainsCombat"] = true;
        capture.Values["IsArena"] = true;
        capture.Values["AttackerHp"] = 30;
        capture.Values["DefenderHp"] = 30;
        capture.Values["AttackerPhaseCount"] = 1;
        capture.Values["DefenderPhaseCount"] = 1;
        capture.Values["AttackerStatusDetail"] = new Detail();
        capture.Values["DefenderStatusDetail"] = new Detail();
    }

    private sealed class RngView : IRngView, IDisposable
    {
        public int CurrentPosition => 0;
        public Subject<int> Position { get; } = new();
        public IObservable<int> PositionChanged => Position;
        public IReadOnlyList<IRandomNumberViewModel> Rows { get; private set; } = Array.Empty<IRandomNumberViewModel>();
        public string? Error { get; private set; }
        public void SetRandomNumbers(IReadOnlyList<IRandomNumberViewModel> viewModels, IEnumerable<int> partitionPositions) => Rows = viewModels;
        public void SetSimulationError(string? message) => Error = message;
        public void Dispose() => Position.Dispose();
    }

    private sealed class Detail : IUnitStatusDetail
    {
        public Const.WeaponType WeaponType => Const.WeaponType.Normal;
        public bool HasVantage => false;
        public bool HasAstra => false;
        public bool HasLuna => false;
        public bool HasSol => false;
        public bool HasContinuation => false;
        public bool HasAssault => false;
        public bool HasGreatShield => false;
        public bool HasWrath => false;
        public bool HasPray => false;
        public int Level => 1;
        public int MaxHp => 30;
        public int Tec => 0;
        public int AttackSpeed => 0;
        public int OpponentAttackSpeed => 0;
        public int OpponentMdf => 0;
    }
}
