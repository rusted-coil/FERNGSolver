namespace FERNGSolver.Thracia.Presentation.ViewContracts
{
    public interface IGrowthSettingsView
    {
        /// <summary>
        /// レベルアップを行うかどうかを取得します。
        /// </summary>
        bool ContainsGrowth { get; }
    }
}
