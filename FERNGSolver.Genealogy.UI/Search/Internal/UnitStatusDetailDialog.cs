using FERNGSolver.Genealogy.Domain.Combat;
using FERNGSolver.Genealogy.Presentation.ViewContracts;

namespace FERNGSolver.Genealogy.UI.Search.Internal
{
    internal partial class UnitStatusDetailDialog : Form
    {
        private readonly RadioButton[] WeaponTypeRadioButtons;

        // ReadOnlyなUnitStatusDetailを元に、UnitStatusDetailDialogを初期化します。
        public UnitStatusDetailDialog(IUnitStatusDetail currentStatus)
        {
            InitializeComponent();

            WeaponTypeRadioButtons = [
                IsWeaponTypeNormalRadioButton,
                IsWeaponTypeBraveRadioButton,
                IsWeaponTypeAbsorbRadioButton,
                IsWeaponTypePoisonRadioButton,
            ];

            HasVantageCheckBox.Checked = currentStatus.HasVantage;
            HasAstraCheckBox.Checked = currentStatus.HasAstra;
            HasLunaCheckBox.Checked = currentStatus.HasLuna;
            HasSolCheckBox.Checked = currentStatus.HasSol;
            HasContinuationCheckBox.Checked = currentStatus.HasContinuation;
            HasAssaultCheckBox.Checked = currentStatus.HasAssault;
            HasGreatShieldCheckBox.Checked = currentStatus.HasGreatShield;


            /*
            for (int i = 0; i < WeaponTypeRadioButtons.Length; ++i)
            {
                WeaponTypeRadioButtons[i].Checked = (i == (int)currentStatus.WeaponType);
            }
            for (int i = 0; i < SkillTypeRadioButtons.Length; ++i)
            {
                SkillTypeRadioButtons[i].Checked = (i == (int)currentStatus.SkillType);
            }
            for (int i = 0; i < BossTypeRadioButtons.Length; ++i)
            {
                BossTypeRadioButtons[i].Checked = (i == (int)currentStatus.BossType);
            }

            LevelNumericUpDown.Value = currentStatus.Level;
            MaxHpNumericUpDown.Value = currentStatus.MaxHp;
            LuckNumericUpDown.Value = currentStatus.Luck;
            OpponentDefNumericUpDown.Value = currentStatus.OpponentDefense;
            */
        }

        // 変更可能なUnitStatusDetailにフォーム内容の下記戻しを行います。
        public void WriteToUnitStatusDetail(UnitStatusDetail unitStatusDetail)
        {
            unitStatusDetail.HasVantage = HasVantageCheckBox.Checked;
            unitStatusDetail.HasAstra = HasAstraCheckBox.Checked;
            unitStatusDetail.HasLuna = HasLunaCheckBox.Checked;
            unitStatusDetail.HasSol = HasSolCheckBox.Checked;
            unitStatusDetail.HasContinuation = HasContinuationCheckBox.Checked;
            unitStatusDetail.HasAssault = HasAssaultCheckBox.Checked;
            unitStatusDetail.HasGreatShield = HasGreatShieldCheckBox.Checked;
            /*
            unitStatusDetail.WeaponType = (Const.WeaponType)Array.IndexOf(WeaponTypeRadioButtons, WeaponTypeRadioButtons.FirstOrDefault(r => r.Checked));
            unitStatusDetail.SkillType = (Const.SkillType)Array.IndexOf(SkillTypeRadioButtons, SkillTypeRadioButtons.FirstOrDefault(r => r.Checked));
            unitStatusDetail.BossType = (Const.BossType)Array.IndexOf(BossTypeRadioButtons, BossTypeRadioButtons.FirstOrDefault(r => r.Checked));
            unitStatusDetail.Level = (int)LevelNumericUpDown.Value;
            unitStatusDetail.MaxHp = (int)MaxHpNumericUpDown.Value;
            unitStatusDetail.Luck = (int)LuckNumericUpDown.Value;
            unitStatusDetail.OpponentDefense = (int)OpponentDefNumericUpDown.Value;
            */
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
    }
}
