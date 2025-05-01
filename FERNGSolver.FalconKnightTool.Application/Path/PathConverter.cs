using FERNGSolver.Common.Types;
using System.Text;

namespace FERNGSolver.FalconKnightTool.Application.Path
{
    public static class PathConverter
    {
        private static readonly (int dx, int dy)[] DirectionPriority = new[]
        {
            (-1, 0), // 左
            (0, 1),  // 下
            (1, 0),  // 右
            (0, -1), // 上
        };

        /// <summary>
        /// 座標のリストから、乱数のcx列に変換します。
        /// </summary>
        public static string PathToCxString(IReadOnlyList<GridPosition> path)
        {
            if (path.Count < 2)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            var goal = path[0]; // 終点（ゴール）

            // ゴールからスタートへ向かって逆順に処理
            for (int i = path.Count - 1; i > 0; i--)
            {
                var current = path[i];
                var prev = path[i - 1];

                int currentDistance = ManhattanDistance(current, goal);

                // 最短距離候補（距離が1減る方向）を列挙
                var validDirs = new List<(int dx, int dy)>();
                foreach (var dir in DirectionPriority)
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

                    for (int rank = 0; rank < validDirs.Count; rank++)
                    {
                        if (validDirs[rank].dx == actualDx && validDirs[rank].dy == actualDy)
                        {
                            sb.Append(rank == 0 ? 'c' : 'x');
                            break;
                        }
                    }
                }
            }

            return sb.ToString();
        }

        private static int ManhattanDistance(GridPosition a, GridPosition b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
}
