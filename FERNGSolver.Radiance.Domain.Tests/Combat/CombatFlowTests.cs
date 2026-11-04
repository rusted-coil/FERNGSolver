using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Radiance.Domain.Combat;
using FERNGSolver.Radiance.Domain.Combat.Service;

namespace FERNGSolver.Radiance.Domain.Tests.Combat;

[TestClass]
public class CombatFlowTests
{
    [TestMethod]
    [DataRow(49, false)]
    [DataRow(50, true)]
    public void Hit_UsesTwoRollAverageWithStrictThreshold(int hitRate, bool hits)
    {
        var rng = hits ? new SequenceRng(0, 99, 99) : new SequenceRng(0, 99);

        var result = Simulate(rng, new CombatUnit { HitRate = hitRate }, new CombatUnit { PhaseCount = 0 });

        Assert.AreEqual(hits ? 20 : 30, result.DefenderHp);
        Assert.AreEqual(hits ? 3 : 2, rng.Calls, "A missed attack must not consume a critical roll.");
    }

    [TestMethod]
    [DataRow(false, 30, 0)]
    [DataRow(true, 0, 30)]
    public void Vantage_ChangesAttackOrderAndDeathStopsRetaliation(bool hasVantage, int expectedAttacker, int expectedDefender)
    {
        var rng = new SequenceRng(0, 0, 99);

        var result = Simulate(rng, new CombatUnit { Power = 100 },
            new CombatUnit { Power = 100, StatusDetail = new Detail { HasVantage = hasVantage } });

        Assert.AreEqual(expectedAttacker, result.AttackerHp);
        Assert.AreEqual(expectedDefender, result.DefenderHp);
        Assert.AreEqual(3, rng.Calls);
    }

    [TestMethod]
    [DataRow(0, 30, 0)]
    [DataRow(1, 20, 3)]
    [DataRow(2, 10, 6)]
    public void BraveWeapon_StopsWhenWeaponUsesRunOut(int weaponUses, int expectedHp, int expectedCalls)
    {
        var rng = new SequenceRng(0, 0, 99, 0, 0, 99);

        var result = Simulate(rng, new CombatUnit { StatusDetail = new Detail { WeaponType = Const.WeaponType.Brave, WeaponUses = weaponUses } },
            new CombatUnit { PhaseCount = 0 });

        Assert.AreEqual(expectedHp, result.DefenderHp);
        Assert.AreEqual(expectedCalls, rng.Calls);
    }

    [TestMethod]
    public void Guard_CancelsAllRemainingOpponentPhases()
    {
        var rng = new SequenceRng(0, 0, 99, 0);

        var result = Simulate(rng, new CombatUnit { StatusDetail = new Detail { HasGuard = true } }, new CombatUnit { PhaseCount = 2 });

        Assert.AreEqual(30, result.AttackerHp);
        Assert.AreEqual(20, result.DefenderHp);
        Assert.AreEqual(4, rng.Calls);
    }

    [TestMethod]
    public void Counter_AccumulatesDamageAcrossBraveHits()
    {
        var rng = new SequenceRng(0, 0, 99, 0, 0, 0, 99, 0);

        var result = Simulate(rng, new CombatUnit { StatusDetail = new Detail { WeaponType = Const.WeaponType.Brave } },
            new CombatUnit { Hp = 50, PhaseCount = 0, StatusDetail = new Detail { HasCounter = true } });

        Assert.AreEqual(20, result.AttackerHp);
        Assert.AreEqual(30, result.DefenderHp);
        Assert.AreEqual(8, rng.Calls);
    }

    [TestMethod]
    [DataRow(1, 43, 4)]
    [DataRow(2, 42, 7)]
    [DataRow(5, 30, 16)]
    public void Astra_RequiresTwoUsesAndRoundsEachHalfDamageUp(int weaponUses, int expectedHp, int expectedCalls)
    {
        var rng = new SequenceRng(0, 0, 0, 99, 0, 0, 99, 0, 0, 99, 0, 0, 99, 0, 0, 99);

        var result = Simulate(rng, new CombatUnit { Power = 7, StatusDetail = new Detail { HasAstra = true, WeaponUses = weaponUses } },
            new CombatUnit { Hp = 50, PhaseCount = 0 });

        Assert.AreEqual(expectedHp, result.DefenderHp);
        Assert.AreEqual(expectedCalls, rng.Calls, "The activation roll is still consumed with only one weapon use.");
    }

    [TestMethod]
    public void MagicSword_SuppressesAetherAstraAndLunaRolls()
    {
        var rng = new SequenceRng(0, 0, 99);

        var result = Simulate(rng, new CombatUnit
        {
            StatusDetail = new Detail { WeaponType = Const.WeaponType.MagicSword, HasAether = true, HasAstra = true, HasLuna = true },
        }, new CombatUnit { PhaseCount = 0 });

        Assert.AreEqual(20, result.DefenderHp);
        Assert.AreEqual(3, rng.Calls);
    }

    [TestMethod]
    public void Miracle_OnLethalHitLeavesHalfHpRoundedUp()
    {
        var rng = new SequenceRng(0, 0, 99, 0);

        var result = Simulate(rng, new CombatUnit { Power = 50 },
            new CombatUnit { Hp = 11, PhaseCount = 0, StatusDetail = new Detail { HasMiracle = true, Luck = 100 } });

        Assert.AreEqual(6, result.DefenderHp);
        Assert.AreEqual(4, rng.Calls);
    }

    private static CombatSimulator.Result Simulate(IRng rng, ICombatUnit attacker, ICombatUnit defender) =>
        CombatSimulator.Simulate(CombatRngServiceFactory.Create(rng), attacker, defender);

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
        public int Power { get; init; } = 10;
        public int HitRate { get; init; } = 100;
        public int CriticalRate { get; init; }
        public int PhaseCount { get; init; } = 1;
        public IUnitStatusDetail StatusDetail { get; init; } = new Detail();
    }

    private sealed class Detail : IUnitStatusDetail
    {
        public Const.WeaponType WeaponType { get; init; }
        public Const.BossType BossType { get; init; }
        public bool HasVantage { get; init; }
        public bool HasAdept { get; init; }
        public bool HasWrath { get; init; }
        public bool HasMiracle { get; init; }
        public bool HasResolve { get; init; }
        public bool HasCounter { get; init; }
        public bool HasGuard { get; init; }
        public bool HasCorrode { get; init; }
        public bool HasAether { get; init; }
        public bool HasAstra { get; init; }
        public bool HasLuna { get; init; }
        public bool HasSol { get; init; }
        public bool HasFlare { get; init; }
        public bool HasStun { get; init; }
        public bool HasColossus { get; init; }
        public bool HasDeadeye { get; init; }
        public bool HasLethality { get; init; }
        public bool HasCancel { get; init; }
        public int WeaponUses { get; init; } = 20;
        public int Level { get; init; } = 10;
        public int MaxHp { get; init; } = 30;
        public int Str { get; init; }
        public int Tec { get; init; } = 100;
        public int Luck { get; init; }
        public int OpponentDefense { get; init; }
    }
}
