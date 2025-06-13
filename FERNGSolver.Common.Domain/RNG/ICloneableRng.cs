namespace FERNGSolver.Common.Domain.RNG
{
    public interface ICloneableRng : IRng
    {
        /// <summary>
        /// 現在の状態と同じRNGを複製して返します。
        /// </summary>
        ICloneableRng Clone();
    }
}
