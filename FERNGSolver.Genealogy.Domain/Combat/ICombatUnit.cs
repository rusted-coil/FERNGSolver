namespace FERNGSolver.Genealogy.Domain.Combat
{
    /// <summary>
    /// 戦闘を行うユニットのインターフェースです。
    /// </summary>
    public interface ICombatUnit
    {
        /// <summary>
        /// HPを取得します。
        /// </summary>
        public int Hp { get; }

        /// <summary>
        /// 攻撃力を取得します。
        /// </summary>
        public int Attack { get; }

        /// <summary>
        /// 守備力を取得します。
        /// </summary>
        public int Defense { get; }

        /// <summary>
        /// 命中率を取得します。
        /// </summary>
        public int HitRate { get; }

        /// <summary>
        /// 必殺率を取得します。
        /// </summary>
        public int CriticalRate { get; }

        /// <summary>
        /// 攻撃フェーズの回数を取得します。
        /// <para> * 反撃しない時は0、追撃する時は2となります。</para>
        /// </summary>
        public int PhaseCount { get; }

        /// <summary>
        /// ステータスの詳細設定を取得します。
        /// </summary>
        public IUnitStatusDetail StatusDetail { get; }
    }
}
