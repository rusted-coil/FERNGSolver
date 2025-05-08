namespace FERNGSolver.Gba.Application.Search.Strategy
{
    /// <summary>
    /// CombatStrategyに必要な引数をまとめたクラスです。
    /// </summary>
    public sealed class CombatStrategyArgs
    {
        /// <summary>
        /// 攻撃側の情報を取得します。
        /// </summary>
        public CombatUnitInfo Attacker { get; set; }

        /// <summary>
        /// 防御側の情報を取得します。
        /// </summary>
        public CombatUnitInfo Defender { get; set; }
    }

    public class CombatUnitInfo
    {
        /// <summary>
        /// 攻撃フェーズの回数を取得します。
        /// <para> * 反撃しない時は0、追撃する時は2となります。</para>
        /// </summary>
        public int PhaseCount { get; set; }

        /// <summary>
        /// 命中率を取得します。
        /// </summary>
        public int HitRate { get; set; }

        /// <summary>
        /// 必殺率を取得します。
        /// </summary>
        public int CriticalRate { get; set; }

        /// <summary>
        /// 2回攻撃（勇者武器）かどうかを取得します。
        /// </summary>
        public bool IsDoubleAttack { get; set; }
    }
}
