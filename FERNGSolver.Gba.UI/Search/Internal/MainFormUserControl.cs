using FERNGSolver.Common.Interfaces;
using FERNGSolver.Common.ViewContracts;
using FERNGSolver.Gba.Domain.Character;
using FERNGSolver.Gba.Domain.Character.Extensions;
using FERNGSolver.Gba.Domain.Repository.Stub;
using FERNGSolver.Gba.Presentation.ViewContracts;
using System.Reactive;

namespace FERNGSolver.Gba.UI.Search
{
    internal partial class MainFormUserControl : UserControl, IExtendedMainFormView
    {
        public IObservable<Unit> GetSearchButtonClicked(string title) => m_MainFormView.GetSearchButtonClicked(title);
        public void ShowSearchResults(IReadOnlyList<ITableColumn> columns, Type viewModelType, IReadOnlyList<object> viewModels) => m_MainFormView.ShowSearchResults(columns, viewModelType, viewModels);

        // ファルコンナイト法
        public bool UsesFalconKnightMethod => UsesFalconKnightMethodCheckBox.Checked;
        public string CxString => CxStringTextBox.Text;
        public bool AddsCxOffset => AddsCxOffsetCheckBox.Checked;

        // 戦闘
        public bool ContainsCombat => ContainsCombatCheckBox.Checked;
        public int AttackerHp => (int)AttackerHpNumericUpDown.Value;
        public int AttackerPower => (int)AttackerPowerNumericUpDown.Value;
        public int AttackerHitRate => (int)AttackerHitRateNumericUpDown.Value;
        public int AttackerCriticalRate => (int)AttackerCriticalRateNumericUpDown.Value;
        public int AttackerPhaseCount => DoesAttackerFollowUpAttackCheckBox.Checked ? 2 : 1;
        public bool IsAttackerDoubleAttack => false;
        public int DefenderHp => (int)DefenderHpNumericUpDown.Value;
        public int DefenderPower => (int)DefenderPowerNumericUpDown.Value;
        public int DefenderHitRate => (int)DefenderHitRateNumericUpDown.Value;
        public int DefenderCriticalRate => (int)DefenderCriticalRateNumericUpDown.Value;
        public int DefenderPhaseCount => DoesDefenderAttackCheckBox.Checked ? (DoesDefenderFollowUpAttackCheckBox.Checked ? 2 : 1) : 0;
        public bool IsDefenderDoubleAttack => false;

        // 戦闘事後条件
        public int AttackerHpPostconditionMin => FiltersByAttackerHpPostconditionCheckBox.Checked ? (int)AttackerHpPostconditionMinNumericUpDown.Value : 0;
        public int AttackerHpPostconditionMax => FiltersByAttackerHpPostconditionCheckBox.Checked ? (int)AttackerHpPostconditionMaxNumericUpDown.Value : 999;
        public int DefenderHpPostconditionMin => FiltersByDefenderHpPostconditionCheckBox.Checked ? (int)DefenderHpPostconditionMinNumericUpDown.Value : 0;
        public int DefenderHpPostconditionMax => FiltersByDefenderHpPostconditionCheckBox.Checked ? (int)DefenderHpPostconditionMaxNumericUpDown.Value : 999;

        // レベルアップ
        public bool ContainsGrowth => ContainsGrowthCheckBox.Checked;
        public int HpGrowthRate => IsHpGrowthNeeded.Checked ? (int)GrowthHpRateNumericUpDown.Value : 100;
        public int AtkGrowthRate => IsAtkGrowthNeeded.Checked ? (int)GrowthAtkRateNumericUpDown.Value : 100;
        public int TecGrowthRate => IsTecGrowthNeeded.Checked ? (int)GrowthTecRateNumericUpDown.Value : 100;
        public int SpdGrowthRate => IsSpdGrowthNeeded.Checked ? (int)GrowthSpdRateNumericUpDown.Value : 100;
        public int DefGrowthRate => IsDefGrowthNeeded.Checked ? (int)GrowthDefRateNumericUpDown.Value : 100;
        public int MdfGrowthRate => IsMdfGrowthNeeded.Checked ? (int)GrowthMdfRateNumericUpDown.Value : 100;
        public int LucGrowthRate => IsLucGrowthNeeded.Checked ? (int)GrowthLucRateNumericUpDown.Value : 100;

        // 検索条件
        public int CurrentPosition => (int)CurrentRngCountNumericUpDown.Value;
        public int OffsetMin => (int)OffsetMinNumericUpDown.Value;
        public int OffsetMax => (int)OffsetMaxNumericUpDown.Value;

        // 結果出力用
        public int FalconKnightMethodMove => (int)FalconKnightConsumeMoveNumericUpDown.Value;

        private readonly IMainFormView m_MainFormView;
        private readonly IReadOnlyList<ICharacter> m_Characters;

        public MainFormUserControl(IMainFormView mainFormView)
        {
            m_MainFormView = mainFormView;
            InitializeComponent();

            // TODO とりあえずStubからキャラデータを取得してコンボボックスにセットする
            var characterRepository = new StubCharacterRepository();
            m_Characters = characterRepository.AllCharacters;
            GrowthCharacterNameComboBox.Items.Clear();
            GrowthCharacterNameComboBox.Items.AddRange(m_Characters.Select(x => x.Name).ToArray());
            for (int i = 0; i < m_Characters.Count; ++i)
            {
                if (!m_Characters[i].IsPartitionData())
                {
                    GrowthCharacterNameComboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        public void InitializeDefaults()
        {
            OffsetMinNumericUpDown.Value = 0;
            OffsetMaxNumericUpDown.Value = 10000;
        }

        private void UsesFalconKnightMethodCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // ファルコンナイト法検索にチェックを入れてる時は戦闘とレベルアップ検索を無効に
            bool isChecked = UsesFalconKnightMethodCheckBox.Checked;
            ContainsCombatCheckBox.Enabled = !isChecked;
            CombatGroupBox.Enabled = !isChecked;
            ContainsGrowthCheckBox.Enabled = !isChecked;
            GrowthGroupBox.Enabled = !isChecked;
        }

        private void GrowthCharacterNameComboBox_SelectedIndexChanged(object sender, EventArgs e) => RefreshGrowthRate();
        private void IsGrowthBoostedCheckBox_CheckedChanged(object sender, EventArgs e) => RefreshGrowthRate();

        void RefreshGrowthRate()
        {
            if (GrowthCharacterNameComboBox.SelectedIndex >= 0 && GrowthCharacterNameComboBox.SelectedIndex < m_Characters.Count)
            {
                var character = m_Characters[GrowthCharacterNameComboBox.SelectedIndex];
                if (!character.IsPartitionData())
                {
                    if (IsGrowthBoostedCheckBox.Checked)
                    {
                        character = character.Boost();
                    }

                    GrowthHpRateNumericUpDown.Value = character.HpGrowthRate;
                    GrowthAtkRateNumericUpDown.Value = character.AtkGrowthRate;
                    GrowthTecRateNumericUpDown.Value = character.TecGrowthRate;
                    GrowthSpdRateNumericUpDown.Value = character.SpdGrowthRate;
                    GrowthDefRateNumericUpDown.Value = character.DefGrowthRate;
                    GrowthMdfRateNumericUpDown.Value = character.MdfGrowthRate;
                    GrowthLucRateNumericUpDown.Value = character.LucGrowthRate;
                }
            }
        }
    }
}
