using FERNGSolver.Common.Application.Search.Pattern;
using FERNGSolver.Common.Application.Search.Strategy;
using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Genealogy.Domain.RNG;

namespace FERNGSolver.Genealogy.Domain.Tests.RNG
{
    [TestClass]
    public class HighOrLowPatternTests
    {
        [TestMethod]
        [DataRow("x")]
        [DataRow("X")]
        public void WildcardAcceptsEntireRandomNumberRange(string pattern)
        {
            var strategy = CommonStrategyFactory.CreateHighOrLowPatternStrategy(HighOrLowPatternConverter.ConvertFromString(pattern));
            for (ushort value = 0; value < 100; ++value)
            {
                var rng = new FixedRng(value);
                Assert.IsTrue(strategy.CheckAndAdvance(rng), $"Wildcard rejected RN {value}");
                Assert.AreEqual(1, rng.Calls);
            }
        }

        [TestMethod]
        public void WildcardMatchesGenealogyRn99AtOffset167()
        {
            var rng = RngFactory.Create();
            rng.Advance(167);
            Assert.AreEqual((ushort)99, rng.Clone().Next());

            var strategy = CommonStrategyFactory.CreateHighOrLowPatternStrategy(HighOrLowPatternConverter.ConvertFromString("x"));

            Assert.IsTrue(strategy.CheckAndAdvance(rng));
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(65535)]
        public void WildcardDoesNotAssumeAnRngUpperBound(int value)
        {
            var strategy = CommonStrategyFactory.CreateHighOrLowPatternStrategy(HighOrLowPatternConverter.ConvertFromString("x"));

            Assert.IsTrue(strategy.CheckAndAdvance(new FixedRng((ushort)value)));
        }

        [TestMethod]
        [DataRow("99-", false)]
        [DataRow("99+", true)]
        public void NumericThresholdStillUsesStrictLessThan(string pattern, bool expected)
        {
            var strategy = CommonStrategyFactory.CreateHighOrLowPatternStrategy(HighOrLowPatternConverter.ConvertFromString(pattern));

            Assert.AreEqual(expected, strategy.CheckAndAdvance(new FixedRng(99)));
        }

        private sealed class FixedRng(ushort value) : IRng
        {
            public int Calls { get; private set; }
            public ushort Next()
            {
                Calls++;
                return value;
            }
        }
    }
}
