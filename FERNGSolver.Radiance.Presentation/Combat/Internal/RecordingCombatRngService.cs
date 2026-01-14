using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Radiance.Application.RNG;
using FERNGSolver.Radiance.Domain.Combat.Service;

namespace FERNGSolver.Radiance.Presentation.Combat.Internal
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

        public bool CheckHit(int hitRate, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckHit(hitRate, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerHit1 : RandomNumberUsage.EnemyHit1, isOk));
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerHit2 : RandomNumberUsage.EnemyHit2, isOk));
            return isOk;
        }

        public bool CheckCritical(int criticalRate, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckCritical(criticalRate, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerCritical : RandomNumberUsage.EnemyCritical, isOk));
            return isOk;
        }

        public bool CheckActivateAdept(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateAdept(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerAdept : RandomNumberUsage.EnemyAdept, isOk));
            return isOk;
        }

        public bool CheckActivateAether(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateAether(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerAether : RandomNumberUsage.EnemyAether, isOk));
            return isOk;
        }

        public bool CheckActivateAstra(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateAstra(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerAstra : RandomNumberUsage.EnemyAstra, isOk));
            return isOk;
        }

        public bool CheckActivateLuna(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateLuna(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerLuna : RandomNumberUsage.EnemyLuna, isOk));
            return isOk;
        }

        public bool CheckActivateSol(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateSol(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerSol : RandomNumberUsage.EnemySol, isOk));
            return isOk;
        }

        public bool CheckActivateFlare(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateFlare(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerFlare : RandomNumberUsage.EnemyFlare, isOk));
            return isOk;
        }

        public bool CheckActivateLethality(UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateLethality(unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerLethality : RandomNumberUsage.EnemyLethality, isOk));
            return isOk;
        }

        public bool CheckActivateCorrode(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateCorrode(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerCorrode : RandomNumberUsage.EnemyCorrode, isOk));
            return isOk;
        }

        public bool CheckActivateStun(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateStun(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerStun : RandomNumberUsage.EnemyStun, isOk));
            return isOk;
        }

        public bool CheckActivateColossus(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateColossus(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerColossus : RandomNumberUsage.EnemyColossus, isOk));
            return isOk;
        }

        public bool CheckActivateCounter(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateCounter(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerCounter : RandomNumberUsage.EnemyCounter, isOk));
            return isOk;
        }

        public bool CheckActivateMiracle(int luck, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateMiracle(luck, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerMiracle : RandomNumberUsage.EnemyMiracle, isOk));
            return isOk;
        }

        public bool CheckActivateGuard(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateGuard(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerGuard : RandomNumberUsage.EnemyGuard, isOk));
            return isOk;
        }

        public bool CheckActivateDeadeye(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateDeadeye(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerDeadeye : RandomNumberUsage.EnemyDeadeye, isOk));
            return isOk;
        }

        public bool CheckActivateCancel(int tec, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateCancel(tec, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerCancel : RandomNumberUsage.EnemyCancel, isOk));
            return isOk;
        }
    }
}
