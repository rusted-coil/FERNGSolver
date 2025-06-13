using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Gba.Domain.Combat.Service
{
    public static class CombatRngServiceFactory
    {
        public static IModifiableCombatRngService Create(IRng rng)
        {
            return new Internal.CombatRngService(rng);
        }
    }
}
