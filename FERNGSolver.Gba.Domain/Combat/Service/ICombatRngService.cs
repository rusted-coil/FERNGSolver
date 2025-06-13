namespace FERNGSolver.Gba.Domain.Combat.Service
{
    public interface ICombatRngService
    {
        /// <summary>
        /// 乱数を消費して命中判定を行います。
        /// </summary>
        bool CheckHit(int hitRate);

        /// <summary>
        /// 乱数を消費して必殺判定を行います。
        /// </summary>
        bool CheckCritical(int criticalRate);

        /// <summary>
        /// 乱数を消費して必的の発動判定を行います。
        /// </summary>
        bool CheckActivateSureStrike(int level);

        /// <summary>
        /// 乱数を消費して貫通の発動判定を行います。
        /// </summary>
        bool CheckActivatePierce(int level);

        /// <summary>
        /// 乱数を消費して大盾の発動判定を行います。
        /// </summary>
        bool CheckActivateGreatShield(int level);

        /// <summary>
        /// 乱数を消費して瞬殺の発動判定を行います。
        /// </summary>
        bool CheckActivateSilencer(Const.BossType bossType);

        /// <summary>
        /// 乱数を消費してデビルアクスの呪いの発動判定を行います。
        /// </summary>
        bool CheckActivateCurse(int luck);
    }
}
