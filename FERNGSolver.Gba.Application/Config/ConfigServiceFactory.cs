using FERNGSolver.Common.Application.Interfaces;

namespace FERNGSolver.Gba.Application.Config
{
    public static class ConfigServiceFactory
    {
        /// <summary>
        /// GBAの設定関連のサービスを提供するインターフェースを取得します。
        /// </summary>
        public static IConfigService Create(ISerializer serializer, IDeserializer deserializer, IErrorNotifier errorNotifier)
        {
            return new Internal.ConfigService(serializer, deserializer, errorNotifier);
        }
    }
}
