namespace FERNGSolver.Thracia.UI.Search.Internal
{
    partial class MainFormUserControl
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
            FalconKnightMethodGroupBox = new GroupBox();
            FalconKnightToolOpenButton = new Button();
            AddsCxOffset = new CheckBox();
            label17 = new Label();
            CxStringTextBox = new TextBox();
            UsesFalconKnightMethodCheckBox = new CheckBox();
            IsSpecificTableCheckBox = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            numericUpDownEx1 = new Windows.Common.Controls.NumericUpDownEx();
            numericUpDownEx2 = new Windows.Common.Controls.NumericUpDownEx();
            numericUpDownEx3 = new Windows.Common.Controls.NumericUpDownEx();
            FalconKnightMethodGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEx1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEx2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEx3).BeginInit();
            SuspendLayout();
            // 
            // FalconKnightMethodGroupBox
            // 
            FalconKnightMethodGroupBox.Controls.Add(FalconKnightToolOpenButton);
            FalconKnightMethodGroupBox.Controls.Add(AddsCxOffset);
            FalconKnightMethodGroupBox.Controls.Add(label17);
            FalconKnightMethodGroupBox.Controls.Add(CxStringTextBox);
            FalconKnightMethodGroupBox.Controls.Add(UsesFalconKnightMethodCheckBox);
            FalconKnightMethodGroupBox.Location = new Point(11, 12);
            FalconKnightMethodGroupBox.Name = "FalconKnightMethodGroupBox";
            FalconKnightMethodGroupBox.Size = new Size(620, 59);
            FalconKnightMethodGroupBox.TabIndex = 12;
            FalconKnightMethodGroupBox.TabStop = false;
            // 
            // FalconKnightToolOpenButton
            // 
            FalconKnightToolOpenButton.Location = new Point(505, 20);
            FalconKnightToolOpenButton.Name = "FalconKnightToolOpenButton";
            FalconKnightToolOpenButton.Size = new Size(75, 25);
            FalconKnightToolOpenButton.TabIndex = 3;
            FalconKnightToolOpenButton.Text = "補助ツール";
            FalconKnightToolOpenButton.UseVisualStyleBackColor = true;
            // 
            // AddsCxOffset
            // 
            AddsCxOffset.AutoSize = true;
            AddsCxOffset.Location = new Point(344, 24);
            AddsCxOffset.Name = "AddsCxOffset";
            AddsCxOffset.Size = new Size(140, 19);
            AddsCxOffset.TabIndex = 2;
            AddsCxOffset.Text = "入力分を消費数に加算";
            AddsCxOffset.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(14, 25);
            label17.Name = "label17";
            label17.Size = new Size(37, 15);
            label17.TabIndex = 24;
            label17.Text = "cx列: ";
            // 
            // CxStringTextBox
            // 
            CxStringTextBox.Location = new Point(52, 22);
            CxStringTextBox.Name = "CxStringTextBox";
            CxStringTextBox.Size = new Size(269, 23);
            CxStringTextBox.TabIndex = 1;
            // 
            // UsesFalconKnightMethodCheckBox
            // 
            UsesFalconKnightMethodCheckBox.AutoSize = true;
            UsesFalconKnightMethodCheckBox.Location = new Point(6, 0);
            UsesFalconKnightMethodCheckBox.Name = "UsesFalconKnightMethodCheckBox";
            UsesFalconKnightMethodCheckBox.Size = new Size(130, 19);
            UsesFalconKnightMethodCheckBox.TabIndex = 0;
            UsesFalconKnightMethodCheckBox.Text = "ファルコンナイト法検索";
            UsesFalconKnightMethodCheckBox.UseVisualStyleBackColor = true;
            // 
            // IsSpecificTableCheckBox
            // 
            IsSpecificTableCheckBox.AutoSize = true;
            IsSpecificTableCheckBox.Location = new Point(24, 639);
            IsSpecificTableCheckBox.Name = "IsSpecificTableCheckBox";
            IsSpecificTableCheckBox.Size = new Size(119, 19);
            IsSpecificTableCheckBox.TabIndex = 17;
            IsSpecificTableCheckBox.Text = "指定テーブルのみ: #";
            IsSpecificTableCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(301, 640);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 16;
            label2.Text = "～";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(182, 640);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 13;
            label1.Text = "消費数：";
            // 
            // numericUpDownEx1
            // 
            numericUpDownEx1.Location = new Point(139, 638);
            numericUpDownEx1.Maximum = new decimal(new int[] { 63, 0, 0, 0 });
            numericUpDownEx1.Name = "numericUpDownEx1";
            numericUpDownEx1.Size = new Size(37, 23);
            numericUpDownEx1.TabIndex = 19;
            // 
            // numericUpDownEx2
            // 
            numericUpDownEx2.Location = new Point(235, 638);
            numericUpDownEx2.Name = "numericUpDownEx2";
            numericUpDownEx2.Size = new Size(60, 23);
            numericUpDownEx2.TabIndex = 20;
            // 
            // numericUpDownEx3
            // 
            numericUpDownEx3.Location = new Point(326, 638);
            numericUpDownEx3.Name = "numericUpDownEx3";
            numericUpDownEx3.Size = new Size(56, 23);
            numericUpDownEx3.TabIndex = 21;
            // 
            // MainFormUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numericUpDownEx3);
            Controls.Add(numericUpDownEx2);
            Controls.Add(numericUpDownEx1);
            Controls.Add(IsSpecificTableCheckBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(FalconKnightMethodGroupBox);
            Name = "MainFormUserControl";
            Size = new Size(640, 670);
            FalconKnightMethodGroupBox.ResumeLayout(false);
            FalconKnightMethodGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEx1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEx2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEx3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox FalconKnightMethodGroupBox;
        private Button FalconKnightToolOpenButton;
        private CheckBox AddsCxOffset;
        private Label label17;
        private TextBox CxStringTextBox;
        private CheckBox UsesFalconKnightMethodCheckBox;
        private CheckBox IsSpecificTableCheckBox;
        private Label label2;
        private Label label1;
        private Windows.Common.Controls.NumericUpDownEx numericUpDownEx1;
        private Windows.Common.Controls.NumericUpDownEx numericUpDownEx2;
        private Windows.Common.Controls.NumericUpDownEx numericUpDownEx3;
    }
}
