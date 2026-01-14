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

        // 月光判定
        public bool CheckActivateLuna(int tec, UnitSide unitSide) => m_Rng.Next() < tec;

        // 太陽判定
        public bool CheckActivateSol(int tec, UnitSide unitSide) => m_Rng.Next() < tec;

        // 陽光判定
        public bool CheckActivateFlare(int tec, UnitSide unitSide) => m_Rng.Next() < tec;

        // 瞬殺判定
        public bool CheckActivateLethality(UnitSide unitSide) => m_Rng.Next() < 50;

        // 武器破壊判定
        public bool CheckActivateCorrode(int tec, UnitSide unitSide) => m_Rng.Next() < tec;

        // 衝撃判定
        public bool CheckActivateStun(int tec, UnitSide unitSide) => m_Rng.Next() < tec / 2;

        // 鳴動判定
        public bool CheckActivateColossus(int tec, UnitSide unitSide) => m_Rng.Next() < tec;

        // カウンター判定
        public bool CheckActivateCounter(int tec, UnitSide unitSide) => m_Rng.Next() < tec / 2;

        // 祈り判定
        public bool CheckActivateMiracle(int luck, UnitSide unitSide) => m_Rng.Next() < luck;

        // キャンセル判定
        public bool CheckActivateGuard(int tec, UnitSide unitSide) => m_Rng.Next() < tec;

        // 狙撃判定
        public bool CheckActivateDeadeye(int tec, UnitSide unitSide) => m_Rng.Next() < tec / 2;

        // 翼の守護判定
        public bool CheckActivateCancel(int tec, UnitSide unitSide) => m_Rng.Next() < tec;
    }
}
