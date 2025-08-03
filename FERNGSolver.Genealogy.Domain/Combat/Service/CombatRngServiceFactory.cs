using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Genealogy.Domain.Combat.Service
{
    public static class CombatRngServiceFactory
    {
        public static IModifiableCombatRngService Create(IRng rng)
        {
            return new Internal.CombatRngService(rng);
        }
    }
}
