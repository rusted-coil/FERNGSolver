using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Radiance.Domain.Combat;
using FERNGSolver.Radiance.Domain.Combat.Service;

namespace FERNGSolver.Radiance.Domain.Tests.Combat
{
    [TestClass]
    public class CombatSimulatorTests
    {
        [TestMethod]
        public void OrdinaryHit_DoesNotClampAttackerHpToUnusedDetailMaximum()
        {
            var rng = new CountingRng();
            var attacker = new CombatUnit { Hp = 40, Power = 10 };
            var defender = new CombatUnit { Hp = 30, PhaseCount = 0 };

            var result = CombatSimulator.Simulate(CombatRngServiceFactory.Create(rng), attacker, defender);

            Assert.AreEqual(40, result.AttackerHp);
            Assert.AreEqual(20, result.DefenderHp);
            Assert.AreEqual(3, rng.Consumed, "命中2個と必殺1個の乱数消費は変えない。");
        }

        [TestMethod]
        [DataRow(false, Const.WeaponType.Absorb, 20, 30)]
        [DataRow(true, Const.WeaponType.Normal, 20, 30)]
        [DataRow(false, Const.WeaponType.Absorb, 10, 25)]
        [DataRow(true, Const.WeaponType.Normal, 10, 25)]
        public void HealingHit_HealsAndRespectsMaximum(bool hasSol, Const.WeaponType weaponType, int power, int expectedHp)
        {
            var attacker = new CombatUnit
            {
                Hp = 15,
                Power = power,
                StatusDetail = new Detail { HasSol = hasSol, WeaponType = weaponType, MaxHp = 30 },
            };
            var defender = new CombatUnit { Hp = 50, PhaseCount = 0 };

            var result = CombatSimulator.Simulate(CombatRngServiceFactory.Create(new CountingRng()), attacker, defender);

            Assert.AreEqual(expectedHp, result.AttackerHp);
            Assert.AreEqual(50 - power, result.DefenderHp);
        }

        [TestMethod]
        [DataRow(false, Const.WeaponType.Absorb)]
        [DataRow(true, Const.WeaponType.Normal)]
        public void ZeroHealing_DoesNotReduceAttackerHp(bool hasSol, Const.WeaponType weaponType)
        {
            var attacker = new CombatUnit
            {
                Hp = 40,
                Power = 0,
                StatusDetail = new Detail { HasSol = hasSol, WeaponType = weaponType, MaxHp = 30 },
            };
            var defender = new CombatUnit { Hp = 30, PhaseCount = 0 };

            var result = CombatSimulator.Simulate(CombatRngServiceFactory.Create(new CountingRng()), attacker, defender);

            Assert.AreEqual(40, result.AttackerHp);
            Assert.AreEqual(30, result.DefenderHp);
        }

        private sealed class CountingRng : IRng
        {
            public int Consumed { get; private set; }
            public ushort Next()
            {
                ++Consumed;
                return 0;
            }
        }

        private sealed class CombatUnit : ICombatUnit
        {
            public int Hp { get; init; } = 30;
            public int Power { get; init; }
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
}
