using FERNGSolver.Gba.Domain.Combat;
using FERNGSolver.Gba.Domain.Combat.Service;

namespace FERNGSolver.Gba.Domain.Tests.Combat;

[TestClass]
public class CombatRngServiceTests
{
    [DataTestMethod]
    [DataRow(0, 0, 0, false)]
    [DataRow(49, 50, 50, true)]
    [DataRow(50, 50, 50, false)]
    [DataRow(99, 99, 100, true)]
    [DataRow(100, 100, 100, false)]
    public void CheckHit_UsesTwoNumbersAndTruncatesTheAverage(int first, int second, int rate, bool expected)
    {
        var rng = new SequenceRng((ushort)first, (ushort)second);

        Assert.AreEqual(expected, CombatRngServiceFactory.Create(rng).CheckHit(rate, UnitSide.Player));
        Assert.AreEqual(2, rng.Consumed);
    }

    [DataTestMethod]
    [DataRow(0, 0, false)]
    [DataRow(19, 20, true)]
    [DataRow(20, 20, false)]
    [DataRow(99, 100, true)]
    public void CriticalAndLevelBasedSkills_UseStrictThresholdAndOneNumber(int value, int rate, bool expected)
    {
        foreach (var side in new[] { UnitSide.Player, UnitSide.Enemy })
        {
            var rng = new SequenceRng((ushort)value, (ushort)value, (ushort)value, (ushort)value);
            var service = CombatRngServiceFactory.Create(rng);

            Assert.AreEqual(expected, service.CheckCritical(rate, side));
            Assert.AreEqual(expected, service.CheckActivateSureStrike(rate, side));
            Assert.AreEqual(expected, service.CheckActivatePierce(rate, side));
            Assert.AreEqual(expected, service.CheckActivateGreatShield(rate, side));
            Assert.AreEqual(4, rng.Consumed);
        }
    }

    [DataTestMethod]
    [DataRow(Const.BossType.None, 49, true, true)]
    [DataRow(Const.BossType.None, 50, true, false)]
    [DataRow(Const.BossType.Boss, 24, true, true)]
    [DataRow(Const.BossType.Boss, 25, true, false)]
    [DataRow(Const.BossType.None, 0, false, false)]
    [DataRow(Const.BossType.Boss, 0, false, false)]
    public void CheckActivateSilencer_UsesBossThresholdAndConsumesEvenWithoutSkill(
        Const.BossType boss, int value, bool hasSkill, bool expected)
    {
        var rng = new SequenceRng((ushort)value);

        Assert.AreEqual(expected, CombatRngServiceFactory.Create(rng).CheckActivateSilencer(boss, hasSkill, UnitSide.Player));
        Assert.AreEqual(1, rng.Consumed);
    }

    [DataTestMethod]
    [DataRow(0, 30, true)]
    [DataRow(0, 31, false)]
    [DataRow(30, 0, true)]
    [DataRow(30, 1, false)]
    [DataRow(31, 0, false)]
    [DataRow(40, 0, false)]
    public void CheckActivateCurse_UsesLuckAndClampsRateAtZero(int luck, int value, bool expected)
    {
        var rng = new SequenceRng((ushort)value);

        Assert.AreEqual(expected, CombatRngServiceFactory.Create(rng).CheckActivateCurse(luck, UnitSide.Player));
        Assert.AreEqual(1, rng.Consumed);
    }

    [TestMethod]
    public void SetRng_SubsequentChecksConsumeOnlyReplacementRng()
    {
        var original = new SequenceRng(0);
        var replacement = new SequenceRng(99);
        var service = CombatRngServiceFactory.Create(original);

        service.SetRng(replacement);

        Assert.IsFalse(service.CheckCritical(50, UnitSide.Enemy));
        Assert.AreEqual(0, original.Consumed);
        Assert.AreEqual(1, replacement.Consumed);
    }
}
