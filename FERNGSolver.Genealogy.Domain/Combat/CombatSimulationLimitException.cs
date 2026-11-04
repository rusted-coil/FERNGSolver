namespace FERNGSolver.Genealogy.Domain.Combat
{
    /// <summary>
    /// 戦闘が計算上限までに終了せず、確定した結果を取得できなかったことを示します。
    /// </summary>
    public sealed class CombatSimulationLimitException : Exception
    {
        public int RoundLimit { get; }

        public CombatSimulationLimitException(int roundLimit)
            : base($"戦闘が{roundLimit:N0}ラウンド以内に終了しなかったため、計算を中断しました。命中率・攻撃回数・スキルなどの条件を確認してください。")
        {
            RoundLimit = roundLimit;
        }
    }
}
