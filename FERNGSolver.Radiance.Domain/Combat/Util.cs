namespace FERNGSolver.Radiance.Domain.Combat
{
    public static class Util
    {
        /// <summary>
        /// 幸運のステータスから、デビルアクスの呪いの発生率を取得します。
        /// </summary>
        public static int GetCurseRate(int luck)
        {
            return Math.Max(0, 31 - luck);
        }

        /// <summary>
        /// 瞬殺の成功率を取得します。
        /// </summary>
        public static int GetSilencerRate(Const.BossType opponentBossType)
        {
            return opponentBossType switch
            {
                Const.BossType.None => 50,
                Const.BossType.Boss => 25,
                Const.BossType.FinalBoss => throw new NotSupportedException(), // 本来は魔王相手は瞬殺判定が存在しないため判定はしないはず
                _ => throw new ArgumentOutOfRangeException(nameof(opponentBossType), opponentBossType, null)
            };
        }
    }
}
