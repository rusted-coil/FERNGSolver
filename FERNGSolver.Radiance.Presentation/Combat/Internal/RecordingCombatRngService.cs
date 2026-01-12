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

        public bool CheckActivateSureStrike(int level, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateSureStrike(level, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerSureStrike : RandomNumberUsage.EnemySureStrike, isOk));
            return isOk;
        }

        public bool CheckActivatePierce(int level, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivatePierce(level, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerPierce : RandomNumberUsage.EnemyPierce, isOk));
            return isOk;
        }

        public bool CheckActivateGreatShield(int level, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateGreatShield(level, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerGreatShield : RandomNumberUsage.EnemyGreatShield, isOk));
            return isOk;
        }

        public bool CheckActivateSilencer(Domain.Combat.Const.BossType bossType, bool hasSkill, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateSilencer(bossType, hasSkill, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerSilencer : RandomNumberUsage.EnemySilencer, isOk));
            return isOk;
        }

        public bool CheckActivateCurse(int luck, UnitSide unitSide)
        {
            bool isOk = m_Underlying.CheckActivateCurse(luck, unitSide);
            m_UsedRandomNumbers.Add((unitSide == UnitSide.Player ? RandomNumberUsage.PlayerCurse : RandomNumberUsage.EnemyCurse, isOk));
            return isOk;
        }
    }
}
