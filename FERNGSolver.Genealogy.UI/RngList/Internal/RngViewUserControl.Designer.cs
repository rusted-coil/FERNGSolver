namespace FERNGSolver.Genealogy.UI.RngList.Internal
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
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
            PositionNumericUpDown.Name = "PositionNumericUpDown";
            PositionNumericUpDown.Size = new Size(70, 23);
            PositionNumericUpDown.TabIndex = 1;
            PositionNumericUpDown.ValueChanged += PositionNumericUpDown_ValueChanged;
            // 
            // RngViewUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(PositionNumericUpDown);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "RngViewUserControl";
            Size = new Size(398, 148);
            ((System.ComponentModel.ISupportInitialize)PositionNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Common.UI.Controls.NumericUpDownEx PositionNumericUpDown;
    }
}
