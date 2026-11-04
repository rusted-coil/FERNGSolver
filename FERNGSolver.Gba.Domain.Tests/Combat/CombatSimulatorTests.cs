using FERNGSolver.Gba.Domain.Combat;
using FERNGSolver.Gba.Domain.Combat.Service;

namespace FERNGSolver.Gba.Domain.Tests.Combat;

[TestClass]
public class CombatSimulatorTests
{
    [TestMethod]
    public void Simulate_AlternatesAttacksBeforeFollowup_WithoutMutatingInput()
    {
        var rng = new RecordingRngService();
        var attacker = new CombatUnit { PhaseCount = 2 };
        var defender = new CombatUnit();

        var result = CombatSimulator.Simulate(rng, attacker, defender, true);

        Assert.AreEqual(25, result.AttackerHp);
        Assert.AreEqual(20, result.DefenderHp);
        Assert.AreEqual(30, attacker.Hp);
        Assert.AreEqual(30, defender.Hp);
        AssertCalls(rng, "Hit:Player", "Critical:Player", "Hit:Enemy", "Critical:Enemy", "Hit:Player", "Critical:Player");
    }

    [TestMethod]
    public void Simulate_WithNoPhases_DoesNotConsumeRandomNumbers()
    {
        var rng = new RecordingRngService();

        var result = CombatSimulator.Simulate(rng, new CombatUnit { PhaseCount = 0 }, new CombatUnit { PhaseCount = 0 }, true);

        Assert.AreEqual(30, result.AttackerHp);
        Assert.AreEqual(30, result.DefenderHp);
        AssertCalls(rng);
    }

    [TestMethod]
    public void Simulate_WhenAttackMisses_SkipsCriticalAndWeaponEffects()
    {
        var rng = new RecordingRngService { Hit = false, Curse = true };
        var attacker = new CombatUnit { StatusDetail = new Detail { WeaponType = Const.WeaponType.Cursed } };

        var result = CombatSimulator.Simulate(rng, attacker, new CombatUnit { PhaseCount = 0 }, false);

        Assert.AreEqual(30, result.AttackerHp);
        Assert.AreEqual(30, result.DefenderHp);
        AssertCalls(rng, "Hit:Player");
    }

    [TestMethod]
    public void Simulate_WhenFirstHitKills_StopsBeforeCounterattackAndBraveSecondHit()
    {
        var rng = new RecordingRngService();
        var attacker = new CombatUnit { Power = 40, PhaseCount = 2, StatusDetail = new Detail { WeaponType = Const.WeaponType.Brave } };

        var result = CombatSimulator.Simulate(rng, attacker, new CombatUnit(), true);

        Assert.AreEqual(30, result.AttackerHp);
        Assert.AreEqual(0, result.DefenderHp);
        AssertCalls(rng, "Hit:Player", "Critical:Player");
    }

    [TestMethod]
    public void Simulate_WhenCounterattackKills_StopsBeforeAttackerFollowup()
    {
        var rng = new RecordingRngService();

        var result = CombatSimulator.Simulate(rng, new CombatUnit { PhaseCount = 2 }, new CombatUnit { Power = 40 }, true);

        Assert.AreEqual(0, result.AttackerHp);
        Assert.AreEqual(25, result.DefenderHp);
        AssertCalls(rng, "Hit:Player", "Critical:Player", "Hit:Enemy", "Critical:Enemy");
    }

    [DataTestMethod]
    [DataRow(true)]
    [DataRow(false)]
    public void Simulate_BraveWeaponAttacksTwicePerPhase_ForEitherSide(bool playerIsBrave)
    {
        var rng = new RecordingRngService();
        var brave = new CombatUnit { StatusDetail = new Detail { WeaponType = Const.WeaponType.Brave } };
        var ordinary = new CombatUnit();

        var result = CombatSimulator.Simulate(rng, playerIsBrave ? brave : ordinary, playerIsBrave ? ordinary : brave, true);

        Assert.AreEqual(playerIsBrave ? 25 : 20, result.AttackerHp);
        Assert.AreEqual(playerIsBrave ? 20 : 25, result.DefenderHp);
        AssertCalls(rng, playerIsBrave
            ? ["Hit:Player", "Critical:Player", "Hit:Player", "Critical:Player", "Hit:Enemy", "Critical:Enemy"]
            : ["Hit:Player", "Critical:Player", "Hit:Enemy", "Critical:Enemy", "Hit:Enemy", "Critical:Enemy"]);
    }

    [DataTestMethod]
    [DataRow(10, 30, 15, 25, 15)]
    [DataRow(28, 30, 15, 30, 15)]
    [DataRow(10, 4, 15, 14, 0)]
    public void Simulate_AbsorbHealingIsLimitedByActualDamageAndMaximumHp(
        int attackerHp, int defenderHp, int power, int expectedAttackerHp, int expectedDefenderHp)
    {
        var rng = new RecordingRngService();
        var attacker = new CombatUnit { Hp = attackerHp, Power = power, StatusDetail = new Detail { WeaponType = Const.WeaponType.Absorb } };

        var result = CombatSimulator.Simulate(rng, attacker, new CombatUnit { Hp = defenderHp, PhaseCount = 0 }, true);

        Assert.AreEqual(expectedAttackerHp, result.AttackerHp);
        Assert.AreEqual(expectedDefenderHp, result.DefenderHp);
        AssertCalls(rng, "Hit:Player", "Critical:Player");
    }

