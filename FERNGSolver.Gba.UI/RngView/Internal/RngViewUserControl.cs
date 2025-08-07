using FERNGSolver.Gba.Application.RNG;
using FERNGSolver.Gba.Domain.Combat.Service;
using FERNGSolver.Gba.Presentation.RngView;
using FERNGSolver.Gba.Presentation.RngView.ViewContracts;
using FormRx.Button;
using System.Drawing.Drawing2D;
using System.Reactive;
using System.Reactive.Subjects;

namespace FERNGSolver.Gba.UI.RngView.Internal
{
    public partial class RngViewUserControl : UserControl, IRngView
    {
        // Viewに使用する定数
        private const int RngNumberStartX = 5; // 乱数値の表示開始X座標
        private const int RngNumberStartY = 32; // 乱数値の表示開始Y座標
        private const int RngNumberIntervalX = 22; // 乱数値の表示位置X座標間隔
        private const int CxOffsetX = 1;
        private const int CxOffsetY = 20; // ◯×表示のY座標オフセット
        private const int HitUsageOffsetX = 5;
        private const int HitUsageLineLength = 27;
        private const int UsageOffsetY = 40; // 乱数値の使用状況表示のY座標オフセット
        private const int UsageLineOffsetY = 16;
        private const int UsageLineLength = 16;

        // ブラシとペンのキャッシュ
        private static readonly (Brush Brush, Pen Pen) DefaultDrawer = (Brushes.Black, Pens.Black);
        private static readonly (Brush Brush, Pen Pen) GrowthUsageDrawer = (Brushes.DarkGreen, Pens.DarkGreen);
        private static readonly (Brush Brush, Pen Pen) PlayerUsageDrawer = (Brushes.Blue, Pens.Blue);
        private static readonly (Brush Brush, Pen Pen) EnemyUsageDrawer = (Brushes.Red, Pens.Red);

        public int CurrentPosition => (int)PositionNumericUpDown.Value;
        public IObservable<int> PositionChanged => m_PositionChanged;

        private BehaviorSubject<int> m_PositionChanged;

        private readonly IButton m_RemoveButton;
        public IObservable<Unit> RemoveButtonClicked => m_RemoveButton.Clicked;

        private IRandomNumberViewModel[] m_RandomNumberViewModels = Array.Empty<IRandomNumberViewModel>();

        public RngViewUserControl(int initialPosition)
        {
            InitializeComponent();

            // ValueChangedイベントのハンドラを一時的に解除して初期値をセット
            PositionNumericUpDown.ValueChanged -= PositionNumericUpDown_ValueChanged;
            PositionNumericUpDown.Value = initialPosition;
            PositionNumericUpDown.ValueChanged += PositionNumericUpDown_ValueChanged;

            m_PositionChanged = new BehaviorSubject<int>((int)PositionNumericUpDown.Value);
            m_RemoveButton = ButtonFactory.CreateButton(RemoveButton);
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

            int skipCount = 0;
            for (int i = 0; i < m_RandomNumberViewModels.Length; i++)
            {
                var x = RngNumberStartX + i * RngNumberIntervalX;
                var y = RngNumberStartY;

                g.DrawString(m_RandomNumberViewModels[i].Value.ToString("D2"), this.Font, Brushes.Black, x, y);
                g.DrawString(Domain.RNG.Util.IsRngValueOk(m_RandomNumberViewModels[i].Value) ? "◯" : "✕", this.Font, Brushes.Black, x + CxOffsetX, y + CxOffsetY);

                if (skipCount == 0)
                {
                    if ((skipCount = TryDrawRangedUsage(g, m_RandomNumberViewModels, i, x, y + UsageOffsetY)) == 0)
                    {
                        DrawUsage(g, m_RandomNumberViewModels[i], x, y + UsageOffsetY);
                    }
                }
                else
                {
                    skipCount--;
                }
            }
        }

        // 複数に跨るUsageを描画する。描画を行った場合はその後スキップする数を返す。
        private int TryDrawRangedUsage(Graphics g, IReadOnlyList<IRandomNumberViewModel> viewModels, int index, int x, int y)
        {
            // 実効命中率
            if ((viewModels[index].Usage == RandomNumberUsage.PlayerHit1 && index + 1 < viewModels.Count && viewModels[index + 1].Usage == RandomNumberUsage.PlayerHit2)
                || (viewModels[index].Usage == RandomNumberUsage.EnemyHit1 && index + 1 < viewModels.Count && viewModels[index + 1].Usage == RandomNumberUsage.EnemyHit2))
            {
                var drawer = GetUsageDrawer(viewModels[index].Usage);
                g.DrawString(viewModels[index].Usage.ToSpecialDisplayString(), this.Font, drawer.Brush, x + HitUsageOffsetX, y);
                if (viewModels[index].IsOk)
                {
                    g.DrawLine(drawer.Pen, x + HitUsageOffsetX, y + UsageLineOffsetY, x + HitUsageOffsetX + HitUsageLineLength, y + UsageLineOffsetY);
                }
                return 1;
            }
            return 0;
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
                g.DrawLine(drawer.Pen, x, y + UsageLineOffsetY, x + UsageLineLength, y + UsageLineOffsetY);
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

        private void PositionNumericUpDown_ValueChanged(object? sender, EventArgs e) => m_PositionChanged.OnNext((int)PositionNumericUpDown.Value);
    }
}
