using FERNGSolver.Common.UI.RngView;
using FERNGSolver.Genealogy.Application.RNG;
using FERNGSolver.Genealogy.Domain.Combat.Service;
using FERNGSolver.Genealogy.Presentation.RngView;
using FERNGSolver.Genealogy.Presentation.RngView.ViewContracts;
using System.Reactive.Subjects;

namespace FERNGSolver.Genealogy.UI.RngView.Internal
{
    public partial class RngViewUserControl : RngViewUserControlBase<IRandomNumberViewModel>, IRngView
    {
        // 聖戦はファルコンナイト法非対応
        protected override bool SupportsFalconKnightMethod => false;

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

        protected override string GetUsageDisplayString(IRandomNumberViewModel viewModel) => viewModel.Usage.ToDisplayString();

        private void PositionNumericUpDown_ValueChanged(object? sender, EventArgs e) => m_PositionChanged.OnNext((int)PositionNumericUpDown.Value);
    }
}