    [TestMethod]
    public void Simulate_GreatShieldPreventsDamageAndAbsorbHealing()
    {
        var rng = new RecordingRngService { GreatShield = true };
        var attacker = new CombatUnit { Hp = 10, StatusDetail = new Detail { WeaponType = Const.WeaponType.Absorb } };
        var defender = new CombatUnit { PhaseCount = 0, StatusDetail = new Detail { SkillType = Const.SkillType.GreatShield } };

        var result = CombatSimulator.Simulate(rng, attacker, defender, true);

        Assert.AreEqual(10, result.AttackerHp);
        Assert.AreEqual(30, result.DefenderHp);
        AssertCalls(rng, "Hit:Player", "GreatShield:Enemy", "Critical:Player");
    }

    [TestMethod]
    public void Simulate_PoisonWeaponSkipsGreatShieldCheck()
    {
        var rng = new RecordingRngService { GreatShield = true };
        var attacker = new CombatUnit { StatusDetail = new Detail { WeaponType = Const.WeaponType.Poison } };
        var defender = new CombatUnit { PhaseCount = 0, StatusDetail = new Detail { SkillType = Const.SkillType.GreatShield } };

        var result = CombatSimulator.Simulate(rng, attacker, defender, true);

        Assert.AreEqual(25, result.DefenderHp);
        AssertCalls(rng, "Hit:Player", "Critical:Player");
    }

    [TestMethod]
    public void Simulate_ActivatedSureStrikeSkipsHitAndGreatShieldChecks()
    {
        var rng = new RecordingRngService { SureStrike = true, Hit = false, GreatShield = true };
        var attacker = new CombatUnit { StatusDetail = new Detail { SkillType = Const.SkillType.SureStrike } };
        var defender = new CombatUnit { PhaseCount = 0, StatusDetail = new Detail { SkillType = Const.SkillType.GreatShield } };

        var result = CombatSimulator.Simulate(rng, attacker, defender, true);

        Assert.AreEqual(25, result.DefenderHp);
        AssertCalls(rng, "SureStrike:Player", "Critical:Player");
    }

    [TestMethod]
    public void Simulate_WhenSureStrikeDoesNotActivate_FallsBackToNormalHitCheck()
    {
        var rng = new RecordingRngService { SureStrike = false, Hit = false };
        var attacker = new CombatUnit { StatusDetail = new Detail { SkillType = Const.SkillType.SureStrike } };

        var result = CombatSimulator.Simulate(rng, attacker, new CombatUnit { PhaseCount = 0 }, true);

        Assert.AreEqual(30, result.DefenderHp);
        AssertCalls(rng, "SureStrike:Player", "Hit:Player");
    }

    [TestMethod]
    public void Simulate_PierceAddsOpponentDefenseBeforeCriticalMultiplier()
    {
        var rng = new RecordingRngService { Pierce = true, Critical = true };
        var attacker = new CombatUnit { StatusDetail = new Detail { SkillType = Const.SkillType.Pierce, OpponentDefense = 3 } };

        var result = CombatSimulator.Simulate(rng, attacker, new CombatUnit { PhaseCount = 0 }, true);

        Assert.AreEqual(6, result.DefenderHp);
        AssertCalls(rng, "Hit:Player", "Pierce:Player", "Critical:Player");
    }

    [TestMethod]
    public void Simulate_ActivatedGreatShieldSkipsPierceCheck()
    {
        var rng = new RecordingRngService { GreatShield = true, Pierce = true };
        var attacker = new CombatUnit { StatusDetail = new Detail { SkillType = Const.SkillType.Pierce } };
        var defender = new CombatUnit { PhaseCount = 0, StatusDetail = new Detail { SkillType = Const.SkillType.GreatShield } };

        var result = CombatSimulator.Simulate(rng, attacker, defender, true);

        Assert.AreEqual(30, result.DefenderHp);
        AssertCalls(rng, "Hit:Player", "GreatShield:Enemy", "Critical:Player");
    }

