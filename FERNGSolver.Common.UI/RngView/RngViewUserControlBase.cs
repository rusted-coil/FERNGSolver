using FERNGSolver.Common.Presentation.ViewContracts;
using FormRx.Button;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Reactive;

namespace FERNGSolver.Common.UI.RngView
{
    public partial class RngViewUserControlBase<TViewModel> : UserControl where TViewModel : IRandomNumberViewModel
    {
        // Viewに使用する定数
        private const int RngNumberStartX = 5; // 乱数値の表示開始X座標
        private const int RngNumberStartY = 32; // 乱数値の表示開始Y座標
        private const int RngNumberIntervalX = 22; // 乱数値の表示位置X座標間隔
        private const int CxOffsetX = 1;
        private const int CxOffsetY = 20; // ◯×表示のY座標オフセット
        private const int UsageOffsetY = 20; // 乱数値の使用状況表示のY座標オフセット
        private const int UsageLineLength = 16;
        protected const int UsageLineOffsetY = 16;

        // ブラシとペンのキャッシュ
        protected static readonly (Brush Brush, Pen Pen) DefaultDrawer = (Brushes.Black, Pens.Black);
        protected static readonly (Brush Brush, Pen Pen) GrowthUsageDrawer = (Brushes.DarkGreen, Pens.DarkGreen);
        protected static readonly (Brush Brush, Pen Pen) PlayerUsageDrawer = (Brushes.Blue, Pens.Blue);
        protected static readonly (Brush Brush, Pen Pen) EnemyUsageDrawer = (Brushes.Red, Pens.Red);

        /// <summary>
        /// 指定したViewModelのUsageを描画するためのブラシとペンを返してください。
        /// </summary>
        protected virtual (Brush Brush, Pen Pen) GetUsageDrawer(TViewModel viewModel) => DefaultDrawer;

        private readonly IButton m_RemoveButton;
        public IObservable<Unit> RemoveButtonClicked => m_RemoveButton.Clicked;

        /// <summary>
        /// ファルコンナイト法の行を表示するかどうか(=派生クラスの作品がファルコンナイト法をサポートしているか)を返してください。
        /// </summary>
        protected virtual bool SupportsFalconKnightMethod => true;

        /// <summary>
        /// 指定したViewModelが◯✕のどちらかを返してください。
        /// </summary>
        protected virtual bool IsRngValueOk(TViewModel viewModel) => false;

        int ViewHeight => SupportsFalconKnightMethod ? 105 : 85;

        private TViewModel[] m_RandomNumberViewModels = Array.Empty<TViewModel>();

        public RngViewUserControlBase()
        {
            InitializeComponent();
            this.Height = ViewHeight;

            m_RemoveButton = ButtonFactory.CreateButton(RemoveButton);
        }

        public void SetRandomNumbers(IReadOnlyList<TViewModel> viewModels)
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

                if (SupportsFalconKnightMethod)
                {
                    y += CxOffsetY;
                    g.DrawString(IsRngValueOk(m_RandomNumberViewModels[i]) ? "◯" : "✕", this.Font, Brushes.Black, x + CxOffsetX, y);
                }

                if (m_RandomNumberViewModels[i].IsOk == null)
                {
                    continue; // 判定が行われていない場合はスキップ
                }

                if (skipCount == 0)
                {
                    y += UsageOffsetY;
                    if ((skipCount = TryDrawRangedUsage(g, m_RandomNumberViewModels, i, x, y)) == 0)
                    {
                        DrawUsage(g, m_RandomNumberViewModels[i], x, y);
                    }
                }
                else
                {
                    skipCount--;
                }
            }
        }

        /// <summary>
        /// 指定したViewModelのUsageを表示するための文字列を返してください。
        /// </summary>
        protected virtual string GetUsageDisplayString(TViewModel viewModel) => string.Empty;

        /// <summary>
        /// viewModelのリストの指定したIndexを始点とし、複数に跨った描画をする場合、そのUsageの数を返してください。
        /// </summary>
        protected virtual int GetDrawRangedUsageCount(IReadOnlyList<TViewModel> viewModels, int index) => 0;

        // 複数に跨る特殊な描画が必要な場合は処理を行ってください。描画を行った場合はその後スキップする数(1以上)を返します。
        protected virtual int TryDrawRangedUsage(Graphics g, IReadOnlyList<TViewModel> viewModels, int index, int x, int y)
        {
            return 0;
        }

        // 通常のUsageの描画を行う。
        private void DrawUsage(Graphics g, TViewModel viewModel, int x, int y)
        {
            Debug.Assert(viewModel.IsOk != null, "IsOk should not be null when drawing usage.");

            var drawer = GetUsageDrawer(viewModel);

            g.DrawString(GetUsageDisplayString(viewModel), this.Font, drawer.Brush, x, y);
            if (viewModel.IsOk.Value)
            {
                g.DrawLine(drawer.Pen, x, y + UsageLineOffsetY, x + UsageLineLength, y + UsageLineOffsetY);
            }
        }
    }
}
