using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Domain.Growth
{
    public static class GrowthSimulator
    {
        /// <summary>
        /// RNGを進め、レベルアップをシミュレートした結果を得ます。
        /// </summary>
        /// <returns>入力した成長率に対応する成長値のリストを返します。</returns>
        public static IReadOnlyList<int> Simulate(IRng rng, params int[] growthRates)
        {
            int[] results = new int[growthRates.Length];
            int pin = 0;

            for (int i = 0; i < results.Length; ++i)
            {
                int rate = growthRates[i];

                // 成長率100%以上はその数値分確定成長
                results[i] = rate / 100; 
                rate -= (results[i] * 100);

                // 成長率0でも乱数は消費する

                if (rng.Next() < rate)
                {
                    results[i]++;
                }
            }

            return results;
        }
    }
}
