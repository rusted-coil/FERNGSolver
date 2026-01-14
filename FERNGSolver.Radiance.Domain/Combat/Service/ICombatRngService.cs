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
        /// 乱数を2個消費して命中判定を行います。
        /// </summary>
        bool CheckHit(int hitRate, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して必殺判定を行います。
        /// </summary>
        bool CheckCritical(int criticalRate, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して連続の発動判定を行います。
        /// </summary>
        bool CheckActivateAdept(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して天空の発動判定を行います。
        /// </summary>
        bool CheckActivateAether(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して流星の発動判定を行います。
        /// </summary>
        bool CheckActivateAstra(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して月光の発動判定を行います。
        /// </summary>
        bool CheckActivateLuna(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して太陽の発動判定を行います。
        /// </summary>
        bool CheckActivateSol(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して陽光の発動判定を行います。
        /// </summary>
        bool CheckActivateFlare(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して瞬殺の発動判定を行います。
        /// </summary>
        bool CheckActivateLethality(UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して武器破壊の発動判定を行います。
        /// </summary>
        bool CheckActivateCorrode(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して衝撃の発動判定を行います。
        /// </summary>
        bool CheckActivateStun(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して鳴動の発動判定を行います。
        /// </summary>
        bool CheckActivateColossus(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費してカウンターの発動判定を行います。
        /// </summary>
        bool CheckActivateCounter(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して祈りの発動判定を行います。
        /// </summary>
        bool CheckActivateMiracle(int luck, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費してキャンセルの発動判定を行います。
        /// </summary>
        bool CheckActivateGuard(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して狙撃の発動判定を行います。
        /// </summary>
        bool CheckActivateDeadeye(int tec, UnitSide unitSide);

        /// <summary>
        /// 乱数を消費して翼の守護の発動判定を行います。
        /// </summary>
        bool CheckActivateCancel(int tec, UnitSide unitSide);
    }
}
