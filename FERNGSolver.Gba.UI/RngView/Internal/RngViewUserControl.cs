using FERNGSolver.Gba.Application.RNG;
using FERNGSolver.Gba.Domain.Combat.Service;
using FERNGSolver.Gba.Presentation.RngView;
using FERNGSolver.Gba.Presentation.RngView.ViewContracts;
using System.Drawing.Drawing2D;
using System.Reactive.Subjects;

namespace FERNGSolver.Gba.UI.RngView.Internal
{
    public partial class RngViewUserControl : UserControl, IRngView
    {
        // Viewに使用する定数
        private const int RngNumberStartX = 5; // 乱数値の表示開始X座標
        private const int RngNumberStartY = 32; // 乱数値の表示開始Y座標
        private const int RngNumberIntervalX = 22; // 乱数値の表示位置X座標間隔
        private const int RngNumberCxOffset = 20; // ◯×表示のY座標オフセット
        private const int RngNumberUsageOffset = 40; // 乱数値の使用状況表示のY座標オフセット

        // ブラシとペンのキャッシュ
        private static readonly (Brush Brush, Pen Pen) DefaultDrawer = (Brushes.Black, Pens.Black);
        private static readonly (Brush Brush, Pen Pen) GrowthUsageDrawer = (Brushes.DarkGreen, Pens.DarkGreen);
        private static readonly (Brush Brush, Pen Pen) PlayerUsageDrawer = (Brushes.Blue, Pens.Blue);
        private static readonly (Brush Brush, Pen Pen) EnemyUsageDrawer = (Brushes.Red, Pens.Red);

        public int CurrentPosition => (int)PositionNumericUpDown.Value;
        public IObservable<int> PositionChanged => m_PositionChanged;

        private BehaviorSubject<int> m_PositionChanged;

        private IRandomNumberViewModel[] m_RandomNumberViewModels = Array.Empty<IRandomNumberViewModel>();

        public RngViewUserControl()
        {
            InitializeComponent();
            m_PositionChanged = new BehaviorSubject<int>((int)PositionNumericUpDown.Value);
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
                var x = RngNumberStartX + i * RngNumberIntervalX;
                var y = RngNumberStartY;

                g.DrawString(m_RandomNumberViewModels[i].Value.ToString("D2"), this.Font, Brushes.Black, x, y);
                g.DrawString(Domain.RNG.Util.IsRngValueOk(m_RandomNumberViewModels[i].Value) ? "◯" : "✕", this.Font, Brushes.Black, x + 1, y + RngNumberCxOffset);
                DrawUsage(g, m_RandomNumberViewModels[i], x, y + RngNumberUsageOffset);
            }
        }

        private void DrawUsage(Graphics g, IRandomNumberViewModel viewModel, int x, int y)
        {
            if (viewModel.Usage == RandomNumberUsage.None)
            {
                return;
            }

            var drawer = GetUsageDrawer(viewModel.Usage);

            g.DrawString(viewModel.Usage.ToDisplayString(), this.Font, drawer.Brush, x, y);
            if (viewModel.IsOk)
            {
                g.DrawLine(drawer.Pen, x, y + 16, x + 16, y + 16);
            }
        }

        private (Brush Brush, Pen Pen) GetUsageDrawer(RandomNumberUsage usage)
        {
            if (usage.IsGrowth())
            {
                return GrowthUsageDrawer;
            }
            var unitSide = usage.GetUnitSide();
            return unitSide switch
            {
                UnitSide.Player => PlayerUsageDrawer,
                UnitSide.Enemy => EnemyUsageDrawer,
                _ => DefaultDrawer,
            };
        }

        private void PositionNumericUpDown_ValueChanged(object sender, EventArgs e) => m_PositionChanged.OnNext((int)PositionNumericUpDown.Value);
    }
}
