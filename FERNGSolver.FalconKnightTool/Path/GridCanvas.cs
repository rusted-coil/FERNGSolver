namespace FERNGSolver.FalconKnightTool.UI.Path
{
    public class GridCanvas : Panel
    {
        public GridCanvas()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.White;

            // デザイン時にはイベントや描画処理を避ける
            if (!DesignMode)
            {
//                this.MouseDown += OnMouseDown;
//                this.MouseMove += OnMouseMove;
 //               this.MouseUp += OnMouseUp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (DesignMode) return;

            // 通常の描画処理...
        }
    }
}
