using FERNGSolver.Radiance.Domain.Combat;

namespace FERNGSolver.Radiance.UI.Search.Internal
{
    internal partial class UnitStatusDetailDialog : Form
    {
        private readonly RadioButton[] WeaponTypeRadioButtons;
        private readonly RadioButton[] BossTypeRadioButtons;
        private readonly UnitStatusDetailDialogState m_State;
        private readonly Control[] ParameterControls;
        private readonly ICheckable[][] ParameterControlDependencies;

        #region 標準のCheckBoxとRadioButtonが共通のCheckメンバを持たないのでラッパーを定義
        private interface ICheckable
        {
            bool Checked { get; }
        }
        private class RadioButtonWrapper : ICheckable
        {
            private readonly RadioButton _radioButton;
            public RadioButtonWrapper(RadioButton radioButton)
            {
                _radioButton = radioButton;
            }
            public bool Checked => _radioButton.Checked;
        }
        private class CheckBoxWrapper : ICheckable
        {
            private readonly CheckBox _checkBox;
            public CheckBoxWrapper(CheckBox checkBox)
            {
                _checkBox = checkBox;
            }
            public bool Checked => _checkBox.Checked;
        }
        private class NumericUpDownWrapper : ICheckable
        {
            private readonly NumericUpDown _numericUpDown;
            private readonly int _criterionExclusive;
            public NumericUpDownWrapper(NumericUpDown numericUpDown, int criterionExclusive)
            {
                _numericUpDown = numericUpDown;
                _criterionExclusive = criterionExclusive;
            }
            public bool Checked => _numericUpDown.Value > _criterionExclusive;
        }
        #endregion

