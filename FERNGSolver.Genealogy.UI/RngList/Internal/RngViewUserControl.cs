using FERNGSolver.Genealogy.Presentation.RngList.RngView;
using FERNGSolver.Genealogy.Presentation.RngList.RngView.ViewContracts;
using System.Drawing.Drawing2D;
using System.Reactive.Subjects;

namespace FERNGSolver.Genealogy.UI.RngList.Internal
{
    public partial class RngViewUserControl : UserControl, IRngView
    {
        // Viewに使用する定数
        private const int RngNumberStartX = 5; // 乱数値の表示開始X座標
        private const int RngNumberStartY = 32; // 乱数値の表示開始Y座標
        private const int RngNumberIntervalX = 22; // 乱数値の表示位置X座標間隔
        private const int RngNumberUsageOffset = 24;

        public IObservable<int> PositionChanged => m_PositionChanged;

        private Subject<int> m_PositionChanged = new Subject<int>();

        private IRandomNumberViewModel[] m_RandomNumberViewModels = Array.Empty<IRandomNumberViewModel>();

        public RngViewUserControl()
        {
            InitializeComponent();
        }

        public void SetRandomNumbers(IReadOnlyList<IRandomNumberViewModel> viewModels)
        {
            m_RandomNumberViewModels = viewModels.ToArray();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 0; i < m_RandomNumberViewModels.Length; i++)
            {
                var x = RngNumberStartX + i * RngNumberIntervalX; // 行ごとに20個
                var y = RngNumberStartY;

                g.DrawString(m_RandomNumberViewModels[i].Value.ToString("D2"), this.Font, Brushes.Black, x, y);
                g.DrawString(m_RandomNumberViewModels[i].Usage.ToDisplayString(), this.Font, Brushes.LightGreen, x, y + RngNumberUsageOffset);
                if (m_RandomNumberViewModels[i].IsOk)
                {
                    g.DrawLine(Pens.Red, x, y + 20, x + 20, y + 20);
                }
            }
        }

        private void PositionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_PositionChanged.OnNext((int)PositionNumericUpDown.Value);
        }
    }
}
