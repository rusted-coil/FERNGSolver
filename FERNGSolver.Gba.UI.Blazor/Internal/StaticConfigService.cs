using FERNGSolver.Gba.Application.Config;

namespace FERNGSolver.Gba.UI.Blazor.Internal
{
    /// <summary>
    /// プロトタイプ用の簡易コンフィグです。
    /// <para> * タイトルごとに固定した<see cref="IsBindingBlade"/>を保持するだけで、永続化は行いません。</para>
    /// </summary>
    internal sealed class StaticConfig : IModifiableConfig
    {
        public bool IsBindingBlade { get; set; }

        public StaticConfig(bool isBindingBlade)
        {
            IsBindingBlade = isBindingBlade;
        }
    }

    /// <summary>
    /// プロトタイプ用の簡易コンフィグサービスです。
    /// <para> * Web版はタイトルごとに別ビルドのため、コンフィグの永続化は行わず固定値を返します。</para>
    /// </summary>
    internal sealed class StaticConfigService : IConfigService
    {
        public IModifiableConfig Config { get; }

        public StaticConfigService(bool isBindingBlade)
        {
            Config = new StaticConfig(isBindingBlade);
        }

        public void Serialize()
        {
            // Web版プロトタイプでは永続化を行いません。
        }
    }
}
