using FERNGSolver.Common.Types;
using FERNGSolver.FalconKnightTool.Application.Path;

namespace FERNGSolver.FalconKnightTool.Application.Tests.Path
{
    [TestClass]
    public class PathConverterTests
    {
        [TestMethod]
        public void EmptyPath_ShouldReturnEmpty()
        {
            var result = PathConverter.PathToCxString(new List<GridPosition>());
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void SinglePoint_ShouldReturnEmpty()
        {
            var result = PathConverter.PathToCxString(new List<GridPosition>
            {
                new GridPosition(0, 0)
            });
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void LinearPath_NoBranch_ShouldReturnEmpty()
        {
            var result = PathConverter.PathToCxString(new List<GridPosition>
            {
                new GridPosition(0, 0),
                new GridPosition(1, 0),
                new GridPosition(2, 0)
            });
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void BranchPath_ShouldReturnX()
        {
            var result = PathConverter.PathToCxString(new List<GridPosition>
            {
                new GridPosition(0, 0),
                new GridPosition(1, 0),
                new GridPosition(1, 1)
            });
            Assert.AreEqual("x", result);
        }

        [TestMethod]
        public void BranchPath_ShouldReturnC()
        {
            var result = PathConverter.PathToCxString(new List<GridPosition>
            {
                new GridPosition(0, 0),
                new GridPosition(0, 1),
                new GridPosition(1, 1)
            });
            Assert.AreEqual("c", result);
        }

        [TestMethod]
        public void MultiStep_BranchAndStraight()
        {
            var result = PathConverter.PathToCxString(new List<GridPosition>
            {
                new GridPosition(0, 0),
                new GridPosition(1, 0),
                new GridPosition(2, 0),
                new GridPosition(2, 1)
            });
            Assert.AreEqual("x", result);
        }
    }
}
