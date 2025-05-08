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
            label2 = new Label();
            OffsetMaxTextBox = new TextBox();
            OffsetMinTextBox = new TextBox();
            label1 = new Label();
            ContainsCombatCheckBox = new CheckBox();
            CombatGroupBox = new GroupBox();
            IsDefenderDoubleAttackCheckBox = new CheckBox();
            IsAttackerDoubleAttackCheckBox = new CheckBox();
            DoesAttackerFollowUpAttackCheckBox = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            DoesDefenderAttackCheckBox = new CheckBox();
            DoesDefenderFollowUpAttackCheckBox = new CheckBox();
            DefenderCriticalRateNumericUpDown = new NumericUpDown();
            label8 = new Label();
            DefenderHitRateNumericUpDown = new NumericUpDown();
            label9 = new Label();
            AttackerCriticalRateNumericUpDown = new NumericUpDown();
            label7 = new Label();
            AttackerHitRateNumericUpDown = new NumericUpDown();
            label6 = new Label();
            GrowthGroupBox = new GroupBox();
            IsGrowthBoostedCheckBox = new CheckBox();
            checkBox9 = new CheckBox();
            checkBox8 = new CheckBox();
            checkBox7 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            GrowthSpdRateNumericUpDown = new NumericUpDown();
            label16 = new Label();
            GrowthMdfRateNumericUpDown = new NumericUpDown();
            label13 = new Label();
            GrowthDefRateNumericUpDown = new NumericUpDown();
            label14 = new Label();
            GrowthLucRateNumericUpDown = new NumericUpDown();
            label15 = new Label();
            GrowthTecRateNumericUpDown = new NumericUpDown();
            label12 = new Label();
            GrowthAtkRateNumericUpDown = new NumericUpDown();
            label11 = new Label();
            GrowthHpRateNumericUpDown = new NumericUpDown();
            label10 = new Label();
            GrowthCharacterNameComboBox = new ComboBox();
            ContainsGrowthCheckBox = new CheckBox();
            FalconKnightMethodGroupBox = new GroupBox();
            FalconKnightToolOpenButton = new Button();
            AddsCxOffset = new CheckBox();
            label17 = new Label();
            CxStringTextBox = new TextBox();
            UsesFalconKnightMethodCheckBox = new CheckBox();
            CombatGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DefenderCriticalRateNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DefenderHitRateNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AttackerCriticalRateNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AttackerHitRateNumericUpDown).BeginInit();
            GrowthGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GrowthSpdRateNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GrowthMdfRateNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GrowthDefRateNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GrowthLucRateNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GrowthTecRateNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GrowthAtkRateNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GrowthHpRateNumericUpDown).BeginInit();
            FalconKnightMethodGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // DefaultSeedButton
            // 
            DefaultSeedButton.Location = new Point(202, 557);
            DefaultSeedButton.Name = "DefaultSeedButton";
            DefaultSeedButton.Size = new Size(75, 23);
            DefaultSeedButton.TabIndex = 104;
            DefaultSeedButton.Text = "Default";
            DefaultSeedButton.UseVisualStyleBackColor = true;
            DefaultSeedButton.Click += DefaultSeedButton_Click;
            // 
            // Seed2TextBox
            // 
            Seed2TextBox.Location = new Point(154, 558);
            Seed2TextBox.Name = "Seed2TextBox";
            Seed2TextBox.Size = new Size(42, 23);
            Seed2TextBox.TabIndex = 103;
            // 
            // Seed1TextBox
            // 
            Seed1TextBox.Location = new Point(106, 558);
            Seed1TextBox.Name = "Seed1TextBox";
            Seed1TextBox.Size = new Size(42, 23);
            Seed1TextBox.TabIndex = 102;
            // 
            // Seed0TextBox
            // 
            Seed0TextBox.Location = new Point(58, 558);
            Seed0TextBox.Name = "Seed0TextBox";
            Seed0TextBox.Size = new Size(42, 23);
            Seed0TextBox.TabIndex = 101;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 561);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 17;
            label5.Text = "Seed:0x";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(406, 561);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 14;
            label2.Text = "～";
            // 
            // OffsetMaxTextBox
            // 
            OffsetMaxTextBox.Location = new Point(431, 558);
            OffsetMaxTextBox.Name = "OffsetMaxTextBox";
            OffsetMaxTextBox.Size = new Size(37, 23);
            OffsetMaxTextBox.TabIndex = 106;
            // 
            // OffsetMinTextBox
            // 
            OffsetMinTextBox.Location = new Point(362, 558);
            OffsetMinTextBox.Name = "OffsetMinTextBox";
            OffsetMinTextBox.Size = new Size(37, 23);
            OffsetMinTextBox.TabIndex = 105;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(314, 561);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 11;
            label1.Text = "消費数: ";
            // 
            // ContainsCombatCheckBox
            // 
            ContainsCombatCheckBox.AutoSize = true;
            ContainsCombatCheckBox.Location = new Point(6, 0);
            ContainsCombatCheckBox.Name = "ContainsCombatCheckBox";
            ContainsCombatCheckBox.Size = new Size(79, 19);
            ContainsCombatCheckBox.TabIndex = 0;
            ContainsCombatCheckBox.Text = "戦闘を行う";
            ContainsCombatCheckBox.UseVisualStyleBackColor = true;
            // 
            // CombatGroupBox
            // 
            CombatGroupBox.Controls.Add(IsDefenderDoubleAttackCheckBox);
            CombatGroupBox.Controls.Add(IsAttackerDoubleAttackCheckBox);
            CombatGroupBox.Controls.Add(DoesAttackerFollowUpAttackCheckBox);
            CombatGroupBox.Controls.Add(label4);
            CombatGroupBox.Controls.Add(label3);
            CombatGroupBox.Controls.Add(DoesDefenderAttackCheckBox);
            CombatGroupBox.Controls.Add(DoesDefenderFollowUpAttackCheckBox);
            CombatGroupBox.Controls.Add(DefenderCriticalRateNumericUpDown);
            CombatGroupBox.Controls.Add(label8);
            CombatGroupBox.Controls.Add(DefenderHitRateNumericUpDown);
            CombatGroupBox.Controls.Add(label9);
            CombatGroupBox.Controls.Add(AttackerCriticalRateNumericUpDown);
            CombatGroupBox.Controls.Add(label7);
            CombatGroupBox.Controls.Add(AttackerHitRateNumericUpDown);
            CombatGroupBox.Controls.Add(label6);
            CombatGroupBox.Controls.Add(ContainsCombatCheckBox);
            CombatGroupBox.Location = new Point(11, 77);
            CombatGroupBox.Name = "CombatGroupBox";
            CombatGroupBox.Size = new Size(620, 282);
            CombatGroupBox.TabIndex = 20;
            CombatGroupBox.TabStop = false;
            // 
            // IsDefenderDoubleAttackCheckBox
            // 
            IsDefenderDoubleAttackCheckBox.AutoSize = true;
            IsDefenderDoubleAttackCheckBox.Location = new Point(343, 57);
            IsDefenderDoubleAttackCheckBox.Name = "IsDefenderDoubleAttackCheckBox";
            IsDefenderDoubleAttackCheckBox.Size = new Size(50, 19);
            IsDefenderDoubleAttackCheckBox.TabIndex = 24;
            IsDefenderDoubleAttackCheckBox.Text = "連撃";
            IsDefenderDoubleAttackCheckBox.UseVisualStyleBackColor = true;
            // 
            // IsAttackerDoubleAttackCheckBox
            // 
            IsAttackerDoubleAttackCheckBox.AutoSize = true;
            IsAttackerDoubleAttackCheckBox.Location = new Point(343, 24);
            IsAttackerDoubleAttackCheckBox.Name = "IsAttackerDoubleAttackCheckBox";
            IsAttackerDoubleAttackCheckBox.Size = new Size(50, 19);
            IsAttackerDoubleAttackCheckBox.TabIndex = 14;
            IsAttackerDoubleAttackCheckBox.Text = "連撃";
            IsAttackerDoubleAttackCheckBox.UseVisualStyleBackColor = true;
            // 
            // DoesAttackerFollowUpAttackCheckBox
            // 
            DoesAttackerFollowUpAttackCheckBox.AutoSize = true;
            DoesAttackerFollowUpAttackCheckBox.Location = new Point(287, 24);
            DoesAttackerFollowUpAttackCheckBox.Name = "DoesAttackerFollowUpAttackCheckBox";
            DoesAttackerFollowUpAttackCheckBox.Size = new Size(50, 19);
            DoesAttackerFollowUpAttackCheckBox.TabIndex = 13;
            DoesAttackerFollowUpAttackCheckBox.Text = "追撃";
            DoesAttackerFollowUpAttackCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 58);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 34;
            label4.Text = "反撃側: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 25);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 33;
            label3.Text = "攻撃側: ";
            // 
            // DoesDefenderAttackCheckBox
            // 
            DoesDefenderAttackCheckBox.AutoSize = true;
            DoesDefenderAttackCheckBox.Location = new Point(231, 57);
            DoesDefenderAttackCheckBox.Name = "DoesDefenderAttackCheckBox";
            DoesDefenderAttackCheckBox.Size = new Size(50, 19);
            DoesDefenderAttackCheckBox.TabIndex = 22;
            DoesDefenderAttackCheckBox.Text = "反撃";
            DoesDefenderAttackCheckBox.UseVisualStyleBackColor = true;
            // 
            // DoesDefenderFollowUpAttackCheckBox
            // 
            DoesDefenderFollowUpAttackCheckBox.AutoSize = true;
            DoesDefenderFollowUpAttackCheckBox.Location = new Point(287, 57);
            DoesDefenderFollowUpAttackCheckBox.Name = "DoesDefenderFollowUpAttackCheckBox";
            DoesDefenderFollowUpAttackCheckBox.Size = new Size(50, 19);
            DoesDefenderFollowUpAttackCheckBox.TabIndex = 23;
            DoesDefenderFollowUpAttackCheckBox.Text = "追撃";
            DoesDefenderFollowUpAttackCheckBox.UseVisualStyleBackColor = true;
            // 
            // DefenderCriticalRateNumericUpDown
            // 
            DefenderCriticalRateNumericUpDown.Location = new Point(183, 55);
            DefenderCriticalRateNumericUpDown.Name = "DefenderCriticalRateNumericUpDown";
            DefenderCriticalRateNumericUpDown.Size = new Size(42, 23);
            DefenderCriticalRateNumericUpDown.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(150, 58);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 29;
            label8.Text = "必殺";
            // 
            // DefenderHitRateNumericUpDown
            // 
            DefenderHitRateNumericUpDown.Location = new Point(102, 55);
            DefenderHitRateNumericUpDown.Name = "DefenderHitRateNumericUpDown";
            DefenderHitRateNumericUpDown.Size = new Size(42, 23);
            DefenderHitRateNumericUpDown.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(69, 58);
            label9.Name = "label9";
            label9.Size = new Size(31, 15);
            label9.TabIndex = 27;
            label9.Text = "命中";
            // 
            // AttackerCriticalRateNumericUpDown
            // 
            AttackerCriticalRateNumericUpDown.Location = new Point(183, 22);
            AttackerCriticalRateNumericUpDown.Name = "AttackerCriticalRateNumericUpDown";
            AttackerCriticalRateNumericUpDown.Size = new Size(42, 23);
            AttackerCriticalRateNumericUpDown.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(150, 25);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 25;
            label7.Text = "必殺";
            // 
            // AttackerHitRateNumericUpDown
            // 
            AttackerHitRateNumericUpDown.Location = new Point(102, 22);
            AttackerHitRateNumericUpDown.Name = "AttackerHitRateNumericUpDown";
            AttackerHitRateNumericUpDown.Size = new Size(42, 23);
            AttackerHitRateNumericUpDown.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(69, 25);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 23;
            label6.Text = "命中";
            // 
            // GrowthGroupBox
            // 
            GrowthGroupBox.Controls.Add(IsGrowthBoostedCheckBox);
            GrowthGroupBox.Controls.Add(checkBox9);
            GrowthGroupBox.Controls.Add(checkBox8);
            GrowthGroupBox.Controls.Add(checkBox7);
            GrowthGroupBox.Controls.Add(checkBox6);
            GrowthGroupBox.Controls.Add(checkBox5);
            GrowthGroupBox.Controls.Add(checkBox4);
            GrowthGroupBox.Controls.Add(checkBox3);
            GrowthGroupBox.Controls.Add(GrowthSpdRateNumericUpDown);
            GrowthGroupBox.Controls.Add(label16);
            GrowthGroupBox.Controls.Add(GrowthMdfRateNumericUpDown);
            GrowthGroupBox.Controls.Add(label13);
            GrowthGroupBox.Controls.Add(GrowthDefRateNumericUpDown);
            GrowthGroupBox.Controls.Add(label14);
            GrowthGroupBox.Controls.Add(GrowthLucRateNumericUpDown);
            GrowthGroupBox.Controls.Add(label15);
            GrowthGroupBox.Controls.Add(GrowthTecRateNumericUpDown);
            GrowthGroupBox.Controls.Add(label12);
            GrowthGroupBox.Controls.Add(GrowthAtkRateNumericUpDown);
            GrowthGroupBox.Controls.Add(label11);
            GrowthGroupBox.Controls.Add(GrowthHpRateNumericUpDown);
            GrowthGroupBox.Controls.Add(label10);
            GrowthGroupBox.Controls.Add(GrowthCharacterNameComboBox);
            GrowthGroupBox.Controls.Add(ContainsGrowthCheckBox);
            GrowthGroupBox.Location = new Point(11, 365);
            GrowthGroupBox.Name = "GrowthGroupBox";
            GrowthGroupBox.Size = new Size(620, 181);
            GrowthGroupBox.TabIndex = 30;
            GrowthGroupBox.TabStop = false;
            // 
            // IsGrowthBoostedCheckBox
            // 
            IsGrowthBoostedCheckBox.AutoSize = true;
            IsGrowthBoostedCheckBox.Location = new Point(156, 27);
            IsGrowthBoostedCheckBox.Name = "IsGrowthBoostedCheckBox";
            IsGrowthBoostedCheckBox.Size = new Size(90, 19);
            IsGrowthBoostedCheckBox.TabIndex = 2;
            IsGrowthBoostedCheckBox.Text = "アフア/メティス";
            IsGrowthBoostedCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Location = new Point(210, 118);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(15, 14);
            checkBox9.TabIndex = 26;
            checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Location = new Point(210, 90);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(15, 14);
            checkBox8.TabIndex = 25;
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(210, 62);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(15, 14);
            checkBox7.TabIndex = 24;
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(93, 146);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(15, 14);
            checkBox6.TabIndex = 23;
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(93, 118);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(15, 14);
            checkBox5.TabIndex = 22;
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(93, 90);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(15, 14);
            checkBox4.TabIndex = 21;
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(93, 62);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(15, 14);
            checkBox3.TabIndex = 20;
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // GrowthSpdRateNumericUpDown
            // 
            GrowthSpdRateNumericUpDown.Location = new Point(45, 142);
            GrowthSpdRateNumericUpDown.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            GrowthSpdRateNumericUpDown.Name = "GrowthSpdRateNumericUpDown";
            GrowthSpdRateNumericUpDown.Size = new Size(42, 23);
            GrowthSpdRateNumericUpDown.TabIndex = 13;
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
            // GrowthMdfRateNumericUpDown
            // 
            GrowthMdfRateNumericUpDown.Location = new Point(161, 114);
            GrowthMdfRateNumericUpDown.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            GrowthMdfRateNumericUpDown.Name = "GrowthMdfRateNumericUpDown";
            GrowthMdfRateNumericUpDown.Size = new Size(42, 23);
            GrowthMdfRateNumericUpDown.TabIndex = 16;
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
            // GrowthDefRateNumericUpDown
            // 
            GrowthDefRateNumericUpDown.Location = new Point(161, 86);
            GrowthDefRateNumericUpDown.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            GrowthDefRateNumericUpDown.Name = "GrowthDefRateNumericUpDown";
            GrowthDefRateNumericUpDown.Size = new Size(42, 23);
            GrowthDefRateNumericUpDown.TabIndex = 15;
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
            // GrowthLucRateNumericUpDown
            // 
            GrowthLucRateNumericUpDown.Location = new Point(161, 58);
            GrowthLucRateNumericUpDown.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            GrowthLucRateNumericUpDown.Name = "GrowthLucRateNumericUpDown";
            GrowthLucRateNumericUpDown.Size = new Size(42, 23);
            GrowthLucRateNumericUpDown.TabIndex = 14;
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
            // GrowthTecRateNumericUpDown
            // 
            GrowthTecRateNumericUpDown.Location = new Point(45, 114);
            GrowthTecRateNumericUpDown.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            GrowthTecRateNumericUpDown.Name = "GrowthTecRateNumericUpDown";
            GrowthTecRateNumericUpDown.Size = new Size(42, 23);
            GrowthTecRateNumericUpDown.TabIndex = 12;
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
            // GrowthAtkRateNumericUpDown
            // 
            GrowthAtkRateNumericUpDown.Location = new Point(45, 86);
            GrowthAtkRateNumericUpDown.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            GrowthAtkRateNumericUpDown.Name = "GrowthAtkRateNumericUpDown";
            GrowthAtkRateNumericUpDown.Size = new Size(42, 23);
            GrowthAtkRateNumericUpDown.TabIndex = 11;
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
            // GrowthHpRateNumericUpDown
            // 
            GrowthHpRateNumericUpDown.Location = new Point(45, 58);
            GrowthHpRateNumericUpDown.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            GrowthHpRateNumericUpDown.Name = "GrowthHpRateNumericUpDown";
            GrowthHpRateNumericUpDown.Size = new Size(42, 23);
            GrowthHpRateNumericUpDown.TabIndex = 10;
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
            // GrowthCharacterNameComboBox
            // 
            GrowthCharacterNameComboBox.FormattingEnabled = true;
            GrowthCharacterNameComboBox.Location = new Point(16, 25);
            GrowthCharacterNameComboBox.Name = "GrowthCharacterNameComboBox";
            GrowthCharacterNameComboBox.Size = new Size(134, 23);
            GrowthCharacterNameComboBox.TabIndex = 1;
            // 
            // ContainsGrowthCheckBox
            // 
            ContainsGrowthCheckBox.AutoSize = true;
            ContainsGrowthCheckBox.Location = new Point(6, 0);
            ContainsGrowthCheckBox.Name = "ContainsGrowthCheckBox";
            ContainsGrowthCheckBox.Size = new Size(81, 19);
            ContainsGrowthCheckBox.TabIndex = 0;
            ContainsGrowthCheckBox.Text = "レベルアップ";
            ContainsGrowthCheckBox.UseVisualStyleBackColor = true;
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
            FalconKnightMethodGroupBox.TabIndex = 11;
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
            UsesFalconKnightMethodCheckBox.CheckedChanged += UsesFalconKnightMethodCheckBox_CheckedChanged;
            // 
            // MainFormUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(FalconKnightMethodGroupBox);
            Controls.Add(GrowthGroupBox);
            Controls.Add(CombatGroupBox);
            Controls.Add(DefaultSeedButton);
            Controls.Add(Seed2TextBox);
            Controls.Add(Seed1TextBox);
            Controls.Add(Seed0TextBox);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(OffsetMaxTextBox);
            Controls.Add(OffsetMinTextBox);
            Controls.Add(label1);
            Name = "MainFormUserControl";
            Size = new Size(640, 590);
            CombatGroupBox.ResumeLayout(false);
            CombatGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DefenderCriticalRateNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)DefenderHitRateNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AttackerCriticalRateNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AttackerHitRateNumericUpDown).EndInit();
            GrowthGroupBox.ResumeLayout(false);
            GrowthGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GrowthSpdRateNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)GrowthMdfRateNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)GrowthDefRateNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)GrowthLucRateNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)GrowthTecRateNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)GrowthAtkRateNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)GrowthHpRateNumericUpDown).EndInit();
            FalconKnightMethodGroupBox.ResumeLayout(false);
            FalconKnightMethodGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DefaultSeedButton;
        private TextBox Seed2TextBox;
        private TextBox Seed1TextBox;
        private TextBox Seed0TextBox;
        private Label label5;
        private Label label2;
        private TextBox OffsetMaxTextBox;
        private TextBox OffsetMinTextBox;
        private Label label1;
        private CheckBox ContainsCombatCheckBox;
        private GroupBox CombatGroupBox;
        private GroupBox GrowthGroupBox;
        private CheckBox ContainsGrowthCheckBox;
        private CheckBox DoesDefenderAttackCheckBox;
        private CheckBox DoesDefenderFollowUpAttackCheckBox;
        private NumericUpDown DefenderCriticalRateNumericUpDown;
        private Label label8;
        private NumericUpDown DefenderHitRateNumericUpDown;
        private Label label9;
        private NumericUpDown AttackerCriticalRateNumericUpDown;
        private Label label7;
        private NumericUpDown AttackerHitRateNumericUpDown;
        private Label label6;
        private ComboBox GrowthCharacterNameComboBox;
        private CheckBox checkBox9;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private NumericUpDown GrowthSpdRateNumericUpDown;
        private Label label16;
        private NumericUpDown GrowthMdfRateNumericUpDown;
        private Label label13;
        private NumericUpDown GrowthDefRateNumericUpDown;
        private Label label14;
        private NumericUpDown GrowthLucRateNumericUpDown;
        private Label label15;
        private NumericUpDown GrowthTecRateNumericUpDown;
        private Label label12;
        private NumericUpDown GrowthAtkRateNumericUpDown;
        private Label label11;
        private NumericUpDown GrowthHpRateNumericUpDown;
        private Label label10;
        private GroupBox FalconKnightMethodGroupBox;
        private CheckBox checkBox10;
        private CheckBox checkBox11;
        private TextBox textBox13;
        private Label label18;
        private TextBox textBox14;
        private Label label19;
        private TextBox textBox15;
        private Label label20;
        private CheckBox UsesFalconKnightMethodCheckBox;
        private Label label17;
        private TextBox CxStringTextBox;
        private CheckBox AddsCxOffset;
        private Button FalconKnightToolOpenButton;
        private CheckBox IsGrowthBoostedCheckBox;
        private CheckBox IsDefenderDoubleAttackCheckBox;
        private CheckBox IsAttackerDoubleAttackCheckBox;
        private CheckBox DoesAttackerFollowUpAttackCheckBox;
        private Label label4;
        private Label label3;
    }
}
