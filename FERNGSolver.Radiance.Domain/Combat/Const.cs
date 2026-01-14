namespace FERNGSolver.Radiance.Domain.Combat
{
    public static class Const
    {
        public enum WeaponType
        {
            Normal,
            Brave, // 勇者武器
            MagicSword, // 剣の間接攻撃
            Absorb, // 吸収武器
        }

        public enum BossType
        {
            None,
            Boss, // ボス
            FinalBoss, // 漆黒の騎士orアシュナード
        }
    }
}
