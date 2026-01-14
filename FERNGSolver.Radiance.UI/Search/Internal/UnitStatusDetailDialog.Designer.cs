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
            IsWeaponTypeAbsorbRadioButton = new RadioButton();
            IsWeaponTypePoisonRadioButton = new RadioButton();
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
            label5 = new Label();
            OpponentAttackSpeedNumericUpDown = new NumericUpDownEx();
            label3 = new Label();
            AttackSpeedNumericUpDown = new NumericUpDownEx();
            OkButton = new Button();
            label7 = new Label();
            OpponentMdfNumericUpDown = new NumericUpDownEx();
            ((System.ComponentModel.ISupportInitialize)LevelNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxHpNumericUpDown).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TecNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OpponentAttackSpeedNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AttackSpeedNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OpponentMdfNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 253);
            label1.Name = "label1";
            label1.Size = new Size(22, 15);
            label1.TabIndex = 120;
            label1.Text = "Lv:";
            // 
            // LevelNumericUpDown
            // 
            LevelNumericUpDown.Location = new Point(40, 251);
            LevelNumericUpDown.Name = "LevelNumericUpDown";
            LevelNumericUpDown.Size = new Size(42, 23);
            LevelNumericUpDown.TabIndex = 4;
            LevelNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 253);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 122;
            label2.Text = "最大HP:";
            // 
            // MaxHpNumericUpDown
            // 
            MaxHpNumericUpDown.Enabled = false;
            MaxHpNumericUpDown.Location = new Point(156, 251);
            MaxHpNumericUpDown.Name = "MaxHpNumericUpDown";
            MaxHpNumericUpDown.Size = new Size(42, 23);
            MaxHpNumericUpDown.TabIndex = 5;
            MaxHpNumericUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // IsWeaponTypeNormalRadioButton
            // 
            IsWeaponTypeNormalRadioButton.AutoSize = true;
            IsWeaponTypeNormalRadioButton.Location = new Point(15, 25);
            IsWeaponTypeNormalRadioButton.Name = "IsWeaponTypeNormalRadioButton";
            IsWeaponTypeNormalRadioButton.Size = new Size(73, 19);
            IsWeaponTypeNormalRadioButton.TabIndex = 1;
            IsWeaponTypeNormalRadioButton.TabStop = true;
            IsWeaponTypeNormalRadioButton.Text = "通常武器";
            IsWeaponTypeNormalRadioButton.UseVisualStyleBackColor = true;
            IsWeaponTypeNormalRadioButton.CheckedChanged += RadioButtonControlStateChenged;
            // 
            // IsWeaponTypeBraveRadioButton
            // 
            IsWeaponTypeBraveRadioButton.AutoSize = true;
            IsWeaponTypeBraveRadioButton.Location = new Point(15, 50);
            IsWeaponTypeBraveRadioButton.Name = "IsWeaponTypeBraveRadioButton";
            IsWeaponTypeBraveRadioButton.Size = new Size(49, 19);
            IsWeaponTypeBraveRadioButton.TabIndex = 2;
            IsWeaponTypeBraveRadioButton.TabStop = true;
            IsWeaponTypeBraveRadioButton.Text = "勇者";
            IsWeaponTypeBraveRadioButton.UseVisualStyleBackColor = true;
            IsWeaponTypeBraveRadioButton.CheckedChanged += RadioButtonControlStateChenged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(IsWeaponTypeAbsorbRadioButton);
            groupBox1.Controls.Add(IsWeaponTypePoisonRadioButton);
            groupBox1.Controls.Add(IsWeaponTypeNormalRadioButton);
            groupBox1.Controls.Add(IsWeaponTypeBraveRadioButton);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(132, 138);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "武器";
            // 
            // IsWeaponTypeAbsorbRadioButton
            // 
            IsWeaponTypeAbsorbRadioButton.AutoSize = true;
            IsWeaponTypeAbsorbRadioButton.Location = new Point(15, 75);
            IsWeaponTypeAbsorbRadioButton.Name = "IsWeaponTypeAbsorbRadioButton";
            IsWeaponTypeAbsorbRadioButton.Size = new Size(49, 19);
            IsWeaponTypeAbsorbRadioButton.TabIndex = 3;
            IsWeaponTypeAbsorbRadioButton.TabStop = true;
            IsWeaponTypeAbsorbRadioButton.Text = "吸収";
            IsWeaponTypeAbsorbRadioButton.UseVisualStyleBackColor = true;
            IsWeaponTypeAbsorbRadioButton.CheckedChanged += RadioButtonControlStateChenged;
            // 
            // IsWeaponTypePoisonRadioButton
            // 
            IsWeaponTypePoisonRadioButton.AutoSize = true;
            IsWeaponTypePoisonRadioButton.Location = new Point(15, 100);
            IsWeaponTypePoisonRadioButton.Name = "IsWeaponTypePoisonRadioButton";
            IsWeaponTypePoisonRadioButton.Size = new Size(73, 19);
            IsWeaponTypePoisonRadioButton.TabIndex = 4;
            IsWeaponTypePoisonRadioButton.TabStop = true;
            IsWeaponTypePoisonRadioButton.Text = "状態異常";
            IsWeaponTypePoisonRadioButton.UseVisualStyleBackColor = true;
            IsWeaponTypePoisonRadioButton.CheckedChanged += RadioButtonControlStateChenged;
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
            groupBox2.Size = new Size(352, 204);
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
            label4.Location = new Point(216, 253);
            label4.Name = "label4";
            label4.Size = new Size(22, 15);
            label4.TabIndex = 141;
            label4.Text = "技:";
            // 
            // TecNumericUpDown
            // 
            TecNumericUpDown.Location = new Point(244, 251);
            TecNumericUpDown.Name = "TecNumericUpDown";
            TecNumericUpDown.Size = new Size(42, 23);
            TecNumericUpDown.TabIndex = 6;
            TecNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(404, 253);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 138;
            label5.Text = "敵の攻速:";
            // 
            // OpponentAttackSpeedNumericUpDown
            // 
            OpponentAttackSpeedNumericUpDown.Location = new Point(466, 251);
            OpponentAttackSpeedNumericUpDown.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            OpponentAttackSpeedNumericUpDown.Name = "OpponentAttackSpeedNumericUpDown";
            OpponentAttackSpeedNumericUpDown.Size = new Size(42, 23);
            OpponentAttackSpeedNumericUpDown.TabIndex = 8;
            OpponentAttackSpeedNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(304, 253);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 135;
            label3.Text = "攻速:";
            // 
            // AttackSpeedNumericUpDown
            // 
            AttackSpeedNumericUpDown.BackColor = SystemColors.Window;
            AttackSpeedNumericUpDown.Location = new Point(344, 251);
            AttackSpeedNumericUpDown.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            AttackSpeedNumericUpDown.Name = "AttackSpeedNumericUpDown";
            AttackSpeedNumericUpDown.Size = new Size(42, 23);
            AttackSpeedNumericUpDown.TabIndex = 7;
            AttackSpeedNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // OkButton
            // 
            OkButton.Location = new Point(277, 294);
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
            label7.Location = new Point(526, 253);
            label7.Name = "label7";
            label7.Size = new Size(56, 15);
            label7.TabIndex = 143;
            label7.Text = "敵の魔防:";
            // 
            // OpponentMdfNumericUpDown
            // 
            OpponentMdfNumericUpDown.Location = new Point(588, 251);
            OpponentMdfNumericUpDown.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            OpponentMdfNumericUpDown.Name = "OpponentMdfNumericUpDown";
            OpponentMdfNumericUpDown.Size = new Size(42, 23);
            OpponentMdfNumericUpDown.TabIndex = 9;
            OpponentMdfNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // UnitStatusDetailDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 380);
            Controls.Add(label7);
            Controls.Add(OpponentMdfNumericUpDown);
            Controls.Add(label2);
            Controls.Add(MaxHpNumericUpDown);
            Controls.Add(OkButton);
            Controls.Add(groupBox2);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(OpponentAttackSpeedNumericUpDown);
            Controls.Add(TecNumericUpDown);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(AttackSpeedNumericUpDown);
            Controls.Add(LevelNumericUpDown);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "UnitStatusDetailDialog";
            Text = "詳細設定";
            ((System.ComponentModel.ISupportInitialize)LevelNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxHpNumericUpDown).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TecNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)OpponentAttackSpeedNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AttackSpeedNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)OpponentMdfNumericUpDown).EndInit();
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
        private RadioButton IsWeaponTypePoisonRadioButton;
        private GroupBox groupBox2;
        private RadioButton IsWeaponTypeAbsorbRadioButton;
        private Button OkButton;
        private CheckBox HasVantageCheckBox;
        private Label label5;
        private NumericUpDownEx OpponentAttackSpeedNumericUpDown;
        private CheckBox HasAssaultCheckBox;
        private Label label3;
        private NumericUpDownEx AttackSpeedNumericUpDown;
        private CheckBox HasAdeptCheckBox;
        private CheckBox HasSolCheckBox;
        private CheckBox HasLunaCheckBox;
        private CheckBox HasAstraCheckBox;
        private Label label4;
        private NumericUpDownEx TecNumericUpDown;
        private CheckBox HasMiracleCheckBox;
        private CheckBox HasWrathCheckBox;
        private Label label7;
        private NumericUpDownEx OpponentMdfNumericUpDown;
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
    }
}
