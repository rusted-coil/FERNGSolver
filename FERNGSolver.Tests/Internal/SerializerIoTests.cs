using FERNGSolver.Internal;

namespace FERNGSolver.Tests.Internal;

[TestClass]
public class SerializerIoTests
{
    private string directory = null!;
    private string filePath = null!;

    [TestInitialize]
    public void Initialize()
    {
        directory = Path.Combine(Path.GetTempPath(), $"FERNGSolver.SerializerIoTests.{Guid.NewGuid():N}");
        filePath = Path.Combine(directory, "config.json");
    }

    [TestCleanup]
    public void Cleanup()
    {
        File.Delete(filePath);
        if (Directory.Exists(directory))
            Directory.Delete(directory);
    }

    [TestMethod]
    public void Serialize_CreatesMissingDirectoryAndOverwritesPreviousContent()
    {
        var serializer = new Serializer();
        Assert.IsFalse(Directory.Exists(directory));

        Assert.IsTrue(serializer.Serialize(filePath, new Config { Title = "蒼炎の軌跡" }, out var firstError), firstError);
        Assert.AreEqual(string.Empty, firstError);
        Assert.AreEqual("蒼炎の軌跡", serializer.Deserialize<Config>(filePath).Title);
        Assert.IsTrue(serializer.Serialize(filePath, new Config { Title = "烈火" }, out var secondError), secondError);
        Assert.AreEqual("烈火", serializer.Deserialize<Config>(filePath).Title);
    }

    [TestMethod]
    public void Serialize_DirectoryInPlaceOfFile_ReturnsErrorWithoutThrowing()
    {
        Directory.CreateDirectory(directory);

        var succeeded = new Serializer().Serialize(directory, new Config(), out var error);

        Assert.IsFalse(succeeded);
        Assert.IsFalse(string.IsNullOrWhiteSpace(error));
        Assert.IsTrue(Directory.Exists(directory));
    }

    [TestMethod]
    public void Deserialize_DirectoryInPlaceOfFile_ReturnsDefaults()
    {
        Directory.CreateDirectory(directory);

        Assert.AreEqual("default", new Serializer().Deserialize<Config>(directory).Title);
    }

    public sealed class Config
    {
        public string Title { get; set; } = "default";
    }
}
