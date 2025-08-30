using FERNGSolver.Gba.Domain.Combat;

namespace FERNGSolver.Gba.UI.Search.Internal
{
    internal partial class BlazingBladeUnitStatusDetailDialog : Form, IUnitStatusDetailDialog
    {
        public Form Form => this;

        private readonly RadioButton[] WeaponTypeRadioButtons;
        private readonly RadioButton?[] SkillTypeRadioButtons;
        private readonly RadioButton[] BossTypeRadioButtons;

        // ReadOnlyなUnitStatusDetailを元に、UnitStatusDetailDialogを初期化します。
        public BlazingBladeUnitStatusDetailDialog(IUnitStatusDetail currentStatus)
        {
            InitializeComponent();

            WeaponTypeRadioButtons = [
                IsWeaponTypeNormalRadioButton,
                IsWeaponTypeBraveRadioButton,
                IsWeaponTypeAbsorbRadioButton,
                IsWeaponTypePoisonRadioButton,
                IsWeaponTypeCursedRadioButton,
            ];
            SkillTypeRadioButtons = [
                IsSkillTypeNoneRadioButton,
                null,
                null,
                null,
                IsSkillTypeSilencerRadioButton,
            ];
            BossTypeRadioButtons = [
                IsBossTypeNoneRadioButton,
                IsBossTypeBossRadioButton,
                IsBossTypeFinalBossRadioButton,
            ];

            for (int i = 0; i < WeaponTypeRadioButtons.Length; ++i)
            {
                WeaponTypeRadioButtons[i].Checked = (i == (int)currentStatus.WeaponType);
            }
            for (int i = 0; i < SkillTypeRadioButtons.Length; ++i)
            {
                if (SkillTypeRadioButtons[i] != null)
                {
                    SkillTypeRadioButtons[i].Checked = (i == (int)currentStatus.SkillType);
                }
            }
            for (int i = 0; i < BossTypeRadioButtons.Length; ++i)
            {
                BossTypeRadioButtons[i].Checked = (i == (int)currentStatus.BossType);
            }

            MaxHpNumericUpDown.Value = currentStatus.MaxHp;
            LuckNumericUpDown.Value = currentStatus.Luck;
        }

        // 変更可能なUnitStatusDetailにフォーム内容の下記戻しを行います。
        public void WriteToUnitStatusDetail(UnitStatusDetail unitStatusDetail)
        {
            unitStatusDetail.WeaponType = (Const.WeaponType)Array.IndexOf(WeaponTypeRadioButtons, WeaponTypeRadioButtons.FirstOrDefault(r => r.Checked));
            unitStatusDetail.SkillType = (Const.SkillType)Array.IndexOf(SkillTypeRadioButtons, SkillTypeRadioButtons.FirstOrDefault(r => r != null && r.Checked));
            unitStatusDetail.BossType = (Const.BossType)Array.IndexOf(BossTypeRadioButtons, BossTypeRadioButtons.FirstOrDefault(r => r.Checked));
            unitStatusDetail.MaxHp = (int)MaxHpNumericUpDown.Value;
            unitStatusDetail.Luck = (int)LuckNumericUpDown.Value;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void IsWeaponTypeAbsorbRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            MaxHpNumericUpDown.Enabled = IsWeaponTypeAbsorbRadioButton.Checked;
        }

        private void IsWeaponTypeCursedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LuckNumericUpDown.Enabled = IsWeaponTypeCursedRadioButton.Checked;
        }
    }
}
