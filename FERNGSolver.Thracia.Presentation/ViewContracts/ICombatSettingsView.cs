namespace FERNGSolver.Thracia.Presentation.ViewContracts
{
    public interface ICombatSettingsView
    {
        /// <summary>
        /// 戦闘を行うかどうかを取得します。
        /// </summary>
        bool ContainsCombat { get; }
    }
}
