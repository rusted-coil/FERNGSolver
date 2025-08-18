using FERNGSolver.Common.UI.Controls;

namespace FERNGSolver.Genealogy.UI.Search.Internal
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
            HasSolCheckBox = new CheckBox();
            HasLunaCheckBox = new CheckBox();
            HasAstraCheckBox = new CheckBox();
            label4 = new Label();
            TecNumericUpDown = new NumericUpDownEx();
            HasGreatShieldCheckBox = new CheckBox();
            label5 = new Label();
            OpponentAttackSpeedNumericUpDown = new NumericUpDownEx();
            HasAssaultCheckBox = new CheckBox();
            label3 = new Label();
            AttackSpeedNumericUpDown = new NumericUpDownEx();
            HasContinuationCheckBox = new CheckBox();
            HasVantageCheckBox = new CheckBox();
            OkButton = new Button();
            groupBox3 = new GroupBox();
            HasCriticalSkillCheckBox = new CheckBox();
            HasSupportCheckBox = new CheckBox();
            IsEffectiveCheckBox = new CheckBox();
            label6 = new Label();
            WeaponStarNumericUpDown = new NumericUpDownEx();
            ((System.ComponentModel.ISupportInitialize)LevelNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxHpNumericUpDown).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TecNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OpponentAttackSpeedNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AttackSpeedNumericUpDown).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WeaponStarNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(120, 102);
            label1.Name = "label1";
            label1.Size = new Size(22, 15);
            label1.TabIndex = 120;
            label1.Text = "Lv:";
            // 
            // LevelNumericUpDown
            // 
            LevelNumericUpDown.Location = new Point(148, 100);
            LevelNumericUpDown.Name = "LevelNumericUpDown";
            LevelNumericUpDown.Size = new Size(42, 23);
            LevelNumericUpDown.TabIndex = 119;
            LevelNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 77);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 122;
            label2.Text = "最大HP:";
            // 
            // MaxHpNumericUpDown
            // 
            MaxHpNumericUpDown.Enabled = false;
            MaxHpNumericUpDown.Location = new Point(149, 75);
            MaxHpNumericUpDown.Name = "MaxHpNumericUpDown";
            MaxHpNumericUpDown.Size = new Size(42, 23);
            MaxHpNumericUpDown.TabIndex = 121;
            MaxHpNumericUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // IsWeaponTypeNormalRadioButton
            // 
            IsWeaponTypeNormalRadioButton.AutoSize = true;
            IsWeaponTypeNormalRadioButton.Location = new Point(15, 25);
            IsWeaponTypeNormalRadioButton.Name = "IsWeaponTypeNormalRadioButton";
            IsWeaponTypeNormalRadioButton.Size = new Size(73, 19);
            IsWeaponTypeNormalRadioButton.TabIndex = 123;
            IsWeaponTypeNormalRadioButton.TabStop = true;
            IsWeaponTypeNormalRadioButton.Text = "通常武器";
            IsWeaponTypeNormalRadioButton.UseVisualStyleBackColor = true;
            // 
            // IsWeaponTypeBraveRadioButton
            // 
            IsWeaponTypeBraveRadioButton.AutoSize = true;
            IsWeaponTypeBraveRadioButton.Location = new Point(15, 50);
            IsWeaponTypeBraveRadioButton.Name = "IsWeaponTypeBraveRadioButton";
            IsWeaponTypeBraveRadioButton.Size = new Size(49, 19);
            IsWeaponTypeBraveRadioButton.TabIndex = 124;
            IsWeaponTypeBraveRadioButton.TabStop = true;
            IsWeaponTypeBraveRadioButton.Text = "勇者";
            IsWeaponTypeBraveRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(IsWeaponTypeAbsorbRadioButton);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(MaxHpNumericUpDown);
            groupBox1.Controls.Add(IsWeaponTypePoisonRadioButton);
            groupBox1.Controls.Add(IsWeaponTypeNormalRadioButton);
            groupBox1.Controls.Add(IsWeaponTypeBraveRadioButton);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(210, 131);
            groupBox1.TabIndex = 125;
            groupBox1.TabStop = false;
            groupBox1.Text = "武器";
            // 
            // IsWeaponTypeAbsorbRadioButton
            // 
            IsWeaponTypeAbsorbRadioButton.AutoSize = true;
            IsWeaponTypeAbsorbRadioButton.Location = new Point(15, 75);
            IsWeaponTypeAbsorbRadioButton.Name = "IsWeaponTypeAbsorbRadioButton";
            IsWeaponTypeAbsorbRadioButton.Size = new Size(49, 19);
            IsWeaponTypeAbsorbRadioButton.TabIndex = 127;
            IsWeaponTypeAbsorbRadioButton.TabStop = true;
            IsWeaponTypeAbsorbRadioButton.Text = "吸収";
            IsWeaponTypeAbsorbRadioButton.UseVisualStyleBackColor = true;
            IsWeaponTypeAbsorbRadioButton.CheckedChanged += IsWeaponTypeAbsorbRadioButton_CheckedChanged;
            // 
            // IsWeaponTypePoisonRadioButton
            // 
            IsWeaponTypePoisonRadioButton.AutoSize = true;
            IsWeaponTypePoisonRadioButton.Location = new Point(15, 100);
            IsWeaponTypePoisonRadioButton.Name = "IsWeaponTypePoisonRadioButton";
            IsWeaponTypePoisonRadioButton.Size = new Size(73, 19);
            IsWeaponTypePoisonRadioButton.TabIndex = 125;
            IsWeaponTypePoisonRadioButton.TabStop = true;
            IsWeaponTypePoisonRadioButton.Text = "状態異常";
            IsWeaponTypePoisonRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(HasSolCheckBox);
            groupBox2.Controls.Add(HasLunaCheckBox);
            groupBox2.Controls.Add(HasAstraCheckBox);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(TecNumericUpDown);
            groupBox2.Controls.Add(HasGreatShieldCheckBox);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(OpponentAttackSpeedNumericUpDown);
            groupBox2.Controls.Add(HasAssaultCheckBox);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(AttackSpeedNumericUpDown);
            groupBox2.Controls.Add(HasContinuationCheckBox);
            groupBox2.Controls.Add(HasVantageCheckBox);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(LevelNumericUpDown);
            groupBox2.Location = new Point(228, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(199, 204);
            groupBox2.TabIndex = 127;
            groupBox2.TabStop = false;
            groupBox2.Text = "スキル";
            // 
            // HasSolCheckBox
            // 
            HasSolCheckBox.AutoSize = true;
            HasSolCheckBox.Location = new Point(15, 176);
            HasSolCheckBox.Name = "HasSolCheckBox";
            HasSolCheckBox.Size = new Size(62, 19);
            HasSolCheckBox.TabIndex = 144;
            HasSolCheckBox.Text = "太陽剣";
            HasSolCheckBox.UseVisualStyleBackColor = true;
            // 
            // HasLunaCheckBox
            // 
            HasLunaCheckBox.AutoSize = true;
            HasLunaCheckBox.Location = new Point(15, 151);
            HasLunaCheckBox.Name = "HasLunaCheckBox";
            HasLunaCheckBox.Size = new Size(62, 19);
            HasLunaCheckBox.TabIndex = 143;
            HasLunaCheckBox.Text = "月光剣";
            HasLunaCheckBox.UseVisualStyleBackColor = true;
            // 
            // HasAstraCheckBox
            // 
            HasAstraCheckBox.AutoSize = true;
            HasAstraCheckBox.Location = new Point(15, 126);
            HasAstraCheckBox.Name = "HasAstraCheckBox";
            HasAstraCheckBox.Size = new Size(62, 19);
            HasAstraCheckBox.TabIndex = 142;
            HasAstraCheckBox.Text = "流星剣";
            HasAstraCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(120, 127);
            label4.Name = "label4";
            label4.Size = new Size(22, 15);
            label4.TabIndex = 141;
            label4.Text = "技:";
            // 
            // TecNumericUpDown
            // 
            TecNumericUpDown.Location = new Point(148, 125);
            TecNumericUpDown.Name = "TecNumericUpDown";
            TecNumericUpDown.Size = new Size(42, 23);
            TecNumericUpDown.TabIndex = 140;
            TecNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // HasGreatShieldCheckBox
            // 
            HasGreatShieldCheckBox.AutoSize = true;
            HasGreatShieldCheckBox.Location = new Point(15, 101);
            HasGreatShieldCheckBox.Name = "HasGreatShieldCheckBox";
            HasGreatShieldCheckBox.Size = new Size(50, 19);
            HasGreatShieldCheckBox.TabIndex = 139;
            HasGreatShieldCheckBox.Text = "大盾";
            HasGreatShieldCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(86, 77);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 138;
            label5.Text = "敵の攻速:";
            // 
            // OpponentAttackSpeedNumericUpDown
            // 
            OpponentAttackSpeedNumericUpDown.Location = new Point(148, 75);
            OpponentAttackSpeedNumericUpDown.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            OpponentAttackSpeedNumericUpDown.Name = "OpponentAttackSpeedNumericUpDown";
            OpponentAttackSpeedNumericUpDown.Size = new Size(42, 23);
            OpponentAttackSpeedNumericUpDown.TabIndex = 137;
            OpponentAttackSpeedNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // HasAssaultCheckBox
            // 
            HasAssaultCheckBox.AutoSize = true;
            HasAssaultCheckBox.Location = new Point(15, 76);
            HasAssaultCheckBox.Name = "HasAssaultCheckBox";
            HasAssaultCheckBox.Size = new Size(50, 19);
            HasAssaultCheckBox.TabIndex = 136;
            HasAssaultCheckBox.Text = "突撃";
            HasAssaultCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(108, 52);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 135;
            label3.Text = "攻速:";
            // 
            // AttackSpeedNumericUpDown
            // 
            AttackSpeedNumericUpDown.Location = new Point(148, 50);
            AttackSpeedNumericUpDown.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            AttackSpeedNumericUpDown.Name = "AttackSpeedNumericUpDown";
            AttackSpeedNumericUpDown.Size = new Size(42, 23);
            AttackSpeedNumericUpDown.TabIndex = 134;
            AttackSpeedNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // HasContinuationCheckBox
            // 
            HasContinuationCheckBox.AutoSize = true;
            HasContinuationCheckBox.Location = new Point(15, 51);
            HasContinuationCheckBox.Name = "HasContinuationCheckBox";
            HasContinuationCheckBox.Size = new Size(50, 19);
            HasContinuationCheckBox.TabIndex = 133;
            HasContinuationCheckBox.Text = "連続";
            HasContinuationCheckBox.UseVisualStyleBackColor = true;
            // 
            // HasVantageCheckBox
            // 
            HasVantageCheckBox.AutoSize = true;
            HasVantageCheckBox.Location = new Point(15, 26);
            HasVantageCheckBox.Name = "HasVantageCheckBox";
            HasVantageCheckBox.Size = new Size(69, 19);
            HasVantageCheckBox.TabIndex = 132;
            HasVantageCheckBox.Text = "待ち伏せ";
            HasVantageCheckBox.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            OkButton.Location = new Point(175, 356);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(92, 31);
            OkButton.TabIndex = 129;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(WeaponStarNumericUpDown);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(IsEffectiveCheckBox);
            groupBox3.Controls.Add(HasSupportCheckBox);
            groupBox3.Controls.Add(HasCriticalSkillCheckBox);
            groupBox3.Location = new Point(12, 149);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(191, 141);
            groupBox3.TabIndex = 130;
            groupBox3.TabStop = false;
            groupBox3.Text = "必殺";
            // 
            // HasCriticalSkillCheckBox
            // 
            HasCriticalSkillCheckBox.AutoSize = true;
            HasCriticalSkillCheckBox.Location = new Point(15, 22);
            HasCriticalSkillCheckBox.Name = "HasCriticalSkillCheckBox";
            HasCriticalSkillCheckBox.Size = new Size(102, 19);
            HasCriticalSkillCheckBox.TabIndex = 145;
            HasCriticalSkillCheckBox.Text = "必殺スキル所持";
            HasCriticalSkillCheckBox.UseVisualStyleBackColor = true;
            // 
            // HasSupportCheckBox
            // 
            HasSupportCheckBox.AutoSize = true;
            HasSupportCheckBox.Location = new Point(15, 47);
            HasSupportCheckBox.Name = "HasSupportCheckBox";
            HasSupportCheckBox.Size = new Size(74, 19);
            HasSupportCheckBox.TabIndex = 146;
            HasSupportCheckBox.Text = "支援効果";
            HasSupportCheckBox.UseVisualStyleBackColor = true;
            // 
            // IsEffectiveCheckBox
            // 
            IsEffectiveCheckBox.AutoSize = true;
            IsEffectiveCheckBox.Location = new Point(15, 72);
            IsEffectiveCheckBox.Name = "IsEffectiveCheckBox";
            IsEffectiveCheckBox.Size = new Size(50, 19);
            IsEffectiveCheckBox.TabIndex = 147;
            IsEffectiveCheckBox.Text = "特効";
            IsEffectiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 100);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 148;
            label6.Text = "武器の★:";
            // 
            // WeaponStarNumericUpDown
            // 
            WeaponStarNumericUpDown.Enabled = false;
            WeaponStarNumericUpDown.Location = new Point(77, 98);
            WeaponStarNumericUpDown.Name = "WeaponStarNumericUpDown";
            WeaponStarNumericUpDown.Size = new Size(42, 23);
            WeaponStarNumericUpDown.TabIndex = 128;
            WeaponStarNumericUpDown.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // UnitStatusDetailDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 399);
            Controls.Add(groupBox3);
            Controls.Add(OkButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
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
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)WeaponStarNumericUpDown).EndInit();
            ResumeLayout(false);
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
        private CheckBox HasContinuationCheckBox;
        private CheckBox HasSolCheckBox;
        private CheckBox HasLunaCheckBox;
        private CheckBox HasAstraCheckBox;
        private Label label4;
        private NumericUpDownEx TecNumericUpDown;
        private CheckBox HasGreatShieldCheckBox;
        private GroupBox groupBox3;
        private CheckBox HasSupportCheckBox;
        private CheckBox HasCriticalSkillCheckBox;
        private NumericUpDownEx WeaponStarNumericUpDown;
        private Label label6;
        private CheckBox IsEffectiveCheckBox;
    }
}
