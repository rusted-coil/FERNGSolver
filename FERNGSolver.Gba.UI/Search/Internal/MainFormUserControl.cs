using FERNGSolver.Common.ViewContracts;
using FERNGSolver.Gba.Domain.Character;
using FERNGSolver.Gba.Domain.Character.Extensions;
using FERNGSolver.Gba.Domain.Repository.Stub;
using FERNGSolver.Gba.Domain.RNG;
using FERNGSolver.Gba.Presentation.ViewContracts;
using System.Reactive;

namespace FERNGSolver.Gba.UI.Search
{
    internal partial class MainFormUserControl : UserControl, IExtendedMainFormView
    {
        public IObservable<Unit> SearchButtonClicked => m_MainFormView.SearchButtonClicked;
        public void ShowSearchResults(Type viewModelType, IReadOnlyList<object> viewModels) => m_MainFormView.ShowSearchResults(viewModelType, viewModels);

        public bool UsesFalconKnightMethod => UsesFalconKnightMethodCheckBox.Checked;
        public string CxString => CxStringTextBox.Text;

        // 戦闘
        public bool ContainsCombat => ContainsCombatCheckBox.Checked;
        public int AttackerHitRate => (int)AttackerHitRateNumericUpDown.Value;
        public int AttackerCriticalRate => (int)AttackerCriticalRateNumericUpDown.Value;
        public int AttackerPhaseCount => DoesAttackerFollowUpAttackCheckBox.Checked ? 2 : 1;
        public bool IsAttackerDoubleAttack => IsAttackerDoubleAttackCheckBox.Checked;
        public int DefenderHitRate => (int)DefenderHitRateNumericUpDown.Value;
        public int DefenderCriticalRate => (int)DefenderCriticalRateNumericUpDown.Value;
        public int DefenderPhaseCount => DoesDefenderAttackCheckBox.Checked ? (DoesDefenderFollowUpAttackCheckBox.Checked ? 2 : 1) : 0;
        public bool IsDefenderDoubleAttack => IsDefenderDoubleAttackCheckBox.Checked;

        // レベルアップ
        public bool ContainsGrowth => ContainsGrowthCheckBox.Checked;
        public int HpGrowthRate => (int)GrowthHpRateNumericUpDown.Value;
        public int AtkGrowthRate => (int)GrowthAtkRateNumericUpDown.Value;
        public int TecGrowthRate => (int)GrowthTecRateNumericUpDown.Value;
        public int SpdGrowthRate => (int)GrowthSpdRateNumericUpDown.Value;
        public int DefGrowthRate => (int)GrowthDefRateNumericUpDown.Value;
        public int MdfGrowthRate => (int)GrowthMdfRateNumericUpDown.Value;
        public int LucGrowthRate => (int)GrowthLucRateNumericUpDown.Value;

        public IReadOnlyList<ushort> Seeds
        {
            get
            {
                var values = new ushort[3];
                //                if()
                return values;
            }
        }

        public int OffsetMin
        {
            get
            {
                if (int.TryParse(OffsetMinTextBox.Text, out var value))
                {
                    return value;
                }
                return 0;
            }
        }

        public int OffsetMax
        {
            get
            {
                if (int.TryParse(OffsetMaxTextBox.Text, out var value))
                {
                    return value;
                }
                return 0;
            }
        }

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
        }

        public void InitializeDefaults()
        {
            SetDefaultSeeds();
            OffsetMinTextBox.Text = "0";
            OffsetMaxTextBox.Text = "1000";
        }

        private void SetDefaultSeeds()
        {
            var seeds = Const.DefaultSeeds;
            Seed0TextBox.Text = seeds[0].ToString("X4");
            Seed1TextBox.Text = seeds[1].ToString("X4");
            Seed2TextBox.Text = seeds[2].ToString("X4");
        }

        private void DefaultSeedButton_Click(object sender, EventArgs e) => SetDefaultSeeds();

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
