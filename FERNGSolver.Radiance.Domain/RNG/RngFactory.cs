using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Radiance.Domain.RNG
{
    public static class RngFactory
    {
        /// <summary>
        /// 蒼炎の軌跡のRNGを作成します。
        /// </summary>
        public static ICloneableRng Create(int tableIndex)
        {
            return new Internal.Rng(
                Const.InitialSeeds[tableIndex],
                Const.InitialSeeds[(tableIndex + 1) % Const.TableCount],
                Const.InitialSeeds[(tableIndex + 2) % Const.TableCount]);
        }
    }
}
