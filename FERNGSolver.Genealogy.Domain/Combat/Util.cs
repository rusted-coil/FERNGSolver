namespace FERNGSolver.Genealogy.Domain.Combat
{
    public static class Util
    {
        /// <summary>
        /// 必殺率を計算します。
        /// </summary>
        public static int GetCriticalRate(int tec, bool hasCriticalSkill, bool hasSupport, bool isEffective, int weaponStarCount)
        {
            // 特効は確定必殺
            if (isEffective)
            {
                return 100;
            }

            int criticalRate = hasSupport ? 20 : 0; // 支援がある場合はベースラインを20%とする

            // 武器の★が50以上なら技+(★-50)%
            if (weaponStarCount > 50)
            {
                criticalRate += tec + (weaponStarCount - 50);
            }
            // ただの必殺スキルを持っている場合、技%
            else if(hasCriticalSkill)
            {
                criticalRate += tec;
            }

            return criticalRate;
        }
    }
}
