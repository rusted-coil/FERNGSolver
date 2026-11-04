using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Genealogy.Domain.Combat;
using FERNGSolver.Genealogy.Domain.Combat.Service;

namespace FERNGSolver.Genealogy.Domain.Tests.Combat
{
    [TestClass]
    public class CombatSimulatorTests
    {
        [TestMethod]
        [DataRow(true, 5)]
        [DataRow(false, 0)]
        public void Simulate_PrayerUsesHitRateAfterHpDrops(bool hasPray, int expectedHp)
        {
            var rng = new SequenceRng(0, 50);
            var attacker = new CombatUnit { Attack = 15, PhaseCount = 2 };
            var defender = new CombatUnit
            {
                Hp = 20,
                PhaseCount = 0,
                StatusDetail = new Detail { HasPray = hasPray },
            };

            var result = CombatSimulator.Simulate(CombatRngServiceFactory.Create(rng), attacker, defender, false, false);

            Assert.AreEqual(expectedHp, result.DefenderHp);
            Assert.AreEqual(2, rng.Calls);
        }

        [TestMethod]
        public void Simulate_ArenaWithoutHitsThrowsInsteadOfReturningPartialResult()
        {
            var rng = new SequenceRng();
            var attacker = new CombatUnit { HitRate = 0 };
            var defender = new CombatUnit { HitRate = 0 };

            var exception = Assert.ThrowsException<CombatSimulationLimitException>(() =>
                CombatSimulator.Simulate(CombatRngServiceFactory.Create(rng), attacker, defender, true, false));

            Assert.AreEqual(CombatSimulator.MaximumRoundCount, exception.RoundLimit);
            Assert.AreEqual(2 * CombatSimulator.MaximumRoundCount, rng.Calls);
        }

        [TestMethod]
        public void Simulate_ArenaWithoutAttackPhasesAlsoStops()
        {
            var rng = new SequenceRng();
            var attacker = new CombatUnit { PhaseCount = 0 };
            var defender = new CombatUnit { PhaseCount = 0 };

            Assert.ThrowsException<CombatSimulationLimitException>(() =>
                CombatSimulator.Simulate(CombatRngServiceFactory.Create(rng), attacker, defender, true, false));

            Assert.AreEqual(0, rng.Calls);
        }

        [TestMethod]
        public void Simulate_EndlessAssaultAlsoStops()
        {
            var rng = new SequenceRng();
            var attacker = new CombatUnit
            {
                HitRate = 0,
                StatusDetail = new Detail { HasAssault = true, AttackSpeed = 100 },
            };
            var defender = new CombatUnit { HitRate = 0 };

            Assert.ThrowsException<CombatSimulationLimitException>(() =>
                CombatSimulator.Simulate(CombatRngServiceFactory.Create(rng), attacker, defender, false, false));
        }

        [TestMethod]
        public void Simulate_ArenaReturnsCompletedCombatAndExactRngConsumption()
        {
            var rng = new SequenceRng();

            var result = CombatSimulator.Simulate(CombatRngServiceFactory.Create(rng),
                new CombatUnit(), new CombatUnit(), true, false);

            Assert.AreEqual(10, result.AttackerHp);
            Assert.AreEqual(0, result.DefenderHp);
            Assert.AreEqual(3, result.RoundCount);
            Assert.AreEqual(5, rng.Calls);
        }

        [TestMethod]
        [DataRow(10, 20, 0, 1)]
        [DataRow(10, 10, 0, 1)]
        [DataRow(10, 15, 100, 5)]
        [DataRow(10, 25, 100, 1)]
        public void Simulate_ClampsDamageAfterCriticalAttackBonus(int attack, int defense, int criticalRate, int expectedDamage)
        {
            var rng = new SequenceRng();
            var attacker = new CombatUnit { Attack = attack, CriticalRate = criticalRate };
            var defender = new CombatUnit { Defense = defense, PhaseCount = 0 };

            var result = CombatSimulator.Simulate(CombatRngServiceFactory.Create(rng), attacker, defender, false, false);

            Assert.AreEqual(30 - expectedDamage, result.DefenderHp);
            Assert.AreEqual(30, result.AttackerHp);
            Assert.AreEqual(criticalRate > 0 ? 2 : 1, rng.Calls);
        }

        [TestMethod]
        public void Simulate_AbsorbHealsByMinimumDamageInsteadOfLosingHp()
        {
            var attacker = new CombatUnit
            {
                Hp = 20,
                Attack = 10,
                StatusDetail = new Detail { WeaponType = Const.WeaponType.Absorb },
            };
            var defender = new CombatUnit { Defense = 20, PhaseCount = 0 };

            var result = CombatSimulator.Simulate(CombatRngServiceFactory.Create(new SequenceRng()), attacker, defender, false, false);

            Assert.AreEqual(29, result.DefenderHp);
            Assert.AreEqual(21, result.AttackerHp);
        }

        private sealed class SequenceRng(params ushort[] values) : IRng
        {
            public int Calls { get; private set; }

            public ushort Next()
            {
                var index = Calls++;
                return index < values.Length ? values[index] : (ushort)0;
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
}