    [DataTestMethod]
    [DataRow(true, Const.BossType.None, false)]
    [DataRow(false, Const.BossType.FinalBoss, false)]
    [DataRow(false, Const.BossType.None, true)]
    [DataRow(false, Const.BossType.Boss, true)]
    public void Simulate_CriticalChecksSilencerOnlyForSupportedTitleAndTarget(
        bool isBindingBlade, Const.BossType boss, bool expectedSilencerCheck)
    {
        var rng = new RecordingRngService { Critical = true };
        var defender = new CombatUnit { PhaseCount = 0, StatusDetail = new Detail { BossType = boss } };

        var result = CombatSimulator.Simulate(rng, new CombatUnit(), defender, isBindingBlade);

        Assert.AreEqual(15, result.DefenderHp);
        AssertCalls(rng, expectedSilencerCheck
            ? ["Hit:Player", "Critical:Player", "Silencer:Player"]
            : ["Hit:Player", "Critical:Player"]);
        if (expectedSilencerCheck)
        {
            Assert.AreEqual(boss, rng.SilencerBoss);
            Assert.IsFalse(rng.SilencerHasSkill);
        }
    }

    [TestMethod]
    public void Simulate_ActivatedSilencerKillsThroughGreatShield()
    {
        var rng = new RecordingRngService { Critical = true, GreatShield = true, Silencer = true };
        var attacker = new CombatUnit { StatusDetail = new Detail { SkillType = Const.SkillType.Silencer } };
        var defender = new CombatUnit { StatusDetail = new Detail { SkillType = Const.SkillType.GreatShield } };

        var result = CombatSimulator.Simulate(rng, attacker, defender, false);

        Assert.AreEqual(30, result.AttackerHp);
        Assert.AreEqual(0, result.DefenderHp);
        Assert.IsTrue(rng.SilencerHasSkill);
        AssertCalls(rng, "Hit:Player", "GreatShield:Enemy", "Critical:Player", "Silencer:Player");
    }

    [DataTestMethod]
    [DataRow(false, 30, 25, 30)]
    [DataRow(true, 10, 0, 30)]
    public void Simulate_CurseDamagesAttackerIncludingCriticalAndStopsOnDeath(
        bool critical, int attackerHp, int expectedAttackerHp, int expectedDefenderHp)
    {
        var rng = new RecordingRngService { Critical = critical, Curse = true };
        var attacker = new CombatUnit { Hp = attackerHp, PhaseCount = critical ? 2 : 1, StatusDetail = new Detail { WeaponType = Const.WeaponType.Cursed } };

        var result = CombatSimulator.Simulate(rng, attacker, new CombatUnit { PhaseCount = critical ? 2 : 0 }, true);

        Assert.AreEqual(expectedAttackerHp, result.AttackerHp);
        Assert.AreEqual(expectedDefenderHp, result.DefenderHp);
        AssertCalls(rng, "Hit:Player", "Critical:Player", "Curse:Player");
    }

    private static void AssertCalls(RecordingRngService rng, params string[] expected) =>
        CollectionAssert.AreEqual(expected, rng.Calls);

    private sealed record CombatUnit : ICombatUnit
    {
        public int Hp { get; init; } = 30;
        public int Power { get; init; } = 5;
        public int HitRate => 80;
        public int CriticalRate => 10;
        public int PhaseCount { get; init; } = 1;
        public IUnitStatusDetail StatusDetail { get; init; } = new Detail();
    }

    private sealed record Detail : IUnitStatusDetail
    {
        public Const.WeaponType WeaponType { get; init; }
        public Const.SkillType SkillType { get; init; }
        public Const.BossType BossType { get; init; }
        public int Level => 20;
        public int MaxHp => 30;
        public int Luck => 10;
        public int OpponentDefense { get; init; }
    }

    private sealed class RecordingRngService : ICombatRngService
    {
        public List<string> Calls { get; } = [];
        public bool Hit { get; init; } = true;
        public bool Critical { get; init; }
        public bool SureStrike { get; init; }
        public bool Pierce { get; init; }
        public bool GreatShield { get; init; }
        public bool Silencer { get; init; }
        public bool Curse { get; init; }
        public Const.BossType SilencerBoss { get; private set; }
        public bool SilencerHasSkill { get; private set; }

        public bool CheckHit(int rate, UnitSide side) { Assert.AreEqual(80, rate); return Record("Hit", side, Hit); }
        public bool CheckCritical(int rate, UnitSide side) { Assert.AreEqual(10, rate); return Record("Critical", side, Critical); }
        public bool CheckActivateSureStrike(int level, UnitSide side) { Assert.AreEqual(20, level); return Record("SureStrike", side, SureStrike); }
        public bool CheckActivatePierce(int level, UnitSide side) { Assert.AreEqual(20, level); return Record("Pierce", side, Pierce); }
        public bool CheckActivateGreatShield(int level, UnitSide side) { Assert.AreEqual(20, level); return Record("GreatShield", side, GreatShield); }
        public bool CheckActivateCurse(int luck, UnitSide side) { Assert.AreEqual(10, luck); return Record("Curse", side, Curse); }

        public bool CheckActivateSilencer(Const.BossType boss, bool hasSkill, UnitSide side)
        {
            SilencerBoss = boss;
            SilencerHasSkill = hasSkill;
            return Record("Silencer", side, Silencer);
        }

        private bool Record(string operation, UnitSide side, bool result)
        {
            Calls.Add($"{operation}:{side}");
            return result;
        }
    }
}
