using FERNGSolver.Common.Domain.RNG;
using FERNGSolver.Genealogy.Application.RNG;
using FERNGSolver.Genealogy.Domain.Combat.Service;

namespace FERNGSolver.Genealogy.Presentation.Combat.Internal
{
    internal sealed class RecordingCombatRngService : IModifiableCombatRngService
    {
        public class UsedRandomNumber
        {
            public RandomNumberUsage Usage { get; init; }
            public bool IsOk { get; init; }
            public int RoundIndex { get; init; }
        }

        List<UsedRandomNumber> m_UsedRandomNumbers = new List<UsedRandomNumber>();
        public IReadOnlyList<UsedRandomNumber> UsedRandomNumbers => m_UsedRandomNumbers;

        readonly IModifiableCombatRngService m_Underlying;

        public RecordingCombatRngService(IModifiableCombatRngService underlying)
        {
            m_Underlying = underlying;
        }

        public void SetRng(IRng rng) => m_Underlying.SetRng(rng);

        public bool CheckHit(int hitRate, UnitSide unitSide, int roundIndex)
        {
            bool isOk = m_Underlying.CheckHit(hitRate, unitSide, roundIndex);
            m_UsedRandomNumbers.Add(
                new UsedRandomNumber {
                    Usage = unitSide == UnitSide.Player ? RandomNumberUsage.PlayerHit : RandomNumberUsage.EnemyHit,
                    IsOk = isOk,
                    RoundIndex = roundIndex
                });
            return isOk;
        }

        public bool CheckCritical(int criticalRate, UnitSide unitSide, int roundIndex)
        {
            bool isOk = m_Underlying.CheckCritical(criticalRate, unitSide, roundIndex);
            m_UsedRandomNumbers.Add(
                new UsedRandomNumber {
                    Usage = unitSide == UnitSide.Player ? RandomNumberUsage.PlayerCritical : RandomNumberUsage.EnemyCritical,
                    IsOk = isOk,
                    RoundIndex = roundIndex
                });
            return isOk;
        }

        public bool CheckSleep(int sleepRate, UnitSide unitSide, int roundIndex)
        {
            bool isOk = m_Underlying.CheckSleep(sleepRate, unitSide, roundIndex);
            // 内部処理に依存してしまうが、判定OKだった場合は2個、NGだった場合は1個の乱数を消費する
            if (isOk)
            {
                m_UsedRandomNumbers.Add(
                    new UsedRandomNumber {
                        Usage = unitSide == UnitSide.Player ? RandomNumberUsage.PlayerSleep : RandomNumberUsage.EnemySleep,
                        IsOk = true,
                        RoundIndex = roundIndex
                    });
                m_UsedRandomNumbers.Add(
                    new UsedRandomNumber {
                        Usage = unitSide == UnitSide.Player ? RandomNumberUsage.PlayerSleepTurn : RandomNumberUsage.EnemySleepTurn,
                        IsOk = false,
                        RoundIndex = roundIndex
                    });
            }
            else
            {
                m_UsedRandomNumbers.Add(
                    new UsedRandomNumber {
                        Usage = unitSide == UnitSide.Player ? RandomNumberUsage.PlayerSleep : RandomNumberUsage.EnemySleep,
                        IsOk = false,
                        RoundIndex = roundIndex
                    });
            }
            return isOk;
        }

        public bool CheckActivateAssault(int attackSpeed, int opponentAttackSpeed, int attackerHp, UnitSide unitSide, int roundIndex)
        {
            bool isOk = m_Underlying.CheckActivateAssault(attackSpeed, opponentAttackSpeed, attackerHp, unitSide, roundIndex);
            m_UsedRandomNumbers.Add(
                new UsedRandomNumber {
                    Usage = unitSide == UnitSide.Player ? RandomNumberUsage.PlayerAssault : RandomNumberUsage.EnemyAssault,
                    IsOk = isOk,
                    RoundIndex = roundIndex
                });
            return isOk;
        }

        public bool CheckActivateAstra(int tec, UnitSide unitSide, int roundIndex)
        {
            bool isOk = m_Underlying.CheckActivateAstra(tec, unitSide, roundIndex);
            m_UsedRandomNumbers.Add(
                new UsedRandomNumber {
                    Usage = unitSide == UnitSide.Player ? RandomNumberUsage.PlayerAstra : RandomNumberUsage.EnemyAstra,
                    IsOk = isOk,
                    RoundIndex = roundIndex
                });
            return isOk;
        }

        public bool CheckActivateLuna(int tec, UnitSide unitSide, int roundIndex)
        {
            bool isOk = m_Underlying.CheckActivateLuna(tec, unitSide, roundIndex);
            m_UsedRandomNumbers.Add(
                new UsedRandomNumber {
                    Usage = unitSide == UnitSide.Player ? RandomNumberUsage.PlayerLuna : RandomNumberUsage.EnemyLuna,
                    IsOk = isOk,
                    RoundIndex = roundIndex
                });
            return isOk;
        }

        public bool CheckActivateSol(int tec, UnitSide unitSide, int roundIndex)
        {
            bool isOk = m_Underlying.CheckActivateSol(tec, unitSide, roundIndex);
            m_UsedRandomNumbers.Add(
                new UsedRandomNumber {
                    Usage = unitSide == UnitSide.Player ? RandomNumberUsage.PlayerSol : RandomNumberUsage.EnemySol,
                    IsOk = isOk,
                    RoundIndex = roundIndex
                });
            return isOk;
        }

        public bool CheckActivateContinuation(int attackSpeed, UnitSide unitSide, int roundIndex)
        {
            bool isOk = m_Underlying.CheckActivateContinuation(attackSpeed, unitSide, roundIndex);
            m_UsedRandomNumbers.Add(
                new UsedRandomNumber {
                    Usage = unitSide == UnitSide.Player ? RandomNumberUsage.PlayerContinuation : RandomNumberUsage.EnemyContinuation,
                    IsOk = isOk,
                    RoundIndex = roundIndex
                });
            return isOk;
        }

        public bool CheckActivateGreatShield(int level, UnitSide unitSide, int roundIndex)
        {
            bool isOk = m_Underlying.CheckActivateGreatShield(level, unitSide, roundIndex);
            m_UsedRandomNumbers.Add(
                new UsedRandomNumber {
                    Usage = unitSide == UnitSide.Player ? RandomNumberUsage.PlayerGreatShield : RandomNumberUsage.EnemyGreatShield,
                    IsOk = isOk,
                    RoundIndex = roundIndex
                });
            return isOk;
        }
    }
}
