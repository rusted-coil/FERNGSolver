using FERNGSolver.Common.UI.Controls;

namespace FERNGSolver.Gba.UI.Search.Internal
{
    partial class BlazingBladeUnitStatusDetailDialog
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
            label2 = new Label();
            MaxHpNumericUpDown = new NumericUpDownEx();
            IsWeaponTypeNormalRadioButton = new RadioButton();
            IsWeaponTypeBraveRadioButton = new RadioButton();
            groupBox1 = new GroupBox();
            label3 = new Label();
            LuckNumericUpDown = new NumericUpDownEx();
            IsWeaponTypeAbsorbRadioButton = new RadioButton();
            IsWeaponTypeCursedRadioButton = new RadioButton();
            IsWeaponTypePoisonRadioButton = new RadioButton();
            groupBox2 = new GroupBox();
            IsSkillTypeSilencerRadioButton = new RadioButton();
            IsSkillTypeNoneRadioButton = new RadioButton();
            groupBox3 = new GroupBox();
            IsBossTypeFinalBossRadioButton = new RadioButton();
            IsBossTypeNoneRadioButton = new RadioButton();
            IsBossTypeBossRadioButton = new RadioButton();
            OkButton = new Button();
            ((System.ComponentModel.ISupportInitialize)MaxHpNumericUpDown).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LuckNumericUpDown).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
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
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(LuckNumericUpDown);
            groupBox1.Controls.Add(IsWeaponTypeAbsorbRadioButton);
            groupBox1.Controls.Add(IsWeaponTypeCursedRadioButton);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(MaxHpNumericUpDown);
            groupBox1.Controls.Add(IsWeaponTypePoisonRadioButton);
            groupBox1.Controls.Add(IsWeaponTypeNormalRadioButton);
            groupBox1.Controls.Add(IsWeaponTypeBraveRadioButton);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(210, 160);
            groupBox1.TabIndex = 125;
            groupBox1.TabStop = false;
            groupBox1.Text = "武器";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(109, 127);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 129;
            label3.Text = "幸運:";
            // 
            // LuckNumericUpDown
            // 
            LuckNumericUpDown.Enabled = false;
            LuckNumericUpDown.Location = new Point(149, 125);
            LuckNumericUpDown.Name = "LuckNumericUpDown";
            LuckNumericUpDown.Size = new Size(42, 23);
            LuckNumericUpDown.TabIndex = 128;
            LuckNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
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
            // IsWeaponTypeCursedRadioButton
            // 
            IsWeaponTypeCursedRadioButton.AutoSize = true;
            IsWeaponTypeCursedRadioButton.Location = new Point(15, 125);
            IsWeaponTypeCursedRadioButton.Name = "IsWeaponTypeCursedRadioButton";
            IsWeaponTypeCursedRadioButton.Size = new Size(79, 19);
            IsWeaponTypeCursedRadioButton.TabIndex = 126;
            IsWeaponTypeCursedRadioButton.TabStop = true;
            IsWeaponTypeCursedRadioButton.Text = "デビルアクス";
            IsWeaponTypeCursedRadioButton.UseVisualStyleBackColor = true;
            IsWeaponTypeCursedRadioButton.CheckedChanged += IsWeaponTypeCursedRadioButton_CheckedChanged;
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
            groupBox2.Controls.Add(IsSkillTypeSilencerRadioButton);
            groupBox2.Controls.Add(IsSkillTypeNoneRadioButton);
            groupBox2.Location = new Point(228, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(93, 160);
            groupBox2.TabIndex = 127;
            groupBox2.TabStop = false;
            groupBox2.Text = "スキル";
            // 
            // IsSkillTypeSilencerRadioButton
            // 
            IsSkillTypeSilencerRadioButton.AutoSize = true;
            IsSkillTypeSilencerRadioButton.Location = new Point(15, 50);
            IsSkillTypeSilencerRadioButton.Name = "IsSkillTypeSilencerRadioButton";
            IsSkillTypeSilencerRadioButton.Size = new Size(49, 19);
            IsSkillTypeSilencerRadioButton.TabIndex = 127;
            IsSkillTypeSilencerRadioButton.TabStop = true;
            IsSkillTypeSilencerRadioButton.Text = "瞬殺";
            IsSkillTypeSilencerRadioButton.UseVisualStyleBackColor = true;
            // 
            // IsSkillTypeNoneRadioButton
            // 
            IsSkillTypeNoneRadioButton.AutoSize = true;
            IsSkillTypeNoneRadioButton.Location = new Point(15, 25);
            IsSkillTypeNoneRadioButton.Name = "IsSkillTypeNoneRadioButton";
            IsSkillTypeNoneRadioButton.Size = new Size(43, 19);
            IsSkillTypeNoneRadioButton.TabIndex = 123;
            IsSkillTypeNoneRadioButton.TabStop = true;
            IsSkillTypeNoneRadioButton.Text = "なし";
            IsSkillTypeNoneRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(IsBossTypeFinalBossRadioButton);
            groupBox3.Controls.Add(IsBossTypeNoneRadioButton);
            groupBox3.Controls.Add(IsBossTypeBossRadioButton);
            groupBox3.Location = new Point(12, 178);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(309, 59);
            groupBox3.TabIndex = 128;
            groupBox3.TabStop = false;
            groupBox3.Text = "ボス属性（相手の瞬殺判定にのみ影響）";
            // 
            // IsBossTypeFinalBossRadioButton
            // 
            IsBossTypeFinalBossRadioButton.AutoSize = true;
            IsBossTypeFinalBossRadioButton.Location = new Point(161, 24);
            IsBossTypeFinalBossRadioButton.Name = "IsBossTypeFinalBossRadioButton";
            IsBossTypeFinalBossRadioButton.Size = new Size(71, 19);
            IsBossTypeFinalBossRadioButton.TabIndex = 125;
            IsBossTypeFinalBossRadioButton.TabStop = true;
            IsBossTypeFinalBossRadioButton.Text = "古の火竜";
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
            IsBossTypeBossRadioButton.Location = new Point(93, 24);
            IsBossTypeBossRadioButton.Name = "IsBossTypeBossRadioButton";
            IsBossTypeBossRadioButton.Size = new Size(44, 19);
            IsBossTypeBossRadioButton.TabIndex = 124;
            IsBossTypeBossRadioButton.TabStop = true;
            IsBossTypeBossRadioButton.Text = "ボス";
            IsBossTypeBossRadioButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            OkButton.Location = new Point(120, 243);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(92, 31);
            OkButton.TabIndex = 129;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // BlazingBladeUnitStatusDetailDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 285);
            Controls.Add(OkButton);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "BlazingBladeUnitStatusDetailDialog";
            Text = "詳細設定";
            ((System.ComponentModel.ISupportInitialize)MaxHpNumericUpDown).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LuckNumericUpDown).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private NumericUpDownEx MaxHpNumericUpDown;
        private RadioButton IsWeaponTypeNormalRadioButton;
        private RadioButton IsWeaponTypeBraveRadioButton;
        private GroupBox groupBox1;
        private RadioButton IsWeaponTypeCursedRadioButton;
        private RadioButton IsWeaponTypePoisonRadioButton;
        private GroupBox groupBox2;
        private RadioButton IsSkillTypeNoneRadioButton;
        private RadioButton IsWeaponTypeAbsorbRadioButton;
        private RadioButton IsSkillTypeSilencerRadioButton;
        private GroupBox groupBox3;
        private RadioButton IsBossTypeFinalBossRadioButton;
        private RadioButton IsBossTypeNoneRadioButton;
        private RadioButton IsBossTypeBossRadioButton;
        private Label label3;
        private NumericUpDownEx LuckNumericUpDown;
        private Button OkButton;
    }
}
