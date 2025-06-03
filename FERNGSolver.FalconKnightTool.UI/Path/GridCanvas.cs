using FERNGSolver.Common.Domain.Types;
using System.Reactive.Subjects;

namespace FERNGSolver.FalconKnightTool.UI.Path
{
    public class GridCanvas : Panel
    {
        private int m_GridCount = 15;
        public int GridCount
        {
            get => m_GridCount;
            set {
                m_GridCount = value;
                m_CurrentPath.Clear();
                m_PathDetermined.OnNext(m_CurrentPath);
                Invalidate();
            }
        } 

        public IObservable<IReadOnlyList<GridPosition>> PathDetermined => m_PathDetermined;

        private GridPosition StartPosition => new(GridCount / 2, GridCount / 2);
        private List<GridPosition> m_CurrentPath = new List<GridPosition>();
        private GridPosition? m_CurrentCursorPosition = null;

        private Subject<IReadOnlyList<GridPosition>> m_PathDetermined = new Subject<IReadOnlyList<GridPosition>>();

        private Image m_CursorGrey;
        private Image m_CursorStart;
        private Image m_CursorDrag;

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
            m_CursorStart = Resources.CursorStart;
            m_CursorDrag = Resources.CursorDrag;
            m_CursorGrey = Resources.CursorGrey;

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
            DrawGrids(g);
            DrawPlayer(g);
            DrawPath(g);
            DrawCursor(g);
        }

        private void DrawGrids(Graphics g)
        {
            using var gridPen = new Pen(Color.Gray);
            for (int i = 0; i < GridCount; i++)
            {
                int x = Width * i / GridCount;
                g.DrawLine(gridPen, x, 0, x, Height);
            }
            g.DrawLine(gridPen, Width - 1, 0, Width - 1, Height);
            for (int i = 0; i < GridCount; i++)
            {
                int y = Height * i / GridCount;
                g.DrawLine(gridPen, 0, y, Width, y);
            }
            g.DrawLine(gridPen, 0, Height - 1, Width, Height - 1);
        }

        private void DrawPlayer(Graphics g)
        {
            var center = GridCenterToScreenPoint(StartPosition);
            int r = Width / GridCount / 4;
            var rect = new Rectangle(center.X - r, center.Y - r, r * 2, r * 2);
            g.FillEllipse(Brushes.Blue, rect);
        }

        private void DrawPath(Graphics g)
        {
            // 経路（矢印の代わりに線で表示）
            using var pathPen = new Pen(Color.Red, 2);
            for (int i = 1; i < m_CurrentPath.Count; i++)
            {
                var from = GridCenterToScreenPoint(m_CurrentPath[i - 1]);
                var to = GridCenterToScreenPoint(m_CurrentPath[i]);
                g.DrawLine(pathPen, from, to);
            }
        }

        private void DrawCursor(Graphics g)
        {
            if (m_CurrentCursorPosition != null)
            {
                if (m_isDragging)
                {
                    var center = GridCenterToScreenPoint(m_CurrentCursorPosition.Value);
                    var width = Width * 110 / GridCount / 100;
                    var height = Height * 110 / GridCount / 100;
                    g.DrawImage(m_CursorDrag, center.X - width / 2, center.Y - height / 2, width, height);
                }
                else if (StartPosition.Equals(m_CurrentCursorPosition.Value))
                {
                    var center = GridCenterToScreenPoint(m_CurrentCursorPosition.Value);
                    var width = Width * 110 / GridCount / 100;
                    var height = Height * 110 / GridCount / 100;
                    g.DrawImage(m_CursorStart, center.X - width / 2, center.Y - height / 2, width, height);
                }
                else
                {
                    var center = GridCenterToScreenPoint(m_CurrentCursorPosition.Value);
                    var width = Width / GridCount;
                    var height = Height / GridCount;
                    g.DrawImage(m_CursorGrey, center.X - width / 2, center.Y - height / 2, width, height);
                }
            }
        }

        // コントロール上の座標から、該当するグリッドの座標を取得
        // 領域外だった場合はnullを返す（必ず 0～GridCount-1 の間に収まる）
        private GridPosition? ScreenPointToGrid(Point point)
        {
            int x = point.X * GridCount / Width;
            int y = point.Y * GridCount / Height;

            if (x < 0 || x >= GridCount || y < 0 || y >= GridCount)
            {
                return null;
            }

            return new GridPosition(x, y);
        }

        // グリッド座標から、その中心のコントロール上の座標を取得
        private Point GridCenterToScreenPoint(GridPosition grid)
        {
            return new Point(
                Width * (grid.X * 2 + 1) / GridCount / 2,
                Height * (grid.Y * 2 + 1) / GridCount / 2
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
            if (position != null)
            {
                bool invalid = false;
                if (!position.Equals(m_CurrentCursorPosition))
                {
                    m_CurrentCursorPosition = position;
                    invalid = true;
                }
                if (m_isDragging && !m_CurrentPath.Contains(position.Value))
                {
                    AddPointToPath(position.Value);
                    invalid = true;
                }
                if (invalid)
                {
                    Invalidate();
                }
            }
            else
            {
                if (m_CurrentCursorPosition != null)
                {
                    m_CurrentCursorPosition = null;
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
                Invalidate();
            }
        }
    }
}
