namespace FERNGSolver.Gba.UI.FalconKnight.Internal
{
    partial class SearchConditionUserControl
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
            OffsetMinTextBox = new TextBox();
            OffsetMaxTextBox = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 23);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "消費数：";
            // 
            // OffsetMinTextBox
            // 
            OffsetMinTextBox.Location = new Point(77, 20);
            OffsetMinTextBox.Name = "OffsetMinTextBox";
            OffsetMinTextBox.Size = new Size(37, 23);
            OffsetMinTextBox.TabIndex = 1;
            // 
            // OffsetMaxTextBox
            // 
            OffsetMaxTextBox.Location = new Point(146, 20);
            OffsetMaxTextBox.Name = "OffsetMaxTextBox";
            OffsetMaxTextBox.Size = new Size(37, 23);
            OffsetMaxTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(121, 23);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 3;
            label2.Text = "～";
            // 
            // SearchConditionUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(OffsetMaxTextBox);
            Controls.Add(OffsetMinTextBox);
            Controls.Add(label1);
            Name = "SearchConditionUserControl";
            Size = new Size(205, 150);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox OffsetMinTextBox;
        private TextBox OffsetMaxTextBox;
        private Label label2;
    }
}
