using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Genealogy.Application.RNG;
using FERNGSolver.Genealogy.Domain.Combat.Service;
using System.Diagnostics;

namespace FERNGSolver.Genealogy.Presentation.Combat.Internal
{
    internal sealed class RecordingCombatRngService : IModifiableCombatRngService
    {
        List<(RandomNumberUsage Usage, bool IsOk)> m_UsedRandomNumbers = new List<(RandomNumberUsage, bool)>();
        public IReadOnlyList<(RandomNumberUsage Usage, bool IsOk)> UsedRandomNumbers => m_UsedRandomNumbers;

        readonly IModifiableCombatRngService m_Underlying;

        public RecordingCombatRngService(IModifiableCombatRngService underlying)
        {
            m_Underlying = underlying;
        }

        public void SetRng(IRng rng) => m_Underlying.SetRng(rng);

        public bool CheckHit(int hitRate, UnitSide unitSide = UnitSide.None)
        {
            Debug.Assert(unitSide != UnitSide.None);
            bool isOk = m_Underlying.CheckHit(hitRate);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerHit : RandomNumberUsage.EnemyHit, isOk));
            return isOk;
        }

        public bool CheckCritical(int criticalRate, UnitSide unitSide = UnitSide.None)
        {
            Debug.Assert(unitSide != UnitSide.None);
            bool isOk = m_Underlying.CheckCritical(criticalRate);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerCritical : RandomNumberUsage.EnemyCritical, isOk));
            return isOk;
        }

        public bool CheckActivateAstra(int tec, UnitSide unitSide = UnitSide.None)
        {
            Debug.Assert(unitSide != UnitSide.None);
            bool isOk = m_Underlying.CheckActivateAstra(tec);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerAstra : RandomNumberUsage.EnemyAstra, isOk));
            return isOk;
        }

        public bool CheckActivateLuna(int tec, UnitSide unitSide = UnitSide.None)
        {
            Debug.Assert(unitSide != UnitSide.None);
            bool isOk = m_Underlying.CheckActivateLuna(tec);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerLuna : RandomNumberUsage.EnemyLuna, isOk));
            return isOk;
        }

        public bool CheckActivateSol(int tec, UnitSide unitSide = UnitSide.None)
        {
            Debug.Assert(unitSide != UnitSide.None);
            bool isOk = m_Underlying.CheckActivateSol(tec);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerSol : RandomNumberUsage.EnemySol, isOk));
            return isOk;
        }

        public bool CheckActivateContinuation(int attackSpeed, UnitSide unitSide = UnitSide.None)
        {
            Debug.Assert(unitSide != UnitSide.None);
            bool isOk = m_Underlying.CheckActivateContinuation(attackSpeed);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerContinuation : RandomNumberUsage.EnemyContinuation, isOk));
            return isOk;
        }

        public bool CheckActivateGreatShield(int level, UnitSide unitSide = UnitSide.None)
        {
            Debug.Assert(unitSide != UnitSide.None);
            bool isOk = m_Underlying.CheckActivateGreatShield(level);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerGreatShield : RandomNumberUsage.EnemyGreatShield, isOk));
            return isOk;
        }
    }
}
