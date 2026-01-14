using FERNGSolver.Common.UI.Controls;

namespace FERNGSolver.Radiance.UI.Search.Internal
{
    partial class UnitStatusDetailDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            LevelNumericUpDown = new NumericUpDownEx();
            label2 = new Label();
            MaxHpNumericUpDown = new NumericUpDownEx();
            IsWeaponTypeNormalRadioButton = new RadioButton();
            IsWeaponTypeBraveRadioButton = new RadioButton();
            groupBox1 = new GroupBox();
            label6 = new Label();
            WeaponUsesNumericUpDown = new NumericUpDownEx();
            IsWeaponTypeMagicSwordRadioButton = new RadioButton();
            IsWeaponTypeAbsorbRadioButton = new RadioButton();
            groupBox2 = new GroupBox();
            HasCancelCheckBox = new CheckBox();
            HasLethalityCheckBox = new CheckBox();
            HasDeadeyeCheckBox = new CheckBox();
            HasColossusCheckBox = new CheckBox();
            HasStunCheckBox = new CheckBox();
            HasFlareCheckBox = new CheckBox();
            HasCounterCheckBox = new CheckBox();
            HasGuardCheckBox = new CheckBox();
            HasCorrodeCheckBox = new CheckBox();
            HasAetherCheckBox = new CheckBox();
            HasResolveCheckBox = new CheckBox();
            HasMiracleCheckBox = new CheckBox();
            HasWrathCheckBox = new CheckBox();
            HasSolCheckBox = new CheckBox();
            HasLunaCheckBox = new CheckBox();
            HasAstraCheckBox = new CheckBox();
            HasAdeptCheckBox = new CheckBox();
            HasVantageCheckBox = new CheckBox();
            label4 = new Label();
            TecNumericUpDown = new NumericUpDownEx();
            label3 = new Label();
            LuckNumericUpDown = new NumericUpDownEx();
            OkButton = new Button();
            label7 = new Label();
            OpponentDefNumericUpDown = new NumericUpDownEx();
            label5 = new Label();
            StrNumericUpDown = new NumericUpDownEx();
            groupBox3 = new GroupBox();
            IsBossTypeFinalBossRadioButton = new RadioButton();
            IsBossTypeNoneRadioButton = new RadioButton();
            IsBossTypeBossRadioButton = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)LevelNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxHpNumericUpDown).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WeaponUsesNumericUpDown).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TecNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LuckNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OpponentDefNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StrNumericUpDown).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 209);
            label1.Name = "label1";
            label1.Size = new Size(22, 15);
            label1.TabIndex = 120;
            label1.Text = "Lv:";
            // 
            // LevelNumericUpDown
            // 
            LevelNumericUpDown.Location = new Point(40, 207);
            LevelNumericUpDown.Name = "LevelNumericUpDown";
            LevelNumericUpDown.Size = new Size(42, 23);
            LevelNumericUpDown.TabIndex = 4;
            LevelNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 209);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 122;
            label2.Text = "最大HP:";
            // 
            // MaxHpNumericUpDown
            // 
            MaxHpNumericUpDown.Enabled = false;
            MaxHpNumericUpDown.Location = new Point(149, 207);
            MaxHpNumericUpDown.Name = "MaxHpNumericUpDown";
            MaxHpNumericUpDown.Size = new Size(42, 23);
            MaxHpNumericUpDown.TabIndex = 5;
            MaxHpNumericUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // IsWeaponTypeNormalRadioButton
            // 
            IsWeaponTypeNormalRadioButton.AutoSize = true;
            IsWeaponTypeNormalRadioButton.Location = new Point(15, 66);
            IsWeaponTypeNormalRadioButton.Name = "IsWeaponTypeNormalRadioButton";
            IsWeaponTypeNormalRadioButton.Size = new Size(73, 19);
            IsWeaponTypeNormalRadioButton.TabIndex = 2;
            IsWeaponTypeNormalRadioButton.TabStop = true;
            IsWeaponTypeNormalRadioButton.Text = "通常武器";
            IsWeaponTypeNormalRadioButton.UseVisualStyleBackColor = true;
            IsWeaponTypeNormalRadioButton.CheckedChanged += RadioButtonControlStateChenged;
            // 
            // IsWeaponTypeBraveRadioButton
            // 
            IsWeaponTypeBraveRadioButton.AutoSize = true;
            IsWeaponTypeBraveRadioButton.Location = new Point(15, 91);
            IsWeaponTypeBraveRadioButton.Name = "IsWeaponTypeBraveRadioButton";
            IsWeaponTypeBraveRadioButton.Size = new Size(49, 19);
            IsWeaponTypeBraveRadioButton.TabIndex = 3;
            IsWeaponTypeBraveRadioButton.TabStop = true;
            IsWeaponTypeBraveRadioButton.Text = "勇者";
            IsWeaponTypeBraveRadioButton.UseVisualStyleBackColor = true;
            IsWeaponTypeBraveRadioButton.CheckedChanged += RadioButtonControlStateChenged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(WeaponUsesNumericUpDown);
            groupBox1.Controls.Add(IsWeaponTypeMagicSwordRadioButton);
            groupBox1.Controls.Add(IsWeaponTypeAbsorbRadioButton);
            groupBox1.Controls.Add(IsWeaponTypeNormalRadioButton);
            groupBox1.Controls.Add(IsWeaponTypeBraveRadioButton);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(132, 183);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "武器";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 30);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 122;
            label6.Text = "残り回数:";
            // 
            // WeaponUsesNumericUpDown
            // 
            WeaponUsesNumericUpDown.Location = new Point(75, 28);
            WeaponUsesNumericUpDown.Name = "WeaponUsesNumericUpDown";
            WeaponUsesNumericUpDown.Size = new Size(42, 23);
            WeaponUsesNumericUpDown.TabIndex = 1;
            WeaponUsesNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // IsWeaponTypeMagicSwordRadioButton
            // 
            IsWeaponTypeMagicSwordRadioButton.AutoSize = true;
            IsWeaponTypeMagicSwordRadioButton.Location = new Point(15, 116);
            IsWeaponTypeMagicSwordRadioButton.Name = "IsWeaponTypeMagicSwordRadioButton";
            IsWeaponTypeMagicSwordRadioButton.Size = new Size(95, 19);
            IsWeaponTypeMagicSwordRadioButton.TabIndex = 4;
            IsWeaponTypeMagicSwordRadioButton.TabStop = true;
            IsWeaponTypeMagicSwordRadioButton.Text = "剣の間接攻撃";
            IsWeaponTypeMagicSwordRadioButton.UseVisualStyleBackColor = true;
            IsWeaponTypeMagicSwordRadioButton.CheckedChanged += RadioButtonControlStateChenged;
            // 
            // IsWeaponTypeAbsorbRadioButton
            // 
            IsWeaponTypeAbsorbRadioButton.AutoSize = true;
            IsWeaponTypeAbsorbRadioButton.Location = new Point(15, 141);
            IsWeaponTypeAbsorbRadioButton.Name = "IsWeaponTypeAbsorbRadioButton";
            IsWeaponTypeAbsorbRadioButton.Size = new Size(49, 19);
            IsWeaponTypeAbsorbRadioButton.TabIndex = 5;
            IsWeaponTypeAbsorbRadioButton.TabStop = true;
            IsWeaponTypeAbsorbRadioButton.Text = "吸収";
            IsWeaponTypeAbsorbRadioButton.UseVisualStyleBackColor = true;
            IsWeaponTypeAbsorbRadioButton.CheckedChanged += RadioButtonControlStateChenged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(HasCancelCheckBox);
            groupBox2.Controls.Add(HasLethalityCheckBox);
            groupBox2.Controls.Add(HasDeadeyeCheckBox);
            groupBox2.Controls.Add(HasColossusCheckBox);
            groupBox2.Controls.Add(HasStunCheckBox);
            groupBox2.Controls.Add(HasFlareCheckBox);
            groupBox2.Controls.Add(HasCounterCheckBox);
            groupBox2.Controls.Add(HasGuardCheckBox);
            groupBox2.Controls.Add(HasCorrodeCheckBox);
            groupBox2.Controls.Add(HasAetherCheckBox);
            groupBox2.Controls.Add(HasResolveCheckBox);
            groupBox2.Controls.Add(HasMiracleCheckBox);
            groupBox2.Controls.Add(HasWrathCheckBox);
            groupBox2.Controls.Add(HasSolCheckBox);
            groupBox2.Controls.Add(HasLunaCheckBox);
            groupBox2.Controls.Add(HasAstraCheckBox);
            groupBox2.Controls.Add(HasAdeptCheckBox);
            groupBox2.Controls.Add(HasVantageCheckBox);
            groupBox2.Location = new Point(156, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(352, 183);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "スキル";
            // 
            // HasCancelCheckBox
            // 
            HasCancelCheckBox.AutoSize = true;
            HasCancelCheckBox.Location = new Point(255, 76);
            HasCancelCheckBox.Name = "HasCancelCheckBox";
            HasCancelCheckBox.Size = new Size(72, 19);
            HasCancelCheckBox.TabIndex = 18;
            HasCancelCheckBox.Text = "翼の守護";
            HasCancelCheckBox.UseVisualStyleBackColor = true;
            HasCancelCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasLethalityCheckBox
            // 
            HasLethalityCheckBox.AutoSize = true;
            HasLethalityCheckBox.Location = new Point(180, 101);
            HasLethalityCheckBox.Name = "HasLethalityCheckBox";
            HasLethalityCheckBox.Size = new Size(50, 19);
            HasLethalityCheckBox.TabIndex = 15;
            HasLethalityCheckBox.Text = "瞬殺";
            HasLethalityCheckBox.UseVisualStyleBackColor = true;
            HasLethalityCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasDeadeyeCheckBox
            // 
            HasDeadeyeCheckBox.AutoSize = true;
            HasDeadeyeCheckBox.Location = new Point(180, 76);
            HasDeadeyeCheckBox.Name = "HasDeadeyeCheckBox";
            HasDeadeyeCheckBox.Size = new Size(50, 19);
            HasDeadeyeCheckBox.TabIndex = 14;
            HasDeadeyeCheckBox.Text = "狙撃";
            HasDeadeyeCheckBox.UseVisualStyleBackColor = true;
            HasDeadeyeCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasColossusCheckBox
            // 
            HasColossusCheckBox.AutoSize = true;
            HasColossusCheckBox.Location = new Point(180, 51);
            HasColossusCheckBox.Name = "HasColossusCheckBox";
            HasColossusCheckBox.Size = new Size(50, 19);
            HasColossusCheckBox.TabIndex = 13;
            HasColossusCheckBox.Text = "鳴動";
            HasColossusCheckBox.UseVisualStyleBackColor = true;
            HasColossusCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasStunCheckBox
            // 
            HasStunCheckBox.AutoSize = true;
            HasStunCheckBox.Location = new Point(180, 26);
            HasStunCheckBox.Name = "HasStunCheckBox";
            HasStunCheckBox.Size = new Size(50, 19);
            HasStunCheckBox.TabIndex = 12;
            HasStunCheckBox.Text = "衝撃";
            HasStunCheckBox.UseVisualStyleBackColor = true;
            HasStunCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasFlareCheckBox
            // 
            HasFlareCheckBox.AutoSize = true;
            HasFlareCheckBox.Location = new Point(105, 126);
            HasFlareCheckBox.Name = "HasFlareCheckBox";
            HasFlareCheckBox.Size = new Size(50, 19);
            HasFlareCheckBox.TabIndex = 11;
            HasFlareCheckBox.Text = "陽光";
            HasFlareCheckBox.UseVisualStyleBackColor = true;
            HasFlareCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasCounterCheckBox
            // 
            HasCounterCheckBox.AutoSize = true;
            HasCounterCheckBox.Location = new Point(15, 151);
            HasCounterCheckBox.Name = "HasCounterCheckBox";
            HasCounterCheckBox.Size = new Size(70, 19);
            HasCounterCheckBox.TabIndex = 6;
            HasCounterCheckBox.Text = "カウンター";
            HasCounterCheckBox.UseVisualStyleBackColor = true;
            HasCounterCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasGuardCheckBox
            // 
            HasGuardCheckBox.AutoSize = true;
            HasGuardCheckBox.Location = new Point(255, 26);
            HasGuardCheckBox.Name = "HasGuardCheckBox";
            HasGuardCheckBox.Size = new Size(72, 19);
            HasGuardCheckBox.TabIndex = 16;
            HasGuardCheckBox.Text = "キャンセル";
            HasGuardCheckBox.UseVisualStyleBackColor = true;
            HasGuardCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasCorrodeCheckBox
            // 
            HasCorrodeCheckBox.AutoSize = true;
            HasCorrodeCheckBox.Location = new Point(255, 51);
            HasCorrodeCheckBox.Name = "HasCorrodeCheckBox";
            HasCorrodeCheckBox.Size = new Size(74, 19);
            HasCorrodeCheckBox.TabIndex = 17;
            HasCorrodeCheckBox.Text = "武器破壊";
            HasCorrodeCheckBox.UseVisualStyleBackColor = true;
            HasCorrodeCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasAetherCheckBox
            // 
            HasAetherCheckBox.AutoSize = true;
            HasAetherCheckBox.Location = new Point(105, 26);
            HasAetherCheckBox.Name = "HasAetherCheckBox";
            HasAetherCheckBox.Size = new Size(50, 19);
            HasAetherCheckBox.TabIndex = 7;
            HasAetherCheckBox.Text = "天空";
            HasAetherCheckBox.UseVisualStyleBackColor = true;
            HasAetherCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasResolveCheckBox
            // 
            HasResolveCheckBox.AutoSize = true;
            HasResolveCheckBox.Location = new Point(15, 101);
            HasResolveCheckBox.Name = "HasResolveCheckBox";
            HasResolveCheckBox.Size = new Size(50, 19);
            HasResolveCheckBox.TabIndex = 4;
            HasResolveCheckBox.Text = "勇将";
            HasResolveCheckBox.UseVisualStyleBackColor = true;
            HasResolveCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasMiracleCheckBox
            // 
            HasMiracleCheckBox.AutoSize = true;
            HasMiracleCheckBox.Location = new Point(15, 126);
            HasMiracleCheckBox.Name = "HasMiracleCheckBox";
            HasMiracleCheckBox.Size = new Size(46, 19);
            HasMiracleCheckBox.TabIndex = 5;
            HasMiracleCheckBox.Text = "祈り";
            HasMiracleCheckBox.UseVisualStyleBackColor = true;
            HasMiracleCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasWrathCheckBox
            // 
            HasWrathCheckBox.AutoSize = true;
            HasWrathCheckBox.Location = new Point(15, 76);
            HasWrathCheckBox.Name = "HasWrathCheckBox";
            HasWrathCheckBox.Size = new Size(46, 19);
            HasWrathCheckBox.TabIndex = 3;
            HasWrathCheckBox.Text = "怒り";
            HasWrathCheckBox.UseVisualStyleBackColor = true;
            HasWrathCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasSolCheckBox
            // 
            HasSolCheckBox.AutoSize = true;
            HasSolCheckBox.Location = new Point(105, 101);
            HasSolCheckBox.Name = "HasSolCheckBox";
            HasSolCheckBox.Size = new Size(50, 19);
            HasSolCheckBox.TabIndex = 10;
            HasSolCheckBox.Text = "太陽";
            HasSolCheckBox.UseVisualStyleBackColor = true;
            HasSolCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasLunaCheckBox
            // 
            HasLunaCheckBox.AutoSize = true;
            HasLunaCheckBox.Location = new Point(105, 76);
            HasLunaCheckBox.Name = "HasLunaCheckBox";
            HasLunaCheckBox.Size = new Size(50, 19);
            HasLunaCheckBox.TabIndex = 9;
            HasLunaCheckBox.Text = "月光";
            HasLunaCheckBox.UseVisualStyleBackColor = true;
            HasLunaCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasAstraCheckBox
            // 
            HasAstraCheckBox.AutoSize = true;
            HasAstraCheckBox.Location = new Point(105, 51);
            HasAstraCheckBox.Name = "HasAstraCheckBox";
            HasAstraCheckBox.Size = new Size(50, 19);
            HasAstraCheckBox.TabIndex = 8;
            HasAstraCheckBox.Text = "流星";
            HasAstraCheckBox.UseVisualStyleBackColor = true;
            HasAstraCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasAdeptCheckBox
            // 
            HasAdeptCheckBox.AutoSize = true;
            HasAdeptCheckBox.Location = new Point(15, 51);
            HasAdeptCheckBox.Name = "HasAdeptCheckBox";
            HasAdeptCheckBox.Size = new Size(50, 19);
            HasAdeptCheckBox.TabIndex = 2;
            HasAdeptCheckBox.Text = "連続";
            HasAdeptCheckBox.UseVisualStyleBackColor = true;
            HasAdeptCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // HasVantageCheckBox
            // 
            HasVantageCheckBox.AutoSize = true;
            HasVantageCheckBox.Location = new Point(15, 26);
            HasVantageCheckBox.Name = "HasVantageCheckBox";
            HasVantageCheckBox.Size = new Size(69, 19);
            HasVantageCheckBox.TabIndex = 1;
            HasVantageCheckBox.Text = "待ち伏せ";
            HasVantageCheckBox.UseVisualStyleBackColor = true;
            HasVantageCheckBox.CheckedChanged += ParameterControlStateChenged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(282, 209);
            label4.Name = "label4";
            label4.Size = new Size(22, 15);
            label4.TabIndex = 141;
            label4.Text = "技:";
            // 
            // TecNumericUpDown
            // 
            TecNumericUpDown.Location = new Point(310, 207);
            TecNumericUpDown.Name = "TecNumericUpDown";
            TecNumericUpDown.Size = new Size(42, 23);
            TecNumericUpDown.TabIndex = 7;
            TecNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(362, 209);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 135;
            label3.Text = "幸運:";
            // 
            // LuckNumericUpDown
            // 
            LuckNumericUpDown.BackColor = SystemColors.Window;
            LuckNumericUpDown.Location = new Point(402, 207);
            LuckNumericUpDown.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            LuckNumericUpDown.Name = "LuckNumericUpDown";
            LuckNumericUpDown.Size = new Size(42, 23);
            LuckNumericUpDown.TabIndex = 8;
            LuckNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // OkButton
            // 
            OkButton.Location = new Point(301, 248);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(92, 31);
            OkButton.TabIndex = 129;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(456, 209);
            label7.Name = "label7";
            label7.Size = new Size(85, 15);
            label7.TabIndex = 143;
            label7.Text = "敵の守備/魔防:";
            // 
            // OpponentDefNumericUpDown
            // 
            OpponentDefNumericUpDown.Location = new Point(547, 207);
            OpponentDefNumericUpDown.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            OpponentDefNumericUpDown.Name = "OpponentDefNumericUpDown";
            OpponentDefNumericUpDown.Size = new Size(42, 23);
            OpponentDefNumericUpDown.TabIndex = 9;
            OpponentDefNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(202, 209);
            label5.Name = "label5";
            label5.Size = new Size(22, 15);
            label5.TabIndex = 145;
            label5.Text = "力:";
            // 
            // StrNumericUpDown
            // 
            StrNumericUpDown.Location = new Point(230, 207);
            StrNumericUpDown.Name = "StrNumericUpDown";
            StrNumericUpDown.Size = new Size(42, 23);
            StrNumericUpDown.TabIndex = 6;
            StrNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(IsBossTypeFinalBossRadioButton);
            groupBox3.Controls.Add(IsBossTypeNoneRadioButton);
            groupBox3.Controls.Add(IsBossTypeBossRadioButton);
            groupBox3.Location = new Point(514, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(167, 110);
            groupBox3.TabIndex = 146;
            groupBox3.TabStop = false;
            groupBox3.Text = "ボス属性";
            // 
            // IsBossTypeFinalBossRadioButton
            // 
            IsBossTypeFinalBossRadioButton.AutoSize = true;
            IsBossTypeFinalBossRadioButton.Location = new Point(18, 74);
            IsBossTypeFinalBossRadioButton.Name = "IsBossTypeFinalBossRadioButton";
            IsBossTypeFinalBossRadioButton.Size = new Size(140, 19);
            IsBossTypeFinalBossRadioButton.TabIndex = 125;
            IsBossTypeFinalBossRadioButton.TabStop = true;
            IsBossTypeFinalBossRadioButton.Text = "漆黒の騎士/アシュナード";
            IsBossTypeFinalBossRadioButton.UseVisualStyleBackColor = true;
            // 
            // IsBossTypeNoneRadioButton
            // 
            IsBossTypeNoneRadioButton.AutoSize = true;
            IsBossTypeNoneRadioButton.Location = new Point(18, 24);
            IsBossTypeNoneRadioButton.Name = "IsBossTypeNoneRadioButton";
            IsBossTypeNoneRadioButton.Size = new Size(43, 19);
            IsBossTypeNoneRadioButton.TabIndex = 123;
            IsBossTypeNoneRadioButton.TabStop = true;
            IsBossTypeNoneRadioButton.Text = "なし";
            IsBossTypeNoneRadioButton.UseVisualStyleBackColor = true;
            // 
            // IsBossTypeBossRadioButton
            // 
            IsBossTypeBossRadioButton.AutoSize = true;
            IsBossTypeBossRadioButton.Location = new Point(18, 49);
            IsBossTypeBossRadioButton.Name = "IsBossTypeBossRadioButton";
            IsBossTypeBossRadioButton.Size = new Size(44, 19);
            IsBossTypeBossRadioButton.TabIndex = 124;
            IsBossTypeBossRadioButton.TabStop = true;
            IsBossTypeBossRadioButton.Text = "ボス";
            IsBossTypeBossRadioButton.UseVisualStyleBackColor = true;
            // 
            // UnitStatusDetailDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 294);
            Controls.Add(groupBox3);
            Controls.Add(label5);
            Controls.Add(StrNumericUpDown);
            Controls.Add(label7);
            Controls.Add(OpponentDefNumericUpDown);
            Controls.Add(label2);
            Controls.Add(MaxHpNumericUpDown);
            Controls.Add(OkButton);
            Controls.Add(groupBox2);
            Controls.Add(label4);
            Controls.Add(TecNumericUpDown);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(LuckNumericUpDown);
            Controls.Add(LevelNumericUpDown);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "UnitStatusDetailDialog";
            Text = "詳細設定";
            ((System.ComponentModel.ISupportInitialize)LevelNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxHpNumericUpDown).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)WeaponUsesNumericUpDown).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TecNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)LuckNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)OpponentDefNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)StrNumericUpDown).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDownEx LevelNumericUpDown;
        private Label label2;
        private NumericUpDownEx MaxHpNumericUpDown;
        private RadioButton IsWeaponTypeNormalRadioButton;
        private RadioButton IsWeaponTypeBraveRadioButton;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RadioButton IsWeaponTypeAbsorbRadioButton;
        private Button OkButton;
        private CheckBox HasVantageCheckBox;
        private CheckBox HasAssaultCheckBox;
        private Label label3;
        private NumericUpDownEx LuckNumericUpDown;
        private CheckBox HasAdeptCheckBox;
        private CheckBox HasSolCheckBox;
        private CheckBox HasLunaCheckBox;
        private CheckBox HasAstraCheckBox;
        private Label label4;
        private NumericUpDownEx TecNumericUpDown;
        private CheckBox HasMiracleCheckBox;
        private CheckBox HasWrathCheckBox;
        private Label label7;
        private NumericUpDownEx OpponentDefNumericUpDown;
        private CheckBox HasResolveCheckBox;
        private CheckBox HasAetherCheckBox;
        private CheckBox HasCorrodeCheckBox;
        private CheckBox HasCancelCheckBox;
        private CheckBox HasLethalityCheckBox;
        private CheckBox HasDeadeyeCheckBox;
        private CheckBox HasColossusCheckBox;
        private CheckBox HasStunCheckBox;
        private CheckBox HasFlareCheckBox;
        private CheckBox HasCounterCheckBox;
        private CheckBox HasGuardCheckBox;
        private RadioButton IsWeaponTypeMagicSwordRadioButton;
        private Label label5;
        private NumericUpDownEx StrNumericUpDown;
        private Label label6;
        private NumericUpDownEx WeaponUsesNumericUpDown;
        private GroupBox groupBox3;
        private RadioButton IsBossTypeFinalBossRadioButton;
        private RadioButton IsBossTypeNoneRadioButton;
        private RadioButton IsBossTypeBossRadioButton;
    }
}
