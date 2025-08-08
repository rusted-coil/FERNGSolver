using FERNGSolver.Common.UI.RngView;
using FERNGSolver.Gba.Application.RNG;
using FERNGSolver.Gba.Domain.Combat.Service;
using FERNGSolver.Gba.Presentation.RngView;
using FERNGSolver.Gba.Presentation.RngView.ViewContracts;
using System.Diagnostics;
using System.Reactive.Subjects;

namespace FERNGSolver.Gba.UI.RngView.Internal
{
    public partial class RngViewUserControl : RngViewUserControlBase<IRandomNumberViewModel>, IRngView
    {
        // Viewに使用する定数
        private const int HitUsageOffsetX = 5;
        private const int HitUsageLineLength = 27;

        public int CurrentPosition => (int)PositionNumericUpDown.Value;

        private BehaviorSubject<int> m_PositionChanged;
        public IObservable<int> PositionChanged => m_PositionChanged;

        public RngViewUserControl(int initialPosition) : base()
        {
            InitializeComponent();

            // ValueChangedイベントのハンドラを一時的に解除して初期値をセット
            PositionNumericUpDown.ValueChanged -= PositionNumericUpDown_ValueChanged;
            PositionNumericUpDown.Value = initialPosition;
            PositionNumericUpDown.ValueChanged += PositionNumericUpDown_ValueChanged;

            m_PositionChanged = new BehaviorSubject<int>((int)PositionNumericUpDown.Value);
        }

        protected override (Brush Brush, Pen Pen) GetUsageDrawer(IRandomNumberViewModel viewModel)
        {
            if (viewModel.Usage.IsGrowth())
            {
                return GrowthUsageDrawer;
            }
            var unitSide = viewModel.Usage.GetUnitSide();
            return unitSide switch
            {
                UnitSide.Player => PlayerUsageDrawer,
                UnitSide.Enemy => EnemyUsageDrawer,
                _ => DefaultDrawer,
            };
        }

        protected override bool IsRngValueOk(IRandomNumberViewModel viewModel) => Domain.RNG.Util.IsRngValueOk(viewModel.Value);

        protected override string GetUsageDisplayString(IRandomNumberViewModel viewModel) => viewModel.Usage.ToDisplayString();

        protected override int GetDrawRangedUsageCount(IReadOnlyList<IRandomNumberViewModel> viewModels, int index)
        {
            // 実効命中率
            if ((viewModels[index].Usage == RandomNumberUsage.PlayerHit1 && index + 1 < viewModels.Count && viewModels[index + 1].Usage == RandomNumberUsage.PlayerHit2)
                || (viewModels[index].Usage == RandomNumberUsage.EnemyHit1 && index + 1 < viewModels.Count && viewModels[index + 1].Usage == RandomNumberUsage.EnemyHit2))
            {
                return 2;
            }
            return 0;
        }

        protected override int TryDrawRangedUsage(Graphics g, IReadOnlyList<IRandomNumberViewModel> viewModels, int index, int x, int y)
        {
            var firstViewModel = viewModels[index];
            Debug.Assert(firstViewModel.IsOk != null, "IsOk should not be null when drawing usage.");

            // 実効命中率
            if ((firstViewModel.Usage == RandomNumberUsage.PlayerHit1 && index + 1 < viewModels.Count && viewModels[index + 1].Usage == RandomNumberUsage.PlayerHit2)
                || (firstViewModel.Usage == RandomNumberUsage.EnemyHit1 && index + 1 < viewModels.Count && viewModels[index + 1].Usage == RandomNumberUsage.EnemyHit2))
            {
                var drawer = GetUsageDrawer(firstViewModel);

                g.DrawString(firstViewModel.Usage.ToSpecialDisplayString(), this.Font, drawer.Brush, x + HitUsageOffsetX, y);
                if (firstViewModel.IsOk.Value)
                {
                    g.DrawLine(drawer.Pen, x + HitUsageOffsetX, y + UsageLineOffsetY, x + HitUsageOffsetX + HitUsageLineLength, y + UsageLineOffsetY);
                }
                return 1;
            }
            return 0;
        }

        private void PositionNumericUpDown_ValueChanged(object? sender, EventArgs e) => m_PositionChanged.OnNext((int)PositionNumericUpDown.Value);
    }
}
