using FERNGSolver.Internal;

namespace FERNGSolver.Tests.Internal
{
    [TestClass]
    public class SerializerTests
    {
        private string m_FilePath = null!;

        [TestInitialize]
        public void Initialize()
        {
            m_FilePath = Path.Combine(Path.GetTempPath(), $"FERNGSolver.SerializerTests.{Guid.NewGuid():N}.json");
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(m_FilePath);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("{")]
        [DataRow("{\"SelectingTitle\":")]
        [DataRow("{\"SelectingTitle\":42}")]
        [DataRow("null")]
        public void Deserialize_InvalidOrNullJson_ReturnsDefaultConfig(string content)
        {
            File.WriteAllText(m_FilePath, content);

            var result = new Serializer().Deserialize<TestConfig>(m_FilePath);

            Assert.AreEqual("蒼炎の軌跡", result.SelectingTitle);
        }

        [TestMethod]
        public void Deserialize_MissingFile_ReturnsDefaultConfig()
        {
            var result = new Serializer().Deserialize<TestConfig>(m_FilePath);

            Assert.AreEqual("蒼炎の軌跡", result.SelectingTitle);
        }

        [TestMethod]
        public void SerializeAndDeserialize_PreservesSelectedTitle()
        {
            var serializer = new Serializer();

            Assert.IsTrue(serializer.Serialize(m_FilePath, new TestConfig { SelectingTitle = "聖戦の系譜" }, out var error), error);
            var result = serializer.Deserialize<TestConfig>(m_FilePath);

            Assert.AreEqual("聖戦の系譜", result.SelectingTitle);
        }

        public sealed class TestConfig
        {
            public string SelectingTitle { get; set; } = "蒼炎の軌跡";
        }
    }
}
