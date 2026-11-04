using FERNGSolver.Common.Application.Search.Strategy;
using FERNGSolver.Common.Domain.RNG;
using GenealogyStrategy = FERNGSolver.Genealogy.Application.Search.Strategy;
using GenealogyCombat = FERNGSolver.Genealogy.Domain.Combat;
using RadianceStrategy = FERNGSolver.Radiance.Application.Search.Strategy;
using RadianceCombat = FERNGSolver.Radiance.Domain.Combat;

namespace FERNGSolver.Tests.Search;

[TestClass]
public class NonGbaStrategyTests
{
    [TestMethod]
    [DataRow(false, 0)]
    [DataRow(false, 1)]
    [DataRow(false, 2)]
    [DataRow(false, 3)]
    [DataRow(false, 4)]
    [DataRow(false, 5)]
    [DataRow(false, 6)]
    [DataRow(false, 7)]
    [DataRow(true, 0)]
    [DataRow(true, 1)]
    [DataRow(true, 2)]
    [DataRow(true, 3)]
    [DataRow(true, 4)]
    [DataRow(true, 5)]
    [DataRow(true, 6)]
    [DataRow(true, 7)]
    public void Growth_MapsEachRateAndConditionToItsOwnRandomNumber(bool radiance, int stat)
    {
        // RNG order is HP, Str, Mgc, Tec, Spd, Luc, Def, Mdf (not declaration order).
        var rates = new[] { 10, 20, 30, 40, 50, 60, 70, 80 };
        var noGrowth = rates.Select(rate => (ushort)rate).ToArray();
        var selectedGrowth = noGrowth.ToArray();
        selectedGrowth[stat]--;

        foreach (var requirement in new[] { Requirement.MustUp, Requirement.MustNotUp })
        {
            var strategy = CreateGrowth(radiance, rates, stat, requirement);
            var failedRng = new SequenceRng(noGrowth);
            var successfulRng = new SequenceRng(selectedGrowth);

            Assert.AreEqual(requirement == Requirement.MustNotUp, strategy.CheckAndAdvance(failedRng), $"{requirement}: no growth");
            Assert.AreEqual(requirement == Requirement.MustUp, strategy.CheckAndAdvance(successfulRng), $"{requirement}: selected growth");
            Assert.AreEqual(8, failedRng.Calls);
            Assert.AreEqual(8, successfulRng.Calls);
        }
    }

    [TestMethod]
    [DataRow(false)]
    [DataRow(true)]
    public void Growth_InterpretsGuaranteedGrowthAndIgnoredConditions(bool radiance)
    {
        var cases = new (int Rate, ushort Roll, Requirement Requirement, bool Expected)[]
        {
            (150, 49, Requirement.MustUp, true),
            (150, 50, Requirement.MustUp, false),
            (100, 0, Requirement.MustUp, false),
            (100, 99, Requirement.MustNotUp, false),
            (0, 0, Requirement.MustNotUp, true),
            (100, 0, Requirement.Ignored, true),
            (100, 0, Requirement.Max, true),
        };

        foreach (var testCase in cases)
        {
            var rates = new int[8];
            rates[0] = testCase.Rate;
            var strategy = CreateGrowth(radiance, rates, 0, testCase.Requirement);
            var rng = new SequenceRng(testCase.Roll, 99, 99, 99, 99, 99, 99, 99);

            Assert.AreEqual(testCase.Expected, strategy.CheckAndAdvance(rng), $"{testCase.Requirement}, rate {testCase.Rate}, RN {testCase.Roll}");
            Assert.AreEqual(8, rng.Calls, "A rejected growth candidate still consumes the complete level-up.");
        }
    }

    [TestMethod]
    [DataRow(false, 20, 20, 20, 20, true)]
    [DataRow(false, 21, 30, 0, 30, false)]
    [DataRow(false, 0, 19, 0, 30, false)]
    [DataRow(false, 0, 30, 21, 30, false)]
    [DataRow(false, 0, 30, 0, 19, false)]
    [DataRow(true, 20, 20, 20, 20, true)]
    [DataRow(true, 21, 30, 0, 30, false)]
    [DataRow(true, 0, 19, 0, 30, false)]
    [DataRow(true, 0, 30, 21, 30, false)]
    [DataRow(true, 0, 30, 0, 19, false)]
    public void Combat_ChecksInclusiveHpBoundsForBothUnits(bool radiance, int attackerMin, int attackerMax, int defenderMin, int defenderMax, bool expected)
    {
        var strategy = CreateCombat(radiance, attackerMin, attackerMax, defenderMin, defenderMax);
        var rng = SuccessfulCombatRng(radiance);

        Assert.AreEqual(expected, strategy.CheckAndAdvance(rng));
        Assert.AreEqual(radiance ? 6 : 2, rng.Calls);
    }

