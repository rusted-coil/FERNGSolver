using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Genealogy.Domain.RNG.Internal
{
    internal sealed class Rng : ICloneableRng
    {
        private ushort[] m_State = new ushort[55];

        public Rng(IReadOnlyList<ushort> seeds)
        {
        }

        // 0～99の値を返す
        public int Next()
        {
            return 0;
        }

        public ICloneableRng Clone()
        {
            return new Rng(m_State);
        }
    }
}
