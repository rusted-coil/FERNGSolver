using FERNGSolver.Common.Types;
using System.Reactive.Subjects;

namespace FERNGSolver.FalconKnightTool.UI.Path
{
    public class GridCanvas : Panel
    {
        public int GridCount { get; set; } = 15;
        public IObservable<IReadOnlyList<GridPosition>> PathDetermined => m_PathDetermined;

        private GridPosition StartPosition => new(GridCount / 2, GridCount / 2);
        private List<GridPosition> m_CurrentPath = new List<GridPosition>();

        private Subject<IReadOnlyList<GridPosition>> m_PathDetermined = new Subject<IReadOnlyList<GridPosition>>();

        private void AddPointToPath(GridPosition position)
        {
            if (m_CurrentPath.Count == 0)
            {
                m_CurrentPath.Add(position);
                return;
            }

            // 現在のパスの先端からシティブロック距離で1となる経路のみを許す
            var currentEnd = m_CurrentPath[m_CurrentPath.Count - 1];

            int x = currentEnd.X;
            int y = currentEnd.Y;

            // 補完しながらステップごとに追加
            while (x != position.X || y != position.Y)
            {
                if (x != position.X)
                {
                    x += Math.Sign(position.X - x);
                }
                else if (y != position.Y)
                {
                    y += Math.Sign(position.Y - y);
                }

                m_CurrentPath.Add(new GridPosition(x, y));
            }
        }

        public GridCanvas()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.White;

            // デザイン時にはイベントや描画処理を避ける
            if (!DesignMode)
            {
                this.MouseDown += OnMouseDown;
                this.MouseMove += OnMouseMove;
                this.MouseUp += OnMouseUp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // デザイン時には何も表示しない
            if (DesignMode) return;

            var g = e.Graphics;

            // コントロールサイズからグリッドのサイズを計算
            var gridWidth = Width / GridCount;
            var gridHeight = Height / GridCount;

            using var gridPen = new Pen(Color.Gray);

            // グリッドを描画
            for (int x = 0; x <= GridCount; x++)
            {
                g.DrawLine(gridPen, x * gridWidth, 0, x * gridWidth, Height);
            }
            for (int y = 0; y <= GridCount; y++)
            {
                g.DrawLine(gridPen, 0, y * gridHeight, Width, y * gridHeight);
            }

            // 操作キャラ（中央）
            var center = StartPosition;
            var rect = new Rectangle(center.X * gridWidth + gridWidth / 4, center.Y * gridHeight + gridHeight / 4, gridWidth / 2, gridHeight / 2);
            g.FillEllipse(Brushes.Blue, rect);

            // 経路（矢印の代わりに線で表示）
            using var pathPen = new Pen(Color.Red, 2);
            for (int i = 1; i < m_CurrentPath.Count; i++)
            {
                var from = GridCenterToScreenPoint(m_CurrentPath[i - 1]);
                var to = GridCenterToScreenPoint(m_CurrentPath[i]);
                g.DrawLine(pathPen, from, to);
            }
        }

        // コントロール上の座標から、該当するグリッドの座標を取得
        // 領域外だった場合はnullを返す（必ず 0～GridCount-1 の間に収まる）
        private GridPosition? ScreenPointToGrid(Point point)
        {
            var gridWidth = Width / GridCount;
            var gridHeight = Height / GridCount;

            int x = point.X / gridWidth;
            int y = point.Y / gridHeight;

            if (x < 0 || x >= GridCount || y < 0 || y >= GridCount)
            {
                return null;
            }

            return new GridPosition(x, y);
        }

        // グリッド座標から、その中心のコントロール上の座標を取得
        private Point GridCenterToScreenPoint(GridPosition grid)
        {
            var gridWidth = Width / GridCount;
            var gridHeight = Height / GridCount;

            return new Point(
                grid.X * gridWidth + gridWidth / 2,
                grid.Y * gridHeight + gridHeight / 2
            );
        }

        //-----------------------------------------------------------------------------
        // マウスイベント処理
        //-----------------------------------------------------------------------------

        private void OnMouseDown(object? sender, MouseEventArgs e)
        {
            // 左クリックのみ対応
            if (e.Button != MouseButtons.Left) return;
            OnMouseDownImpl(ScreenPointToGrid(e.Location));
        }

        private void OnMouseMove(object? sender, MouseEventArgs e)
        {
            OnMouseMoveImpl(ScreenPointToGrid(e.Location));
        }

        private void OnMouseUp(object? sender, MouseEventArgs e)
        {
            OnMouseUpImpl(ScreenPointToGrid(e.Location));
        }

        bool m_isDragging = false;

        private void OnMouseDownImpl(GridPosition? position)
        {
            // 操作キャラ位置からのドラッグのみ対応
            if (StartPosition.Equals(position))
            {
                m_isDragging = true;

                m_CurrentPath.Clear();

                AddPointToPath(position.Value);
                Invalidate();
            }
            else
            {
                m_isDragging = false;
            }
        }

        private void OnMouseMoveImpl(GridPosition? position)
        {
            if (m_isDragging)
            {
                if (position != null && !m_CurrentPath.Contains(position.Value))
                {
                    AddPointToPath(position.Value);
                    Invalidate();
                }
            }
        }

        private void OnMouseUpImpl(GridPosition? position)
        {
            if (m_isDragging)
            {
                m_isDragging = false;
                m_PathDetermined.OnNext(m_CurrentPath.ToArray()); // コピーしてパスを通知
            }
        }
    }
}
