namespace FERNGSolver.Radiance.UI.RngView.Internal
{
    partial class RngViewUserControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // ジェネリッククラスのためデザイナーで編集することを諦め、以下の内容を手動で記述する。
        private new void InitializeComponent()
        {
            label1 = new Label();
            PositionNumericUpDown = new FERNGSolver.Common.UI.Controls.NumericUpDownEx();
            ((System.ComponentModel.ISupportInitialize)PositionNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 7);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "消費数:";

            // 
            // PositionNumericUpDown
            // 
            PositionNumericUpDown.Location = new Point(48, 5);
            PositionNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            PositionNumericUpDown.Name = "PositionNumericUpDown";
            PositionNumericUpDown.Size = new Size(70, 23);
            PositionNumericUpDown.TabIndex = 1;
            PositionNumericUpDown.TextAlign = HorizontalAlignment.Right;
            PositionNumericUpDown.ValueChanged += PositionNumericUpDown_ValueChanged;

            // 
            // RngViewUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(PositionNumericUpDown);
            Controls.Add(label1);
            Name = "RngViewUserControl";
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(PositionNumericUpDown, 0);
            ((System.ComponentModel.ISupportInitialize)PositionNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Common.UI.Controls.NumericUpDownEx PositionNumericUpDown;
    }
}
