namespace FERNGSolver.Common.UI.Controls
{
    public class NumericUpDownEx : NumericUpDown
    {
        public NumericUpDownEx()
        {
            // Enterイベントを設定
            this.Enter += SelectableNumericUpDown_Enter;

            // MouseClickイベントを設定
            this.MouseClick += SelectableNumericUpDown_MouseClick;
        }

        private void SelectableNumericUpDown_Enter(object? sender, EventArgs e)
        {
            // フォーカス時に全選択
            this.Select(0, this.Text.Length);
        }

        private void SelectableNumericUpDown_MouseClick(object? sender, MouseEventArgs e)
        {
            // クリック時に全選択
            this.Select(0, this.Text.Length);
        }
    }
}
