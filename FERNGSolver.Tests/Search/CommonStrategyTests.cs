using FERNGSolver.Common.Application.Search.Pattern;
using FERNGSolver.Common.Application.Search.Strategy;
using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.FalconKnightTool.Application.Path;

namespace FERNGSolver.Tests.Search;

[TestClass]
public class CommonStrategyTests
{
    [TestMethod]
    public void ConvertPattern_MixedTokensWhitespaceAndTrailingComma_PreservesOrder()
    {
        var pattern = HighOrLowPatternConverter.ConvertFromString(" 50- , 75+ , x, X, 65535-,");

        CollectionAssert.AreEqual(new (ushort, bool)[]
        {
            (50, true), (75, false), (0, false), (0, false), (65535, true)
        }, pattern.ToArray());
    }

    [DataTestMethod]
    [DataRow("50")]
    [DataRow("-")]
    [DataRow("+")]
    [DataRow("-1+")]
    [DataRow("65536-")]
    [DataRow("word+")]
    [DataRow("x-")]
    [DataRow("50- trailing")]
    public void ConvertPattern_MalformedToken_ThrowsFormatException(string input)
    {
        Assert.ThrowsException<FormatException>(() => HighOrLowPatternConverter.ConvertFromString(input));
    }

    [DataTestMethod]
    [DataRow("50-", 49, true)]
    [DataRow("50-", 50, false)]
    [DataRow("50+", 49, false)]
    [DataRow("50+", 50, true)]
    [DataRow("0-", 0, false)]
    [DataRow("0+", 0, true)]
    [DataRow("65535-", 65535, false)]
    [DataRow("65535+", 65535, true)]
    public void HighOrLow_ThresholdEquality_IsFailureOfLessThanCheck(string pattern, int value, bool expected)
    {
        var rng = new SequenceRng((ushort)value);
        var strategy = CommonStrategyFactory.CreateHighOrLowPatternStrategy(
            HighOrLowPatternConverter.ConvertFromString(pattern));

        Assert.AreEqual(expected, strategy.CheckAndAdvance(rng));
        Assert.AreEqual(1, rng.Calls);
    }

    [TestMethod]
    public void HighOrLow_Mismatch_StopsBeforeRemainingTokens()
    {
        var rng = new SequenceRng(49, 74);
        var strategy = CommonStrategyFactory.CreateHighOrLowPatternStrategy(
            HighOrLowPatternConverter.ConvertFromString("50-,75+,x"));

        Assert.IsFalse(strategy.CheckAndAdvance(rng));
        Assert.AreEqual(2, rng.Calls);
    }

    [TestMethod]
    public void Sequential_MatchingStrategies_ShareOneContinuousRng()
    {
        var rng = new SequenceRng(49, 50, 90);
        var strategy = CommonStrategyFactory.CreateSequentialStrategy(
            CommonStrategyFactory.CreateHighOrLowPatternStrategy(new[] { ((ushort)50, true) }),
            CommonStrategyFactory.CreateFalconKnightPatternStrategy(new[] { true, false }, value => value < 80));

        Assert.IsTrue(strategy.CheckAndAdvance(rng));
        Assert.AreEqual(3, rng.Calls);
    }

    [TestMethod]
    public void Sequential_FirstFailure_DoesNotEvaluateLaterStrategy()
    {
        var rng = new SequenceRng(50);
        var strategy = CommonStrategyFactory.CreateSequentialStrategy(
            CommonStrategyFactory.CreateHighOrLowPatternStrategy(new[] { ((ushort)50, true) }),
            CommonStrategyFactory.CreateFalconKnightPatternStrategy(new[] { true }, _ => throw new AssertFailedException("Should not run")));

        Assert.IsFalse(strategy.CheckAndAdvance(rng));
        Assert.AreEqual(1, rng.Calls);
    }

    [TestMethod]
    public void EmptyPatterns_MatchWithoutConsumingRng()
    {
        var rng = new SequenceRng();

        Assert.IsTrue(CommonStrategyFactory.CreateSequentialStrategy().CheckAndAdvance(rng));
        Assert.IsTrue(CommonStrategyFactory.CreateHighOrLowPatternStrategy(
            HighOrLowPatternConverter.ConvertFromString("")).CheckAndAdvance(rng));
        Assert.IsTrue(CommonStrategyFactory.CreateFalconKnightPatternStrategy(
            CxStringConverter.CxStringToBools(""), _ => false).CheckAndAdvance(rng));
        Assert.AreEqual(0, rng.Calls);
    }

    [TestMethod]
    public void CxString_ValidPattern_PreservesOrder()
    {
        CollectionAssert.AreEqual(new[] { true, false, false, true }, CxStringConverter.CxStringToBools("cxxc").ToArray());
    }

    [DataTestMethod]
    [DataRow("C")]
    [DataRow("X")]
    [DataRow("c x")]
    [DataRow("c,x")]
    [DataRow("cx?")]
    public void CxString_UnsupportedCharacter_ThrowsArgumentException(string input)
    {
        Assert.ThrowsException<ArgumentException>(() => CxStringConverter.CxStringToBools(input));
    }

    private sealed class SequenceRng(params ushort[] values) : IRng
    {
        public int Calls { get; private set; }
        public ushort Next()
        {
            Assert.IsTrue(Calls < values.Length, "Unexpected random number consumption.");
            return values[Calls++];
        }
    }
}
