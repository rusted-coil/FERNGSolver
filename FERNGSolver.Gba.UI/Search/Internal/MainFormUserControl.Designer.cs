namespace FERNGSolver.Gba.UI.Search
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
            DefaultSeedButton = new Button();
            Seed2TextBox = new TextBox();
            Seed1TextBox = new TextBox();
            Seed0TextBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            OffsetMaxTextBox = new TextBox();
            OffsetMinTextBox = new TextBox();
            label1 = new Label();
            ContainsCombatCheckBox = new CheckBox();
            CombatGroupBox = new GroupBox();
            GrowthGroupBox = new GroupBox();
            ContainsGrowthCheckBox = new CheckBox();
            label6 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label7 = new Label();
            textBox3 = new TextBox();
            label8 = new Label();
            textBox4 = new TextBox();
            label9 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            comboBox1 = new ComboBox();
            label10 = new Label();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label11 = new Label();
            textBox7 = new TextBox();
            label12 = new Label();
            textBox8 = new TextBox();
            label13 = new Label();
            textBox9 = new TextBox();
            label14 = new Label();
            textBox10 = new TextBox();
            label15 = new Label();
            textBox11 = new TextBox();
            label16 = new Label();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox7 = new CheckBox();
            checkBox8 = new CheckBox();
            checkBox9 = new CheckBox();
            CombatGroupBox.SuspendLayout();
            GrowthGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // DefaultSeedButton
            // 
            DefaultSeedButton.Location = new Point(25, 412);
            DefaultSeedButton.Name = "DefaultSeedButton";
            DefaultSeedButton.Size = new Size(75, 23);
            DefaultSeedButton.TabIndex = 21;
            DefaultSeedButton.Text = "Default";
            DefaultSeedButton.UseVisualStyleBackColor = true;
            DefaultSeedButton.Click += DefaultSeedButton_Click;
            // 
            // Seed2TextBox
            // 
            Seed2TextBox.Location = new Point(72, 381);
            Seed2TextBox.Name = "Seed2TextBox";
            Seed2TextBox.Size = new Size(42, 23);
            Seed2TextBox.TabIndex = 20;
            // 
            // Seed1TextBox
            // 
            Seed1TextBox.Location = new Point(72, 353);
            Seed1TextBox.Name = "Seed1TextBox";
            Seed1TextBox.Size = new Size(42, 23);
            Seed1TextBox.TabIndex = 19;
            // 
            // Seed0TextBox
            // 
            Seed0TextBox.Location = new Point(72, 325);
            Seed0TextBox.Name = "Seed0TextBox";
            Seed0TextBox.Size = new Size(42, 23);
            Seed0TextBox.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 384);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 17;
            label5.Text = "Seed[2]:0x";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 356);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 16;
            label4.Text = "Seed[1]:0x";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 328);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 15;
            label3.Text = "Seed[0]:0x";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(243, 328);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 14;
            label2.Text = "～";
            // 
            // OffsetMaxTextBox
            // 
            OffsetMaxTextBox.Location = new Point(268, 325);
            OffsetMaxTextBox.Name = "OffsetMaxTextBox";
            OffsetMaxTextBox.Size = new Size(37, 23);
            OffsetMaxTextBox.TabIndex = 13;
            // 
            // OffsetMinTextBox
            // 
            OffsetMinTextBox.Location = new Point(199, 325);
            OffsetMinTextBox.Name = "OffsetMinTextBox";
            OffsetMinTextBox.Size = new Size(37, 23);
            OffsetMinTextBox.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 328);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 11;
            label1.Text = "消費数：";
            // 
            // ContainsCombatCheckBox
            // 
            ContainsCombatCheckBox.AutoSize = true;
            ContainsCombatCheckBox.Location = new Point(6, 0);
            ContainsCombatCheckBox.Name = "ContainsCombatCheckBox";
            ContainsCombatCheckBox.Size = new Size(79, 19);
            ContainsCombatCheckBox.TabIndex = 22;
            ContainsCombatCheckBox.Text = "戦闘を行う";
            ContainsCombatCheckBox.UseVisualStyleBackColor = true;
            // 
            // CombatGroupBox
            // 
            CombatGroupBox.Controls.Add(checkBox2);
            CombatGroupBox.Controls.Add(checkBox1);
            CombatGroupBox.Controls.Add(textBox3);
            CombatGroupBox.Controls.Add(label8);
            CombatGroupBox.Controls.Add(textBox4);
            CombatGroupBox.Controls.Add(label9);
            CombatGroupBox.Controls.Add(textBox2);
            CombatGroupBox.Controls.Add(label7);
            CombatGroupBox.Controls.Add(textBox1);
            CombatGroupBox.Controls.Add(label6);
            CombatGroupBox.Controls.Add(ContainsCombatCheckBox);
            CombatGroupBox.Location = new Point(11, 5);
            CombatGroupBox.Name = "CombatGroupBox";
            CombatGroupBox.Size = new Size(401, 114);
            CombatGroupBox.TabIndex = 23;
            CombatGroupBox.TabStop = false;
            // 
            // GrowthGroupBox
            // 
            GrowthGroupBox.Controls.Add(checkBox9);
            GrowthGroupBox.Controls.Add(checkBox8);
            GrowthGroupBox.Controls.Add(checkBox7);
            GrowthGroupBox.Controls.Add(checkBox6);
            GrowthGroupBox.Controls.Add(checkBox5);
            GrowthGroupBox.Controls.Add(checkBox4);
            GrowthGroupBox.Controls.Add(checkBox3);
            GrowthGroupBox.Controls.Add(textBox11);
            GrowthGroupBox.Controls.Add(label16);
            GrowthGroupBox.Controls.Add(textBox8);
            GrowthGroupBox.Controls.Add(label13);
            GrowthGroupBox.Controls.Add(textBox9);
            GrowthGroupBox.Controls.Add(label14);
            GrowthGroupBox.Controls.Add(textBox10);
            GrowthGroupBox.Controls.Add(label15);
            GrowthGroupBox.Controls.Add(textBox7);
            GrowthGroupBox.Controls.Add(label12);
            GrowthGroupBox.Controls.Add(textBox6);
            GrowthGroupBox.Controls.Add(label11);
            GrowthGroupBox.Controls.Add(textBox5);
            GrowthGroupBox.Controls.Add(label10);
            GrowthGroupBox.Controls.Add(comboBox1);
            GrowthGroupBox.Controls.Add(ContainsGrowthCheckBox);
            GrowthGroupBox.Location = new Point(11, 125);
            GrowthGroupBox.Name = "GrowthGroupBox";
            GrowthGroupBox.Size = new Size(401, 181);
            GrowthGroupBox.TabIndex = 24;
            GrowthGroupBox.TabStop = false;
            // 
            // ContainsGrowthCheckBox
            // 
            ContainsGrowthCheckBox.AutoSize = true;
            ContainsGrowthCheckBox.Location = new Point(6, 0);
            ContainsGrowthCheckBox.Name = "ContainsGrowthCheckBox";
            ContainsGrowthCheckBox.Size = new Size(81, 19);
            ContainsGrowthCheckBox.TabIndex = 22;
            ContainsGrowthCheckBox.Text = "レベルアップ";
            ContainsGrowthCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 25);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 23;
            label6.Text = "命中";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(47, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(42, 23);
            textBox1.TabIndex = 24;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(47, 50);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(42, 23);
            textBox2.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 53);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 25;
            label7.Text = "必殺";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(144, 50);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(42, 23);
            textBox3.TabIndex = 30;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(111, 53);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 29;
            label8.Text = "必殺";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(144, 22);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(42, 23);
            textBox4.TabIndex = 28;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(111, 25);
            label9.Name = "label9";
            label9.Size = new Size(31, 15);
            label9.TabIndex = 27;
            label9.Text = "命中";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(19, 81);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(50, 19);
            checkBox1.TabIndex = 31;
            checkBox1.Text = "追撃";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(116, 81);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(50, 19);
            checkBox2.TabIndex = 32;
            checkBox2.Text = "反撃";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(16, 25);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(134, 23);
            comboBox1.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 61);
            label10.Name = "label10";
            label10.Size = new Size(23, 15);
            label10.TabIndex = 33;
            label10.Text = "HP";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(45, 58);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(42, 23);
            textBox5.TabIndex = 33;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(45, 86);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(42, 23);
            textBox6.TabIndex = 34;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(16, 89);
            label11.Name = "label11";
            label11.Size = new Size(19, 15);
            label11.TabIndex = 35;
            label11.Text = "力";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(45, 114);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(42, 23);
            textBox7.TabIndex = 36;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(16, 117);
            label12.Name = "label12";
            label12.Size = new Size(19, 15);
            label12.TabIndex = 37;
            label12.Text = "技";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(161, 114);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(42, 23);
            textBox8.TabIndex = 42;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(132, 117);
            label13.Name = "label13";
            label13.Size = new Size(31, 15);
            label13.TabIndex = 43;
            label13.Text = "魔防";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(161, 86);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(42, 23);
            textBox9.TabIndex = 40;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(132, 89);
            label14.Name = "label14";
            label14.Size = new Size(31, 15);
            label14.TabIndex = 41;
            label14.Text = "守備";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(161, 58);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(42, 23);
            textBox10.TabIndex = 38;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(132, 61);
            label15.Name = "label15";
            label15.Size = new Size(31, 15);
            label15.TabIndex = 39;
            label15.Text = "幸運";
            // 
            // textBox11
            // 
            textBox11.Location = new Point(45, 142);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(42, 23);
            textBox11.TabIndex = 44;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(16, 145);
            label16.Name = "label16";
            label16.Size = new Size(27, 15);
            label16.TabIndex = 45;
            label16.Text = "速さ";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(93, 62);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(15, 14);
            checkBox3.TabIndex = 46;
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(93, 90);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(15, 14);
            checkBox4.TabIndex = 47;
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(93, 118);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(15, 14);
            checkBox5.TabIndex = 48;
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(93, 146);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(15, 14);
            checkBox6.TabIndex = 49;
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(210, 62);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(15, 14);
            checkBox7.TabIndex = 50;
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Location = new Point(210, 90);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(15, 14);
            checkBox8.TabIndex = 51;
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Location = new Point(210, 118);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(15, 14);
            checkBox9.TabIndex = 52;
            checkBox9.UseVisualStyleBackColor = true;
            // 
            // MainFormUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(GrowthGroupBox);
            Controls.Add(CombatGroupBox);
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
            Name = "MainFormUserControl";
            Size = new Size(645, 609);
            CombatGroupBox.ResumeLayout(false);
            CombatGroupBox.PerformLayout();
            GrowthGroupBox.ResumeLayout(false);
            GrowthGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DefaultSeedButton;
        private TextBox Seed2TextBox;
        private TextBox Seed1TextBox;
        private TextBox Seed0TextBox;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox OffsetMaxTextBox;
        private TextBox OffsetMinTextBox;
        private Label label1;
        private CheckBox ContainsCombatCheckBox;
        private GroupBox CombatGroupBox;
        private GroupBox GrowthGroupBox;
        private CheckBox ContainsGrowthCheckBox;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private TextBox textBox3;
        private Label label8;
        private TextBox textBox4;
        private Label label9;
        private TextBox textBox2;
        private Label label7;
        private TextBox textBox1;
        private Label label6;
        private ComboBox comboBox1;
        private CheckBox checkBox9;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private TextBox textBox11;
        private Label label16;
        private TextBox textBox8;
        private Label label13;
        private TextBox textBox9;
        private Label label14;
        private TextBox textBox10;
        private Label label15;
        private TextBox textBox7;
        private Label label12;
        private TextBox textBox6;
        private Label label11;
        private TextBox textBox5;
        private Label label10;
    }
}
