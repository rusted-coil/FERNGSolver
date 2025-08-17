using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Genealogy.Domain.Combat.Service.Internal
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

        // 命中判定
        public bool CheckHit(int hitRate, UnitSide unitSide) => m_Rng.Next() < hitRate;

        // 必殺判定
        public bool CheckCritical(int criticalRate, UnitSide unitSide) => m_Rng.Next() < criticalRate;

        // 突撃: (自分の攻速-相手の攻速+HP÷2)[%]で発動
        public bool CheckActivateAssault(int attackSpeed, int opponentAttackSpeed, int attackerHp, UnitSide unitSide) => m_Rng.Next() < (attackSpeed - opponentAttackSpeed + attackerHp / 2);

        // 流星剣: 技[%]で発動
        public bool CheckActivateAstra(int tec, UnitSide unitSide) => m_Rng.Next() < tec;

        // 月光剣: 技[%]で発動
        public bool CheckActivateLuna(int tec, UnitSide unitSide) => m_Rng.Next() < tec;

        // 太陽剣: 技[%]で発動
        public bool CheckActivateSol(int tec, UnitSide unitSide) => m_Rng.Next() < tec;

        // 連続: 攻速+20[%]で発動
        public bool CheckActivateContinuation(int attackSpeed, UnitSide unitSide) => m_Rng.Next() < (attackSpeed + 20);

        // 大盾: Lv[%]で発動
        public bool CheckActivateGreatShield(int level, UnitSide unitSide) => m_Rng.Next() < level;
    }
}
