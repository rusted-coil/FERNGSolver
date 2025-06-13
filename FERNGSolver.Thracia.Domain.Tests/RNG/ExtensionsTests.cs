using FERNGSolver.Thracia.Domain.RNG;

namespace FERNGSolver.Thracia.Domain.Tests.RNG
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        [DataRow(0, true)]
        [DataRow(1, false)]
        [DataRow(2, true)]
        [DataRow(3, false)]
        [DataRow(4, false)]
        [DataRow(5, true)]
        [DataRow(6, false)]
        [DataRow(7, true)]
        [DataRow(8, true)]
        [DataRow(9, false)]
        [DataRow(10, true)]
        [DataRow(11, true)]
        [DataRow(12, false)]
        [DataRow(13, true)]
        [DataRow(14, false)]
        [DataRow(15, false)]
        [DataRow(16, true)]
        [DataRow(17, false)]
        [DataRow(18, false)]
        [DataRow(19, true)]
        [DataRow(20, false)]
        [DataRow(21, true)]
        [DataRow(22, true)]
        [DataRow(23, false)]
        [DataRow(24, true)] // Testing modulo behavior
        [DataRow(49, true)] // Testing modulo behavior
        [DataRow(51, false)]  // Testing modulo behavior
        public void ToCx_ShouldReturnExpectedResult(int value, bool expected)
        {
            // Act
            var result = Util.IsRngValueOk((ushort)value);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToCx_RNGSequence_ShouldMatchReference()
        {
            // Arrange
            var rng = RngFactory.Create(13);
            var referenceResults = new bool[] { true, true, false, true, true, true, true }; // Replace with actual reference results
            var generatedResults = new List<bool>();

            // Act
            for (int i = 0; i < referenceResults.Length; i++)
            {
                var value = rng.Next(); // Replace with the actual method to get the next RNG value
                generatedResults.Add(Util.IsRngValueOk(value));
            }

            // Assert
            CollectionAssert.AreEqual(referenceResults, generatedResults);
        }

    }
}