    [TestMethod]
    [DataRow(false)]
    [DataRow(true)]
    public void Combat_ReusesStrategyWithFreshRngAndUnitStateForEveryCandidate(bool radiance)
    {
        var strategy = CreateCombat(radiance, 20, 20, 20, 20);
        var missRng = radiance ? new SequenceRng(99, 99, 99, 99) : new SequenceRng(99, 99);

        Assert.IsFalse(strategy.CheckAndAdvance(missRng));
        var hitRng = SuccessfulCombatRng(radiance);
        Assert.IsTrue(strategy.CheckAndAdvance(hitRng));
        var repeatedHitRng = SuccessfulCombatRng(radiance);
        Assert.IsTrue(strategy.CheckAndAdvance(repeatedHitRng));
        Assert.AreEqual(radiance ? 4 : 2, missRng.Calls);
        Assert.AreEqual(radiance ? 6 : 2, hitRng.Calls);
        Assert.AreEqual(radiance ? 6 : 2, repeatedHitRng.Calls);
    }

    [TestMethod]
    public void GenealogyCombat_ForwardsArenaFlagUntilCombatFinishes()
    {
        var strategy = GenealogyStrategy.StrategyFactory.CreateCombatStrategy(new GenealogyStrategy.CombatStrategyArgs
        {
            Attacker = new GenealogyUnit(), Defender = new GenealogyUnit(), IsArena = true,
            AttackerHpPostconditionMin = 10, AttackerHpPostconditionMax = 10,
            DefenderHpPostconditionMin = 0, DefenderHpPostconditionMax = 0,
        });
        var rng = new SequenceRng(0, 0, 0, 0, 0);

        Assert.IsTrue(strategy.CheckAndAdvance(rng));
        Assert.AreEqual(5, rng.Calls);
    }

    [TestMethod]
    public void GenealogyCombat_ForwardsOpponentFirstFlag()
    {
        var strategy = GenealogyStrategy.StrategyFactory.CreateCombatStrategy(new GenealogyStrategy.CombatStrategyArgs
        {
            Attacker = new GenealogyUnit { Attack = 30 }, Defender = new GenealogyUnit { Attack = 30 }, IsOpponentFirst = true,
            AttackerHpPostconditionMin = 0, AttackerHpPostconditionMax = 0,
            DefenderHpPostconditionMin = 30, DefenderHpPostconditionMax = 30,
        });
        var rng = new SequenceRng(0);

        Assert.IsTrue(strategy.CheckAndAdvance(rng));
        Assert.AreEqual(1, rng.Calls);
    }

    private enum Requirement { Ignored, MustUp, MustNotUp, Max }

    private static ISearchStrategy CreateGrowth(bool radiance, int[] rates, int stat, Requirement requirement)
    {
        if (radiance)
        {
            var conditions = new RadianceStrategy.GrowthSearchType[8];
            conditions[stat] = requirement switch
            {
                Requirement.MustUp => RadianceStrategy.GrowthSearchType.MustUp,
                Requirement.MustNotUp => RadianceStrategy.GrowthSearchType.MustNotUp,
                Requirement.Max => RadianceStrategy.GrowthSearchType.Max,
                _ => RadianceStrategy.GrowthSearchType.NotConsidered,
            };
            return RadianceStrategy.StrategyFactory.CreateGrowthStrategy(new RadianceStrategy.GrowthStrategyArgs
            {
                HpGrowthRate = rates[0], StrGrowthRate = rates[1], MgcGrowthRate = rates[2], TecGrowthRate = rates[3],
                SpdGrowthRate = rates[4], LucGrowthRate = rates[5], DefGrowthRate = rates[6], MdfGrowthRate = rates[7],
                HpSearchType = conditions[0], StrSearchType = conditions[1], MgcSearchType = conditions[2], TecSearchType = conditions[3],
                SpdSearchType = conditions[4], LucSearchType = conditions[5], DefSearchType = conditions[6], MdfSearchType = conditions[7],
            });
        }

        var genealogyConditions = new GenealogyStrategy.GrowthSearchType[8];
        genealogyConditions[stat] = requirement switch
        {
            Requirement.MustUp => GenealogyStrategy.GrowthSearchType.MustUp,
            Requirement.MustNotUp => GenealogyStrategy.GrowthSearchType.MustNotUp,
            Requirement.Max => GenealogyStrategy.GrowthSearchType.Max,
            _ => GenealogyStrategy.GrowthSearchType.NotConsidered,
        };
        return GenealogyStrategy.StrategyFactory.CreateGrowthStrategy(new GenealogyStrategy.GrowthStrategyArgs
        {
            HpGrowthRate = rates[0], StrGrowthRate = rates[1], MgcGrowthRate = rates[2], TecGrowthRate = rates[3],
            SpdGrowthRate = rates[4], LucGrowthRate = rates[5], DefGrowthRate = rates[6], MdfGrowthRate = rates[7],
            HpSearchType = genealogyConditions[0], StrSearchType = genealogyConditions[1], MgcSearchType = genealogyConditions[2], TecSearchType = genealogyConditions[3],
            SpdSearchType = genealogyConditions[4], LucSearchType = genealogyConditions[5], DefSearchType = genealogyConditions[6], MdfSearchType = genealogyConditions[7],
        });
    }

