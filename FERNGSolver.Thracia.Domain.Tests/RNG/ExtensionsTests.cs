using FERNGSolver.Thracia.Domain.RNG;

namespace FERNGSolver.Thracia.Domain.Tests.RNG
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        [DataRow(0, false)]
        [DataRow(1, false)]
        [DataRow(2, true)]
        [DataRow(3, false)]
        [DataRow(4, true)]
        [DataRow(5, true)]
        [DataRow(6, false)]
        [DataRow(7, true)]
        [DataRow(8, false)]
        [DataRow(9, false)]
        [DataRow(10, true)]
        [DataRow(11, false)]
        [DataRow(12, false)]
        [DataRow(13, true)]
        [DataRow(14, false)]
        [DataRow(15, true)]
        [DataRow(16, true)]
        [DataRow(17, false)]
        [DataRow(18, true)]
        [DataRow(19, true)]
        [DataRow(20, false)]
        [DataRow(21, true)]
        [DataRow(22, false)]
        [DataRow(23, false)]
        [DataRow(24, true)]
        [DataRow(25, false)] // Testing modulo behavior
        [DataRow(50, false)] // Testing modulo behavior
        [DataRow(52, true)]  // Testing modulo behavior
        public void ToCx_ShouldReturnExpectedResult(int value, bool expected)
        {
            // Act
            var result = value.ToCx();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToCx_RNGSequence_ShouldMatchReference()
        {
            // Arrange
            var rng = RngFactory.Create(13);
            var referenceResults = new bool[] { true, true, false, true, true, true, true }; // Replace with actual reference results
            //            var referenceResults = new bool[] { false, false, true, true, false, true, true, false, false, false, false, true }; // Replace with actual reference results
            var generatedResults = new List<bool>();

            // Act
            for (int i = 0; i < referenceResults.Length; i++)
            {
                var value = rng.Next(); // Replace with the actual method to get the next RNG value
                generatedResults.Add(value.ToCx());
            }

            // Assert
            CollectionAssert.AreEqual(referenceResults, generatedResults);
        }

    }
}
