using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Gba.Domain.Combat.Service
{
    public interface IModifiableCombatRngService : ICombatRngService
    {
        /// <summary>
        /// 使用するRNGを設定します。
        /// </summary>
        void SetRng(IRng rng);
    }
}
