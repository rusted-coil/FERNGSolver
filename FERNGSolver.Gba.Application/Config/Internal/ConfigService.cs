using FERNGSolver.Common.Interfaces;
using FERNGSolver.Common.ViewContracts;

namespace FERNGSolver.Gba.Application.Config.Internal
{
    internal sealed class ConfigService : IConfigService
    {
        internal static string ConfigFilePath => "config.gba.json";

        public IModifiableConfig Config => m_Config;

        private Config m_Config;
        private readonly ISerializer m_Serializer;
        private readonly IErrorNotifier m_ErrorNotifier;

        public ConfigService(ISerializer serializer, IDeserializer deserializer, IErrorNotifier errorNotifier)
        {
            m_Serializer = serializer;
            m_ErrorNotifier = errorNotifier;

            m_Config = deserializer.Deserialize<Config>(ConfigFilePath);
        }

        public void Serialize()
        {
            if (!m_Serializer.Serialize(ConfigFilePath, m_Config, out var errorMessage))
            {
                m_ErrorNotifier.NotifyError(errorMessage);
            }
        }
    }
}
