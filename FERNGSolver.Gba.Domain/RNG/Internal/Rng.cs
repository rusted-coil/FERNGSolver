
namespace FERNGSolver.Gba.Domain.RNG.Internal
{
    internal sealed class Rng : IRng
    {
        private ushort[] state = new ushort[3];
        public IReadOnlyList<ushort> States => state;

        public Rng(ushort seed0, ushort seed1, ushort seed2)
        {
            state[0] = seed0;
            state[1] = seed1;
            state[2] = seed2;
        }

        // 0～99 の値を返す
        public int Next()
        {
            ushort result = (ushort)(
                (((state[0] >> 5) + (state[1] << 11)) ^
                 ((state[2] << 1) + (state[1] >> 15))) & 0xFFFF);

            // 状態更新
            state[2] = state[1];
            state[1] = state[0];
            state[0] = result;

            return (result * 100) >> 16;
        }
    }
}
