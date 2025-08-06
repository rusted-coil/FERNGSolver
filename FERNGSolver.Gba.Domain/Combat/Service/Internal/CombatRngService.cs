using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Gba.Domain.Combat.Service.Internal
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

        // 必的: Lv[%]で発動
        public bool CheckActivateSureStrike(int level, UnitSide unitSide) => m_Rng.Next() < level;

        // 貫通: Lv[%]で発動
        public bool CheckActivatePierce(int level, UnitSide unitSide) => m_Rng.Next() < level;

        // 大盾: Lv[%]で発動
        public bool CheckActivateGreatShield(int level, UnitSide unitSide) => m_Rng.Next() < level;

        // 瞬殺: ボスの種類に応じて発動
        public bool CheckActivateSilencer(Const.BossType bossType, bool hasSkill, UnitSide unitSide) => m_Rng.Next() < Util.GetSilencerRate(bossType) && hasSkill; // スキルの有無自体にかかわらず判定自体は行われる

        // デビルアクス
        public bool CheckActivateCurse(int luck, UnitSide unitSide) => m_Rng.Next() < Util.GetCurseRate(luck);
    }
}
