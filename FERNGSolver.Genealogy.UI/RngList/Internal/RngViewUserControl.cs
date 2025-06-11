using FERNGSolver.Genealogy.Presentation.RngList.RngView.ViewContracts;
using System.Drawing.Drawing2D;

namespace FERNGSolver.Genealogy.UI.RngList.Internal
{
    public partial class RngViewUserControl : UserControl, IRngView
    {
        private int[] m_RandomNumbers = Array.Empty<int>();

        public RngViewUserControl()
        {
            InitializeComponent();
        }

        public void SetRandomNumbers(IReadOnlyList<int> values)
        {
            m_RandomNumbers = values.ToArray();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 0; i < m_RandomNumbers.Length; i++)
            {
                var x = 10 + (i % 20) * 40; // 行ごとに20個
                var y = 10 + (i / 20) * 60;

                // 数字の描画
                g.DrawString(m_RandomNumbers[i].ToString("D2"), this.Font, Brushes.Black, x, y);

                // 契機の可視化（例：線を引く）
                {
                    g.DrawLine(Pens.Red, x, y + 20, x + 30, y + 20);
                }
            }
        }
    }
}
