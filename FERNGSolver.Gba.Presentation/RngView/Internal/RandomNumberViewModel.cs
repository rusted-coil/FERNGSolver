using FERNGSolver.Gba.Application.RNG;

namespace FERNGSolver.Gba.Presentation.RngView.Internal
{
    internal sealed class RandomNumberViewModel : IRandomNumberViewModel
    {
        public required ushort Value { get; init; }
        public required RandomNumberUsage Usage { get; init; }
        public required bool IsOk { get; init; }
    }
}
