namespace FERNGSolver.Common.Domain.Types
{
    public struct GridPosition
    {
        public int X { get; }
        public int Y { get; }

        public GridPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj) => obj is GridPosition p && p.X == X && p.Y == Y;
        public override int GetHashCode() => HashCode.Combine(X, Y);
    }
}
