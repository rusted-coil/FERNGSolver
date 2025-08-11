using FERNGSolver.Genealogy.Application.RNG;

namespace FERNGSolver.Genealogy.Presentation.RngView.Internal
{
    internal sealed class RandomNumberViewModel : IRandomNumberViewModel
    {
        public required ushort Value { get; init; }
        public required RandomNumberUsage Usage { get; init; }
        public required bool? IsOk { get; init; }
    }
}
