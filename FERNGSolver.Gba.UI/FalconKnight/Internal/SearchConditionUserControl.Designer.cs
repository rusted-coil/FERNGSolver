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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            Seed0TextBox = new TextBox();
            Seed1TextBox = new TextBox();
            Seed2TextBox = new TextBox();
            DefaultSeedButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(137, 10);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "消費数：";
            // 
            // OffsetMinTextBox
            // 
            OffsetMinTextBox.Location = new Point(198, 7);
            OffsetMinTextBox.Name = "OffsetMinTextBox";
            OffsetMinTextBox.Size = new Size(37, 23);
            OffsetMinTextBox.TabIndex = 1;
            // 
            // OffsetMaxTextBox
            // 
            OffsetMaxTextBox.Location = new Point(267, 7);
            OffsetMaxTextBox.Name = "OffsetMaxTextBox";
            OffsetMaxTextBox.Size = new Size(37, 23);
            OffsetMaxTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(242, 10);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 3;
            label2.Text = "～";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 10);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 4;
            label3.Text = "Seed[0]:0x";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 38);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 5;
            label4.Text = "Seed[1]:0x";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 66);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 6;
            label5.Text = "Seed[2]:0x";
            // 
            // Seed0TextBox
            // 
            Seed0TextBox.Location = new Point(71, 7);
            Seed0TextBox.Name = "Seed0TextBox";
            Seed0TextBox.Size = new Size(42, 23);
            Seed0TextBox.TabIndex = 7;
            // 
            // Seed1TextBox
            // 
            Seed1TextBox.Location = new Point(71, 35);
            Seed1TextBox.Name = "Seed1TextBox";
            Seed1TextBox.Size = new Size(42, 23);
            Seed1TextBox.TabIndex = 8;
            // 
            // Seed2TextBox
            // 
            Seed2TextBox.Location = new Point(71, 63);
            Seed2TextBox.Name = "Seed2TextBox";
            Seed2TextBox.Size = new Size(42, 23);
            Seed2TextBox.TabIndex = 9;
            // 
            // DefaultSeedButton
            // 
            DefaultSeedButton.Location = new Point(24, 94);
            DefaultSeedButton.Name = "DefaultSeedButton";
            DefaultSeedButton.Size = new Size(75, 23);
            DefaultSeedButton.TabIndex = 10;
            DefaultSeedButton.Text = "Default";
            DefaultSeedButton.UseVisualStyleBackColor = true;
            DefaultSeedButton.Click += DefaultSeedButton_Click;
            // 
            // SearchConditionUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DefaultSeedButton);
            Controls.Add(Seed2TextBox);
            Controls.Add(Seed1TextBox);
            Controls.Add(Seed0TextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
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
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox Seed0TextBox;
        private TextBox Seed1TextBox;
        private TextBox Seed2TextBox;
        private Button DefaultSeedButton;
    }
}
