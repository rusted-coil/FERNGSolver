using FERNGSolver.Gba.Domain.Combat;

namespace FERNGSolver.Gba.UI.Search.Internal
{
    internal partial class BindingBladeUnitStatusDetailDialog : Form, IUnitStatusDetailDialog
    {
        public Form Form => this;

        private readonly RadioButton[] WeaponTypeRadioButtons;

        // ReadOnlyなUnitStatusDetailを元に、UnitStatusDetailDialogを初期化します。
        public BindingBladeUnitStatusDetailDialog(IUnitStatusDetail currentStatus)
        {
            InitializeComponent();

            WeaponTypeRadioButtons = [
                IsWeaponTypeNormalRadioButton,
                IsWeaponTypeBraveRadioButton,
                IsWeaponTypeAbsorbRadioButton,
                IsWeaponTypePoisonRadioButton,
                IsWeaponTypeCursedRadioButton,
            ];

            for (int i = 0; i < WeaponTypeRadioButtons.Length; ++i)
            {
                WeaponTypeRadioButtons[i].Checked = (i == (int)currentStatus.WeaponType);
            }

            MaxHpNumericUpDown.Value = currentStatus.MaxHp;
            LuckNumericUpDown.Value = currentStatus.Luck;
        }

        // 変更可能なUnitStatusDetailにフォーム内容の下記戻しを行います。
        public void WriteToUnitStatusDetail(UnitStatusDetail unitStatusDetail)
        {
            unitStatusDetail.WeaponType = (Const.WeaponType)Array.IndexOf(WeaponTypeRadioButtons, WeaponTypeRadioButtons.FirstOrDefault(r => r.Checked));
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
