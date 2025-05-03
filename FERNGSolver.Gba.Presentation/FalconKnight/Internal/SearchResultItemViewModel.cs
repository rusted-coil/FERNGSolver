using System.ComponentModel;

namespace FERNGSolver.Gba.Presentation.FalconKnight.Internal
{
    internal class SearchResultItemViewModel
    {
        [DisplayName("消費数")]
        public string Offset { get; }

        [DisplayName("Seed[0]")]
        public string Seed0 { get; }

        [DisplayName("Seed[1]")]
        public string Seed1 { get; }

        [DisplayName("Seed[2]")]
        public string Seed2 { get; }

        public SearchResultItemViewModel(int offset, int consumeCount, ushort[] seeds)
        {
            Offset = $"{offset}～{offset+consumeCount}";
            Seed0 = seeds[0].ToString("X4");
            Seed1 = seeds[1].ToString("X4");
            Seed2 = seeds[2].ToString("X4");
        }
    }
}
