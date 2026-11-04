using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Genealogy.Domain.Combat;
using FERNGSolver.Genealogy.Domain.Combat.Service;

namespace FERNGSolver.Genealogy.Domain.Tests.Combat;

[TestClass]
public class CombatFlowTests
{
    [TestMethod]
    public void Miss_DoesNotConsumeCriticalOrSleepRolls()
    {
        var rng = new SequenceRng(50);
        var attacker = new CombatUnit { HitRate = 50, CriticalRate = 100, StatusDetail = new Detail { WeaponType = Const.WeaponType.Sleep } };

        var result = Simulate(rng, attacker, new CombatUnit { PhaseCount = 0 });

        Assert.AreEqual(30, result.DefenderHp);
        Assert.AreEqual(1, rng.Calls);
    }

    [TestMethod]
    [DataRow(15, 0, 15)]
    [DataRow(16, 30, 0)]
    public void Vantage_OnlyChangesAttackOrderAtHalfHpOrBelow(int defenderHp, int expectedAttacker, int expectedDefender)
    {
        var rng = new SequenceRng(0);
        var defender = new CombatUnit { Hp = defenderHp, Attack = 30, StatusDetail = new Detail { HasVantage = true } };

        var result = Simulate(rng, new CombatUnit { Attack = 30 }, defender);

        Assert.AreEqual(expectedAttacker, result.AttackerHp);
        Assert.AreEqual(expectedDefender, result.DefenderHp);
        Assert.AreEqual(1, rng.Calls, "A defeated unit must not retaliate.");
    }

    [TestMethod]
    [DataRow(false, 30, 0)]
    [DataRow(true, 0, 30)]
    public void OpponentFirst_SelectsWhoDeliversTheLethalHit(bool opponentFirst, int expectedAttacker, int expectedDefender)
    {
        var rng = new SequenceRng(0);

        var result = CombatSimulator.Simulate(CombatRngServiceFactory.Create(rng),
            new CombatUnit { Attack = 30 }, new CombatUnit { Attack = 30 }, false, opponentFirst);

        Assert.AreEqual(expectedAttacker, result.AttackerHp);
        Assert.AreEqual(expectedDefender, result.DefenderHp);
        Assert.AreEqual(1, result.RoundCount);
        Assert.AreEqual(1, rng.Calls);
    }

    [TestMethod]
    public void BraveWeapon_AttacksTwiceInOnePhase()
    {
        var rng = new SequenceRng(0, 0);

        var result = Simulate(rng, new CombatUnit { StatusDetail = new Detail { WeaponType = Const.WeaponType.Brave } },
            new CombatUnit { PhaseCount = 0 });

        Assert.AreEqual(10, result.DefenderHp);
        Assert.AreEqual(2, rng.Calls);
    }

    [TestMethod]
    public void OpponentSwordSkill_ConsumesRollButCannotActivateForAttacker()
    {
        var rng = new SequenceRng(0, 0);

        var result = Simulate(rng, new CombatUnit { HitRate = 0 },
            new CombatUnit { PhaseCount = 0, StatusDetail = new Detail { HasSol = true, Tec = 100 } });

        Assert.AreEqual(30, result.DefenderHp);
        Assert.AreEqual(2, rng.Calls, "The opponent's skill consumes a roll even on a missed attack.");
    }

    [TestMethod]
    public void ActivatedLuna_BypassesHitRollAndDefense()
    {
        var rng = new SequenceRng(0);

        var result = Simulate(rng, new CombatUnit { HitRate = 0, StatusDetail = new Detail { HasLuna = true, Tec = 100 } },
            new CombatUnit { PhaseCount = 0, Defense = 20 });

        Assert.AreEqual(20, result.DefenderHp);
        Assert.AreEqual(1, rng.Calls);
    }

    [TestMethod]
    public void SuccessfulSleep_ConsumesDurationRollAndStopsRetaliation()
    {
        var rng = new SequenceRng(0, 0, 99);

        var result = Simulate(rng, new CombatUnit { StatusDetail = new Detail { WeaponType = Const.WeaponType.Sleep } }, new CombatUnit());

        Assert.AreEqual(30, result.AttackerHp);
        Assert.AreEqual(20, result.DefenderHp);
        Assert.AreEqual(3, rng.Calls);
    }

    [TestMethod]
    public void FailedSleep_DoesNotConsumeDurationRollAndAllowsRetaliation()
    {
        var rng = new SequenceRng(0, 30, 0);

        var result = Simulate(rng, new CombatUnit { StatusDetail = new Detail { WeaponType = Const.WeaponType.Sleep } }, new CombatUnit());

        Assert.AreEqual(20, result.AttackerHp);
        Assert.AreEqual(20, result.DefenderHp);
        Assert.AreEqual(3, rng.Calls);
    }

    [TestMethod]
    [DataRow(true)]
    [DataRow(false)]
    public void LethalSleepWeaponHit_ClampsDefenderHpToZero(bool sleepSucceeds)
    {
        var rng = sleepSucceeds ? new SequenceRng(0, 0, 99) : new SequenceRng(0, 99);

        var result = Simulate(rng, new CombatUnit { StatusDetail = new Detail { WeaponType = Const.WeaponType.Sleep } },
            new CombatUnit { Hp = 5 });

        Assert.AreEqual(0, result.DefenderHp);
        Assert.AreEqual(30, result.AttackerHp);
        Assert.AreEqual(sleepSucceeds ? 3 : 2, rng.Calls);
    }

    [TestMethod]
    public void Absorb_OverkillOnlyHealsByTheRemainingTargetHp()
    {
        var rng = new SequenceRng(0);

        var result = Simulate(rng, new CombatUnit { Hp = 10, Attack = 20, StatusDetail = new Detail { WeaponType = Const.WeaponType.Absorb } },
            new CombatUnit { Hp = 3 });

        Assert.AreEqual(13, result.AttackerHp);
        Assert.AreEqual(0, result.DefenderHp);
        Assert.AreEqual(1, rng.Calls);
    }

    private static CombatSimulator.Result Simulate(IRng rng, ICombatUnit attacker, ICombatUnit defender) =>
        CombatSimulator.Simulate(CombatRngServiceFactory.Create(rng), attacker, defender, false, false);

    private sealed class SequenceRng(params ushort[] values) : IRng
    {
        public int Calls { get; private set; }
        public ushort Next()
        {
            Assert.IsTrue(Calls < values.Length, "Unexpected additional random number consumption.");
            return values[Calls++];
        }
    }

    private sealed class CombatUnit : ICombatUnit
    {
        public int Hp { get; init; } = 30;
        public int Attack { get; init; } = 10;
        public int Defense { get; init; }
        public int HitRate { get; init; } = 100;
        public int CriticalRate { get; init; }
        public int PhaseCount { get; init; } = 1;
        public IUnitStatusDetail StatusDetail { get; init; } = new Detail();
    }

    private sealed class Detail : IUnitStatusDetail
    {
        public Const.WeaponType WeaponType { get; init; }
        public bool HasVantage { get; init; }
        public bool HasAstra { get; init; }
        public bool HasLuna { get; init; }
        public bool HasSol { get; init; }
        public bool HasContinuation { get; init; }
        public bool HasAssault { get; init; }
        public bool HasGreatShield { get; init; }
        public bool HasWrath { get; init; }
        public bool HasPray { get; init; }
        public int Level { get; init; }
        public int MaxHp { get; init; } = 30;
        public int Tec { get; init; }
        public int AttackSpeed { get; init; }
        public int OpponentAttackSpeed { get; init; }
        public int OpponentMdf { get; init; }
    }
}
