using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Gba.Application.Search.Strategy;
using FERNGSolver.Gba.Domain.Combat;

namespace FERNGSolver.Gba.Application.Tests.Search;

[TestClass]
public class CombatStrategyTests
{
    [DataTestMethod]
    [DataRow(30, 30, 25, 25, true)]
    [DataRow(29, 30, 24, 25, true)]
    [DataRow(30, 31, 25, 26, true)]
    [DataRow(31, 40, 0, 30, false)]
    [DataRow(0, 29, 0, 30, false)]
    [DataRow(0, 30, 26, 30, false)]
    [DataRow(0, 30, 0, 24, false)]
    public void CheckAndAdvance_AppliesInclusiveHpBoundsToBothUnits(
        int attackerMin, int attackerMax, int defenderMin, int defenderMax, bool expected)
    {
        var rng = new SequenceRng(0, 0, 99);
        var strategy = StrategyFactory.CreateCombatStrategy(new CombatStrategyArgs
        {
            IsBindingBlade = true,
            Attacker = new CombatUnit(),
            Defender = new CombatUnit { PhaseCount = 0 },
            AttackerHpPostconditionMin = attackerMin,
            AttackerHpPostconditionMax = attackerMax,
            DefenderHpPostconditionMin = defenderMin,
            DefenderHpPostconditionMax = defenderMax,
        });

        Assert.AreEqual(expected, strategy.CheckAndAdvance(rng));
        Assert.AreEqual(3, rng.Consumed, "Even rejected outcomes must leave RNG after the completed combat.");
    }

    [TestMethod]
    public void CheckAndAdvance_WhenReused_RebindsRngForEachCandidate()
    {
        var strategy = StrategyFactory.CreateCombatStrategy(new CombatStrategyArgs
        {
            IsBindingBlade = true,
            Attacker = new CombatUnit(),
            Defender = new CombatUnit { PhaseCount = 0 },
            AttackerHpPostconditionMin = 30,
            AttackerHpPostconditionMax = 30,
            DefenderHpPostconditionMin = 25,
            DefenderHpPostconditionMax = 25,
        });
        var hitRng = new SequenceRng(0, 0, 99);
        var missRng = new SequenceRng(99, 99);
        var anotherHitRng = new SequenceRng(0, 0, 99);

        Assert.IsTrue(strategy.CheckAndAdvance(hitRng));
        Assert.IsFalse(strategy.CheckAndAdvance(missRng));
        Assert.IsTrue(strategy.CheckAndAdvance(anotherHitRng));
        Assert.AreEqual(3, hitRng.Consumed);
        Assert.AreEqual(2, missRng.Consumed);
        Assert.AreEqual(3, anotherHitRng.Consumed);
    }

    [DataTestMethod]
    [DataRow(true, 3)]
    [DataRow(false, 4)]
    public void CheckAndAdvance_CriticalConsumesTitleSpecificSilencerRoll(bool isBindingBlade, int expectedConsumed)
    {
        var rng = new SequenceRng(0, 0, 0, 99);
        var strategy = StrategyFactory.CreateCombatStrategy(new CombatStrategyArgs
        {
            IsBindingBlade = isBindingBlade,
            Attacker = new CombatUnit { CriticalRate = 100 },
            Defender = new CombatUnit { PhaseCount = 0 },
            AttackerHpPostconditionMin = 30,
            AttackerHpPostconditionMax = 30,
            DefenderHpPostconditionMin = 15,
            DefenderHpPostconditionMax = 15,
        });

        Assert.IsTrue(strategy.CheckAndAdvance(rng));
        Assert.AreEqual(expectedConsumed, rng.Consumed);
    }

    private sealed record CombatUnit : ICombatUnit
    {
        public int Hp => 30;
        public int Power => 5;
        public int HitRate => 80;
        public int CriticalRate { get; init; }
        public int PhaseCount { get; init; } = 1;
        public IUnitStatusDetail StatusDetail { get; } = new Detail();
    }

    private sealed class Detail : IUnitStatusDetail
    {
        public Const.WeaponType WeaponType => Const.WeaponType.Normal;
        public Const.SkillType SkillType => Const.SkillType.None;
        public Const.BossType BossType => Const.BossType.None;
        public int Level => 1;
        public int MaxHp => 30;
        public int Luck => 0;
        public int OpponentDefense => 0;
    }

    private sealed class SequenceRng(params ushort[] values) : IRng
    {
        public int Consumed { get; private set; }
        public ushort Next()
        {
            Assert.IsTrue(Consumed < values.Length, "The strategy consumed an unexpected random number.");
            return values[Consumed++];
        }
    }
}
