using FERNGSolver.Genealogy.Presentation.RngList.RngView.ViewContracts;
using System.Drawing.Drawing2D;
using System.Reactive.Subjects;

namespace FERNGSolver.Genealogy.UI.RngList.Internal
{
    public partial class RngViewUserControl : UserControl, IRngView
    {
        public IObservable<int> PositionChanged => m_PositionChanged;

        private Subject<int> m_PositionChanged = new Subject<int>();
        private ushort[] m_RandomNumbers = Array.Empty<ushort>();

        public RngViewUserControl()
        {
            InitializeComponent();
        }

        public void SetRandomNumbers(IReadOnlyList<ushort> values)
        {
            m_RandomNumbers = values.ToArray();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 0; i < m_RandomNumbers.Length; i++)
            {
                var x = 10 + (i % 20) * 25; // 行ごとに20個
                var y = 30 + (i / 20) * 60;

                // 数字の描画
                g.DrawString(m_RandomNumbers[i].ToString("D2"), this.Font, Brushes.Black, x, y);

                // 契機の可視化（例：線を引く）
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
