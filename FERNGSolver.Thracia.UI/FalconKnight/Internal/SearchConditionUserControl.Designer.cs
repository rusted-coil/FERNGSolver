namespace FERNGSolver.Thracia.UI.FalconKnight.Internal
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
            IsSpecificTableCheckBox = new CheckBox();
            TableIndexTextBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 42);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "消費数：";
            // 
            // OffsetMinTextBox
            // 
            OffsetMinTextBox.Location = new Point(71, 39);
            OffsetMinTextBox.Name = "OffsetMinTextBox";
            OffsetMinTextBox.Size = new Size(37, 23);
            OffsetMinTextBox.TabIndex = 1;
            // 
            // OffsetMaxTextBox
            // 
            OffsetMaxTextBox.Location = new Point(140, 39);
            OffsetMaxTextBox.Name = "OffsetMaxTextBox";
            OffsetMaxTextBox.Size = new Size(37, 23);
            OffsetMaxTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 42);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 3;
            label2.Text = "～";
            // 
            // IsSpecificTableCheckBox
            // 
            IsSpecificTableCheckBox.AutoSize = true;
            IsSpecificTableCheckBox.Location = new Point(14, 10);
            IsSpecificTableCheckBox.Name = "IsSpecificTableCheckBox";
            IsSpecificTableCheckBox.Size = new Size(120, 19);
            IsSpecificTableCheckBox.TabIndex = 4;
            IsSpecificTableCheckBox.Text = "指定テーブルのみ: #";
            IsSpecificTableCheckBox.UseVisualStyleBackColor = true;
            // 
            // TableIndexTextBox
            // 
            TableIndexTextBox.Location = new Point(131, 8);
            TableIndexTextBox.Name = "TableIndexTextBox";
            TableIndexTextBox.Size = new Size(37, 23);
            TableIndexTextBox.TabIndex = 5;
            // 
            // SearchConditionUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TableIndexTextBox);
            Controls.Add(IsSpecificTableCheckBox);
            Controls.Add(label2);
            Controls.Add(OffsetMaxTextBox);
            Controls.Add(OffsetMinTextBox);
            Controls.Add(label1);
            Name = "SearchConditionUserControl";
            Size = new Size(338, 215);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox OffsetMinTextBox;
        private TextBox OffsetMaxTextBox;
        private Label label2;
        private CheckBox IsSpecificTableCheckBox;
        private TextBox TableIndexTextBox;
    }
}
