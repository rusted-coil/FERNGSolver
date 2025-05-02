namespace FERNGSolver.Common.Interfaces
{
    /// <summary>
    /// UserControlを生成できる抽象ファクトリクラスです。
    /// </summary>
    public interface IUserControlFactory
    {
        /// <summary>
        /// UserControlを生成します。
        /// </summary>
        UserControl Create();
    }
}
