namespace FERNGSolver.Radiance.Domain.Combat
{
    public static class Const
    {
        public enum WeaponType
        {
            Normal,
            Brave, // 勇者武器
            Absorb, // 吸収武器
            Poison, // 状態異常武器
            Cursed, // デビルアクス
        }

        public enum BossType
        {
            None,
            Boss, // ボス
            FinalBoss, // 魔王
        }
    }
}
