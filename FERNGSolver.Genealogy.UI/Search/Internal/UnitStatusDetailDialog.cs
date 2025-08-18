using FERNGSolver.Genealogy.Domain.Combat;

namespace FERNGSolver.Genealogy.UI.Search.Internal
{
    internal partial class UnitStatusDetailDialog : Form
    {
        private readonly RadioButton[] WeaponTypeRadioButtons;
        private readonly UnitStatusDetailDialogState m_State;

        // 初期化・書き戻しを行うStateを指定して初期化します。
        public UnitStatusDetailDialog(UnitStatusDetailDialogState state)
        {
            m_State = state;

            InitializeComponent();

            WeaponTypeRadioButtons = [
                IsWeaponTypeNormalRadioButton,
                IsWeaponTypeBraveRadioButton,
                IsWeaponTypeAbsorbRadioButton,
                IsWeaponTypePoisonRadioButton,
            ];

            WeaponTypeRadioButtons[(int)m_State.WeaponType].Checked = true;
            LevelNumericUpDown.Value = state.Level;
            MaxHpNumericUpDown.Value = state.MaxHp;
            TecNumericUpDown.Value = state.Tec;
            AttackSpeedNumericUpDown.Value = state.AttackSpeed;
            OpponentAttackSpeedNumericUpDown.Value = state.OpponentAttackSpeed;

            HasVantageCheckBox.Checked = state.HasVantage;
            HasAstraCheckBox.Checked = state.HasAstra;
            HasLunaCheckBox.Checked = state.HasLuna;
            HasSolCheckBox.Checked = state.HasSol;
            HasContinuationCheckBox.Checked = state.HasContinuation;
            HasAssaultCheckBox.Checked = state.HasAssault;
            HasGreatShieldCheckBox.Checked = state.HasGreatShield;
            HasWrathCheckBox.Checked = state.HasWrath;
            HasPrayCheckBox.Checked = state.HasPray;

            HasCriticalSkillCheckBox.Checked = state.HasCriticalSkill;
            HasSupportCheckBox.Checked = state.HasSupport;
            IsEffectiveCheckBox.Checked = state.IsEffective;
            WeaponStarNumericUpDown.Value = state.WeaponStarCount;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            m_State.WeaponType = (Const.WeaponType)Array.IndexOf(WeaponTypeRadioButtons, WeaponTypeRadioButtons.FirstOrDefault(r => r.Checked));
            m_State.Level = (int)LevelNumericUpDown.Value;
            m_State.MaxHp = (int)MaxHpNumericUpDown.Value;
            m_State.Tec = (int)TecNumericUpDown.Value;
            m_State.AttackSpeed = (int)AttackSpeedNumericUpDown.Value;
            m_State.OpponentAttackSpeed = (int)OpponentAttackSpeedNumericUpDown.Value;

            m_State.HasVantage = HasVantageCheckBox.Checked;
            m_State.HasAstra = HasAstraCheckBox.Checked;
            m_State.HasLuna = HasLunaCheckBox.Checked;
            m_State.HasSol = HasSolCheckBox.Checked;
            m_State.HasContinuation = HasContinuationCheckBox.Checked;
            m_State.HasAssault = HasAssaultCheckBox.Checked;
            m_State.HasGreatShield = HasGreatShieldCheckBox.Checked;
            m_State.HasWrath = HasWrathCheckBox.Checked;
            m_State.HasPray = HasPrayCheckBox.Checked;

            m_State.HasCriticalSkill = HasCriticalSkillCheckBox.Checked;
            m_State.HasSupport = HasSupportCheckBox.Checked;
            m_State.IsEffective = IsEffectiveCheckBox.Checked;
            m_State.WeaponStarCount = (int)WeaponStarNumericUpDown.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void IsWeaponTypeAbsorbRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            MaxHpNumericUpDown.Enabled = IsWeaponTypeAbsorbRadioButton.Checked;
        }
    }
}
