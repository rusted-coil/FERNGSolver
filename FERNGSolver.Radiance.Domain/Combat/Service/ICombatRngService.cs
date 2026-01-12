namespace FERNGSolver.Radiance.Domain.Combat.Service
{
    public enum UnitSide
    {
        Player, // プレイヤー側(青軍)
        Enemy, // 敵側(赤軍)
    }

    public interface ICombatRngService
    {
        /// <summary>
        /// 乱数を消費して命中判定を行います。
        /// </summary>
        bool CheckHit(int hitRate, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して必殺判定を行います。
        /// </summary>
        bool CheckCritical(int criticalRate, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して必的の発動判定を行います。
        /// </summary>
        bool CheckActivateSureStrike(int level, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して貫通の発動判定を行います。
        /// </summary>
        bool CheckActivatePierce(int level, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して大盾の発動判定を行います。
        /// </summary>
        bool CheckActivateGreatShield(int level, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して瞬殺の発動判定を行います。
        /// </summary>
        bool CheckActivateSilencer(Const.BossType bossType, bool hasSkill, UnitSide unitSide); // スキルの有無自体にかかわらず判定自体は行われる

        /// <summary>
        /// 乱数を消費してデビルアクスの呪いの発動判定を行います。
        /// </summary>
        bool CheckActivateCurse(int luck, UnitSide unitSide);
    }
}
