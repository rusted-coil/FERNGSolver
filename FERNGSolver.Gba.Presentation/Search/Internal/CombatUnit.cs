using FERNGSolver.Gba.Domain.Combat;

namespace FERNGSolver.Gba.Presentation.Search.Internal
{
    internal sealed class CombatUnit : ICombatUnit
    {
        /// <summary>
        /// HPを取得します。
        /// </summary>
        public int Hp { get; set; }

        /// <summary>
        /// 威力を取得します。
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// 命中率を取得します。
        /// </summary>
        public int HitRate { get; set; }

        /// <summary>
        /// 必殺率を取得します。
        /// </summary>
        public int CriticalRate { get; set; }

        /// <summary>
        /// 攻撃フェーズの回数を取得します。
        /// <para> * 反撃しない時は0、追撃する時は2となります。</para>
        /// </summary>
        public int PhaseCount { get; set; }

        /// <summary>
        /// ステータスの詳細設定を取得します。
        /// </summary>
        public required IUnitStatusDetail StatusDetail { get; set; }
    }
}
