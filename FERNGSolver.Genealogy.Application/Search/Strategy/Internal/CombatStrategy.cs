using FERNGSolver.Common.Application.Search.Strategy;
using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Genealogy.Domain.Combat;
using FERNGSolver.Genealogy.Domain.Combat.Service;
using FERNGSolver.Genealogy.Domain.RNG;

namespace FERNGSolver.Genealogy.Application.Search.Strategy.Internal
{
    internal sealed class CombatStrategy : ISearchStrategy
    {
        private readonly IModifiableCombatRngService m_CombatRngService; // CheckAndAdvanceを何度も呼ぶことになるのでサービスはキャッシュしておく

        private readonly CombatStrategyArgs m_Args;

        public CombatStrategy(CombatStrategyArgs args)
        {
            m_Args = args;

            m_CombatRngService = CombatRngServiceFactory.Create(RngFactory.Create());
        }

        public bool CheckAndAdvance(IRng rng)
        {
            m_CombatRngService.SetRng(rng);
            var result = CombatSimulator.Simulate(m_CombatRngService, m_Args.Attacker, m_Args.Defender, m_Args.IsArena, m_Args.IsOpponentFirst);

            // HP事後条件チェック
            if (result.AttackerHp < m_Args.AttackerHpPostconditionMin || result.AttackerHp > m_Args.AttackerHpPostconditionMax
                || result.DefenderHp < m_Args.DefenderHpPostconditionMin || result.DefenderHp > m_Args.DefenderHpPostconditionMax)
            {
                return false;
            }

            return true;
        }
    }
}