    private static ISearchStrategy CreateCombat(bool radiance, int attackerMin, int attackerMax, int defenderMin, int defenderMax) =>
        radiance
            ? RadianceStrategy.StrategyFactory.CreateCombatStrategy(new RadianceStrategy.CombatStrategyArgs
            {
                Attacker = new RadianceUnit(), Defender = new RadianceUnit(),
                AttackerHpPostconditionMin = attackerMin, AttackerHpPostconditionMax = attackerMax,
                DefenderHpPostconditionMin = defenderMin, DefenderHpPostconditionMax = defenderMax,
            })
            : GenealogyStrategy.StrategyFactory.CreateCombatStrategy(new GenealogyStrategy.CombatStrategyArgs
            {
                Attacker = new GenealogyUnit(), Defender = new GenealogyUnit(),
                AttackerHpPostconditionMin = attackerMin, AttackerHpPostconditionMax = attackerMax,
                DefenderHpPostconditionMin = defenderMin, DefenderHpPostconditionMax = defenderMax,
            });

    private static SequenceRng SuccessfulCombatRng(bool radiance) =>
        radiance ? new SequenceRng(0, 0, 99, 0, 0, 99) : new SequenceRng(0, 0);

    private sealed class SequenceRng(params ushort[] values) : IRng
    {
        public int Calls { get; private set; }
        public ushort Next()
        {
            Assert.IsTrue(Calls < values.Length, "Unexpected additional random number consumption.");
            return values[Calls++];
        }
    }

    private sealed class GenealogyUnit : GenealogyCombat.ICombatUnit
    {
        public int Hp => 30;
        public int Attack { get; init; } = 10;
        public int Defense => 0;
        public int HitRate => 50;
        public int CriticalRate => 0;
        public int PhaseCount => 1;
        public GenealogyCombat.IUnitStatusDetail StatusDetail { get; } = new GenealogyDetail();
    }

    private sealed class GenealogyDetail : GenealogyCombat.IUnitStatusDetail
    {
        public GenealogyCombat.Const.WeaponType WeaponType => GenealogyCombat.Const.WeaponType.Normal;
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

    private sealed class RadianceUnit : RadianceCombat.ICombatUnit
    {
        public int Hp => 30;
        public int Power => 10;
        public int HitRate => 50;
        public int CriticalRate => 0;
        public int PhaseCount => 1;
        public RadianceCombat.IUnitStatusDetail StatusDetail { get; } = new RadianceDetail();
    }

    private sealed class RadianceDetail : RadianceCombat.IUnitStatusDetail
    {
        public RadianceCombat.Const.WeaponType WeaponType => RadianceCombat.Const.WeaponType.Normal;
        public RadianceCombat.Const.BossType BossType => RadianceCombat.Const.BossType.None;
        public bool HasVantage => false;
        public bool HasAdept => false;
        public bool HasWrath => false;
        public bool HasMiracle => false;
        public bool HasResolve => false;
        public bool HasCounter => false;
        public bool HasGuard => false;
        public bool HasCorrode => false;
        public bool HasAether => false;
        public bool HasAstra => false;
        public bool HasLuna => false;
        public bool HasSol => false;
        public bool HasFlare => false;
        public bool HasStun => false;
        public bool HasColossus => false;
        public bool HasDeadeye => false;
        public bool HasLethality => false;
        public bool HasCancel => false;
        public int WeaponUses => 20;
        public int Level => 1;
        public int MaxHp => 30;
        public int Str => 0;
        public int Tec => 0;
        public int Luck => 0;
        public int OpponentDefense => 0;
    }
}
