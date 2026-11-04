using FERNGSolver.Common.Application.Interfaces;
using MainConfig = FERNGSolver.Application.Config;
using GbaConfig = FERNGSolver.Gba.Application.Config;

namespace FERNGSolver.Tests.Config;

[TestClass]
public class ConfigServiceTests
{
    [TestMethod]
    public void MainConfig_LoadAndSave_PreservesUpdatedTitleAndUsesSameFile()
    {
        var storage = new MemoryStorage();
        var service = MainConfig.ConfigServiceFactory.Create(storage, storage, storage);

        Assert.AreEqual("聖戦の系譜", service.Config.SelectingTitle);
        Assert.AreEqual("config.json", storage.LoadPath);
        service.Config.SelectingTitle = "トラキア776";
        service.Serialize();

        Assert.AreEqual(storage.LoadPath, storage.SavePath);
        Assert.AreSame(service.Config, storage.SavedValue);
        Assert.AreEqual("トラキア776", ((MainConfig.IConfig)storage.SavedValue!).SelectingTitle);
        Assert.AreEqual(0, storage.Errors.Count);
    }

    [TestMethod]
    public void GbaConfig_LoadAndSave_PreservesTitleSpecificRngSetting()
    {
        var storage = new MemoryStorage();
        var service = GbaConfig.ConfigServiceFactory.Create(storage, storage, storage);

        Assert.IsTrue(service.Config.IsBindingBlade);
        Assert.AreEqual("config.gba.json", storage.LoadPath);
        service.Config.IsBindingBlade = false;
        service.Serialize();

        Assert.AreEqual(storage.LoadPath, storage.SavePath);
        Assert.AreSame(service.Config, storage.SavedValue);
        Assert.IsFalse(((GbaConfig.IConfig)storage.SavedValue!).IsBindingBlade);
        Assert.AreEqual(0, storage.Errors.Count);
    }

    [DataTestMethod]
    [DataRow(false)]
    [DataRow(true)]
    public void SaveFailure_NotifiesErrorAndAllowsRetry(bool gba)
    {
        var storage = new MemoryStorage { SaveSucceeds = false };
        Action save = gba
            ? GbaConfig.ConfigServiceFactory.Create(storage, storage, storage).Serialize
            : MainConfig.ConfigServiceFactory.Create(storage, storage, storage).Serialize;

        save();

        CollectionAssert.AreEqual(new[] { "保存できません" }, storage.Errors);
        storage.SaveSucceeds = true;
        save();
        Assert.AreEqual(2, storage.SaveCalls);
        Assert.AreEqual(1, storage.Errors.Count);
    }

    private sealed class MemoryStorage : ISerializer, IDeserializer, IErrorNotifier
    {
        public bool SaveSucceeds { get; set; } = true;
        public int SaveCalls { get; private set; }
        public string? LoadPath { get; private set; }
        public string? SavePath { get; private set; }
        public object? SavedValue { get; private set; }
        public List<string> Errors { get; } = new();

        public T Deserialize<T>(string filePath) where T : new()
        {
            LoadPath = filePath;
            var config = new T();
            if (config is MainConfig.IModifiableConfig main)
                main.SelectingTitle = "聖戦の系譜";
            if (config is GbaConfig.IModifiableConfig gba)
                gba.IsBindingBlade = true;
            return config;
        }

        public bool Serialize<T>(string filePath, T data, out string errorMessage)
        {
            SaveCalls++;
            SavePath = filePath;
            SavedValue = data;
            errorMessage = SaveSucceeds ? string.Empty : "保存できません";
            return SaveSucceeds;
        }

        public void NotifyError(string message) => Errors.Add(message);
    }
}
