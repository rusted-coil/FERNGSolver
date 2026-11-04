using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Gba.Domain.Tests;

internal sealed class SequenceRng(params ushort[] values) : IRng
{
    public int Consumed { get; private set; }

    public ushort Next()
    {
        Assert.IsTrue(Consumed < values.Length, "The operation consumed an unexpected random number.");
        return values[Consumed++];
    }
}