        // 初期化・書き戻しを行うStateを指定して初期化します。
        public UnitStatusDetailDialog(UnitStatusDetailDialogState state)
        {
            m_State = state;

            InitializeComponent();

            WeaponTypeRadioButtons = [
                IsWeaponTypeNormalRadioButton,
                IsWeaponTypeBraveRadioButton,
                IsWeaponTypeMagicSwordRadioButton,
                IsWeaponTypeAbsorbRadioButton,
            ];
            BossTypeRadioButtons = [
                IsBossTypeNoneRadioButton,
                IsBossTypeBossRadioButton,
                IsBossTypeFinalBossRadioButton,
            ];
            ParameterControls = [
                LevelNumericUpDown,
                MaxHpNumericUpDown,
                StrNumericUpDown,
                TecNumericUpDown,
                LuckNumericUpDown,
                OpponentDefNumericUpDown,
            ];

            // パラメータの依存関係を登録
            // 「どの判定に何のパラメータが使われるか」は本来Domain領域に定義した方がいいと思う
            // やるなら例えばパラメータごとにタグを用意して、Domain側はタグの依存関係のみを提供、UI側でそれに基づいてコントロールを紐づけるといった感じ？
            ParameterControlDependencies = [
                // Lv依存は武器破壊
                [ new CheckBoxWrapper(HasCorrodeCheckBox) ],
                // 最大HP依存は吸収武器、怒り、勇将、天空、太陽
                [   new RadioButtonWrapper(IsWeaponTypeAbsorbRadioButton),
                    new CheckBoxWrapper(HasWrathCheckBox),
                    new CheckBoxWrapper(HasResolveCheckBox),
                    new CheckBoxWrapper(HasAetherCheckBox),
                    new CheckBoxWrapper(HasSolCheckBox) ],
                // 力依存は勇将、鳴動
                [   new CheckBoxWrapper(HasResolveCheckBox),
                    new CheckBoxWrapper(HasColossusCheckBox) ],
                // 技依存は連続、勇将、武器破壊、衝撃、鳴動、天空、流星、月光、太陽、陽光、カウンター、キャンセル、狙撃、翼の守護
                [   new CheckBoxWrapper(HasAdeptCheckBox),
                    new CheckBoxWrapper(HasResolveCheckBox),
                    new CheckBoxWrapper(HasCorrodeCheckBox),
                    new CheckBoxWrapper(HasStunCheckBox),
                    new CheckBoxWrapper(HasColossusCheckBox),
                    new CheckBoxWrapper(HasAetherCheckBox),
                    new CheckBoxWrapper(HasAstraCheckBox),
                    new CheckBoxWrapper(HasLunaCheckBox),
                    new CheckBoxWrapper(HasSolCheckBox),
                    new CheckBoxWrapper(HasFlareCheckBox),
                    new CheckBoxWrapper(HasCounterCheckBox),
                    new CheckBoxWrapper(HasGuardCheckBox),
                    new CheckBoxWrapper(HasDeadeyeCheckBox),
                    new CheckBoxWrapper(HasCancelCheckBox) ],
                // 幸運依存は祈り
                [ new CheckBoxWrapper(HasMiracleCheckBox) ],
                // 相手の守備/魔防依存は天空、月光、陽光
                [   new CheckBoxWrapper(HasAetherCheckBox),
                    new CheckBoxWrapper(HasLunaCheckBox),
                    new CheckBoxWrapper(HasFlareCheckBox)],
            ];

            WeaponUsesNumericUpDown.Value = state.WeaponUses;
            WeaponTypeRadioButtons[(int)m_State.WeaponType].Checked = true;
            BossTypeRadioButtons[(int)m_State.BossType].Checked = true;
            LevelNumericUpDown.Value = state.Level;
            MaxHpNumericUpDown.Value = state.MaxHp;
            StrNumericUpDown.Value = state.Str;
            TecNumericUpDown.Value = state.Tec;
            LuckNumericUpDown.Value = state.Luck;
            OpponentDefNumericUpDown.Value = state.OpponentDefense;
            
            HasVantageCheckBox.Checked = state.HasVantage;
            HasAdeptCheckBox.Checked = state.HasAdept;
            HasWrathCheckBox.Checked = state.HasWrath;
            HasResolveCheckBox.Checked = state.HasResolve;
            HasMiracleCheckBox.Checked = state.HasMiracle;
            HasCounterCheckBox.Checked = state.HasCounter;
            HasAetherCheckBox.Checked = state.HasAether;
            HasAstraCheckBox.Checked = state.HasAstra;
            HasLunaCheckBox.Checked = state.HasLuna;
            HasSolCheckBox.Checked = state.HasSol;
            HasFlareCheckBox.Checked = state.HasFlare;
            HasStunCheckBox.Checked = state.HasStun;
            HasColossusCheckBox.Checked = state.HasColossus;
            HasDeadeyeCheckBox.Checked = state.HasDeadeye;
            HasLethalityCheckBox.Checked = state.HasLethality;
            HasGuardCheckBox.Checked = state.HasGuard;
            HasCorrodeCheckBox.Checked = state.HasCorrode;
            HasCancelCheckBox.Checked = state.HasCancel;

            RefreshParameterControlState();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            m_State.WeaponUses = (int)WeaponUsesNumericUpDown.Value;
            m_State.WeaponType = (Const.WeaponType)Array.IndexOf(WeaponTypeRadioButtons, WeaponTypeRadioButtons.FirstOrDefault(r => r.Checked));
            m_State.BossType = (Const.BossType)Array.IndexOf(BossTypeRadioButtons, BossTypeRadioButtons.FirstOrDefault(r => r.Checked));
            m_State.Level = (int)LevelNumericUpDown.Value;
            m_State.MaxHp = (int)MaxHpNumericUpDown.Value;
            m_State.Str = (int)StrNumericUpDown.Value;
            m_State.Tec = (int)TecNumericUpDown.Value;
            m_State.Luck = (int)LuckNumericUpDown.Value;
            m_State.OpponentDefense = (int)OpponentDefNumericUpDown.Value;

            m_State.HasVantage = HasVantageCheckBox.Checked;
            m_State.HasAdept = HasAdeptCheckBox.Checked;
            m_State.HasWrath = HasWrathCheckBox.Checked;
            m_State.HasResolve = HasResolveCheckBox.Checked;
            m_State.HasMiracle = HasMiracleCheckBox.Checked;
            m_State.HasCounter = HasCounterCheckBox.Checked;
            m_State.HasAether = HasAetherCheckBox.Checked;
            m_State.HasAstra = HasAstraCheckBox.Checked;
            m_State.HasLuna = HasLunaCheckBox.Checked;
            m_State.HasSol = HasSolCheckBox.Checked;
            m_State.HasFlare = HasFlareCheckBox.Checked;
            m_State.HasStun = HasStunCheckBox.Checked;
            m_State.HasColossus = HasColossusCheckBox.Checked;
            m_State.HasDeadeye = HasDeadeyeCheckBox.Checked;
            m_State.HasLethality = HasLethalityCheckBox.Checked;
            m_State.HasGuard = HasGuardCheckBox.Checked;
            m_State.HasCorrode = HasCorrodeCheckBox.Checked;
            m_State.HasCancel = HasCancelCheckBox.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RadioButtonControlStateChenged(object sender, EventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Checked)
            {
                RefreshParameterControlState();
            }
        }
        private void ParameterControlStateChenged(object sender, EventArgs e) => RefreshParameterControlState();

        // チェックボックスの状況によって設定できるパラメータを制御
        private void RefreshParameterControlState()
        {
            for (int a = 0; a < ParameterControls.Length; ++a)
            {
                bool isEnabled = false;
                // 依存先コントロールのうち一つでも条件を満たせば有効化
                for (int b = 0; b < ParameterControlDependencies[a].Length; ++b)
                {
                    if (ParameterControlDependencies[a][b].Checked)
                    {
                        isEnabled = true;
                        break;
                    }
                }
                ParameterControls[a].BackColor = isEnabled ? Color.Yellow : SystemColors.Window;
                ParameterControls[a].Enabled = isEnabled;
            }
        }
    }
}
