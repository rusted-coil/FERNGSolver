using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Gba.Domain.Combat.Service
{
    public static class CombatRngServiceFactory
    {
        // Serviceの作成は検索中に頻繁に呼び出すことが想定されるため、一つのオブジェクトを使いまわしてメモリアロケーションを抑える。
        private static Internal.CombatRngService s_Service = new Internal.CombatRngService();

        public static ICombatRngService Create(IRng rng)
        {
            s_Service.SetRng(rng);
            return s_Service;
        }
    }
}
