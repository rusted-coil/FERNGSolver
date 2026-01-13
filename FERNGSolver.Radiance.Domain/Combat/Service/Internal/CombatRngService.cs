using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Radiance.Domain.Combat.Service.Internal
{
    internal sealed class CombatRngService : IModifiableCombatRngService
    {
        private IRng m_Rng;

        public CombatRngService(IRng rng)
        {
            m_Rng = rng;
        }

        public void SetRng(IRng rng)
        {
            m_Rng = rng;
        }

        // 命中判定: 2個の平均
        public bool CheckHit(int hitRate, UnitSide unitSide) => (m_Rng.Next() + m_Rng.Next()) / 2 < hitRate;

        // 必殺判定
        public bool CheckCritical(int criticalRate, UnitSide unitSide) => m_Rng.Next() < criticalRate;

        // 連続判定
        public bool CheckActivateAdept(int tec, UnitSide unitSide) => m_Rng.Next() < tec;

        // 天空判定
        public bool CheckActivateAether(int tec, UnitSide unitSide) => m_Rng.Next() < tec;

        // 流星判定
        public bool CheckActivateAstra(int tec, UnitSide unitSide) => m_Rng.Next() < tec / 2;

        // デビルアクス
        public bool CheckActivateCurse(int luck, UnitSide unitSide) => m_Rng.Next() < Util.GetCurseRate(luck);
    }
}
