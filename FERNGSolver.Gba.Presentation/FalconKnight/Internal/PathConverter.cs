using FERNGSolver.Common.Domain.Types;
using FERNGSolver.FalconKnightTool.Domain.Path;

namespace FERNGSolver.Gba.Presentation.FalconKnight.Internal
{
    internal sealed class PathConverter : IPathConverter
    {
        private static readonly (int dx, int dy)[] Directions = new[]
        {
            (-1, 0), // 左
            (0, 1),  // 下
            (1, 0),  // 右
            (0, -1), // 上
        };

        public IReadOnlyList<bool> PathToCx(IReadOnlyList<GridPosition> path)
        {
            if (path.Count < 2)
            {
                return Array.Empty<bool>();
            }

            var result = new List<bool>();

            var goal = path[0]; // 終点（ゴール）

            // ゴールからスタートへ向かって逆順に処理
            for (int i = path.Count - 1; i > 0; i--)
            {
                var current = path[i];
                var prev = path[i - 1];

                int currentDistance = ManhattanDistance(current, goal);

                // 最短距離候補（距離が1減る方向）を列挙
                var validDirs = new List<(int dx, int dy)>();
                foreach (var dir in Directions)
                {
                    int nx = current.X + dir.dx;
                    int ny = current.Y + dir.dy;
                    var next = new GridPosition(nx, ny);
                    int nextDistance = ManhattanDistance(next, goal);
                    if (nextDistance == currentDistance - 1)
                    {
                        validDirs.Add(dir);
                    }
                }

                // 候補が複数あった場合のみc/x出力
                if (validDirs.Count >= 2)
                {
                    var actualDx = prev.X - current.X;
                    var actualDy = prev.Y - current.Y;
                    result.Add(Math.Abs(actualDx) > 0); // 横方向が◯
                }
            }
            return result;
        }

        private static int ManhattanDistance(GridPosition a, GridPosition b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
}
