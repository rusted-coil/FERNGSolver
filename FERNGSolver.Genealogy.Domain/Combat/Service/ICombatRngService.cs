namespace FERNGSolver.Genealogy.Domain.Combat.Service
{
    public enum UnitSide
    {
        Player, // プレイヤー側(青軍)
        Enemy, // 敵側(赤軍)
    }

    /// <summary>
    /// 戦闘に使う乱数判定を提供するサービスのインターフェースです。
    /// </summary>
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
        /// 乱数を消費して流星剣の発動判定を行います。
        /// </summary>
        bool CheckActivateAstra(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して月光剣の発動判定を行います。
        /// </summary>
        bool CheckActivateLuna(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して太陽剣の発動判定を行います。
        /// </summary>
        bool CheckActivateSol(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して連続の発動判定を行います。
        /// </summary>
        bool CheckActivateContinuation(int attackSpeed, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して大盾の発動判定を行います。
        /// </summary>
        bool CheckActivateGreatShield(int level, UnitSide unitSide);

    }
}
