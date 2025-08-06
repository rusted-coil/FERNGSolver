using FERNGSolver.Common.Presentation.Interfaces;
using FERNGSolver.Common.Presentation.ViewContracts;
using FERNGSolver.FalconKnightTool.UI;
using FERNGSolver.Gba.Application.Config;
using FERNGSolver.Gba.Application.Search.Strategy;
using FERNGSolver.Gba.Domain.Character;
using FERNGSolver.Gba.Domain.Character.Extensions;
using FERNGSolver.Gba.Domain.Combat;
using FERNGSolver.Gba.Domain.Repository.Stub;
using FERNGSolver.Gba.Presentation.FalconKnight;
using FERNGSolver.Gba.Presentation.ViewContracts;
using FERNGSolver.Gba.UI.Internal;
using FERNGSolver.Gba.UI.Search.Internal;
using FormRx.Button;
using System.Reactive;
using System.Reactive.Subjects;

namespace FERNGSolver.Gba.UI.Search
{
    internal partial class MainFormUserControl : UserControl, IExtendedMainFormView
    {
        public IObservable<Unit> SearchButtonClicked => m_MainFormView.SearchButtonClicked;
        public void ShowSearchResults(IReadOnlyList<ITableColumn> columns, Type viewModelType, IReadOnlyList<object> viewModels) => m_MainFormView.ShowSearchResults(columns, viewModelType, viewModels);
        public IObservable<Unit> AddRngViewButtonClicked => m_MainFormView.AddRngViewButtonClicked;

        public IObservable<Unit> PersistentConfigChanged => m_PersistentConfigChanged;
        Subject<Unit> m_PersistentConfigChanged = new Subject<Unit>();
        private void PersistentConfigControlValueChanged(object sender, EventArgs e) => m_PersistentConfigChanged.OnNext(Unit.Default);

        public IObservable<Unit> SearchConditionChanged => m_SearchConditionChanged;
        Subject<Unit> m_SearchConditionChanged = new Subject<Unit>();
        private void SearchConditionControlValueChanged(object? sender, EventArgs e) => m_SearchConditionChanged.OnNext(Unit.Default);

        // ファルコンナイト法
        public bool UsesFalconKnightMethod => UsesFalconKnightMethodCheckBox.Checked;
        public string CxString => CxStringTextBox.Text;
        public bool AddsCxOffset => AddsCxOffsetCheckBox.Checked;
        public IObservable<Unit> FalconKnightToolOpenButtonClicked => m_FalconKnightToolOpenButton.Clicked;

        // 戦闘
        public bool ContainsCombat => ContainsCombatCheckBox.Checked;
        public bool IsBindingBlade => IsBindingBladeRadioButton.Checked;
        public int AttackerHp => (int)AttackerHpNumericUpDown.Value;
        public int AttackerPower => (int)AttackerPowerNumericUpDown.Value;
        public int AttackerHitRate => (int)AttackerHitRateNumericUpDown.Value;
        public int AttackerCriticalRate => (int)AttackerCriticalRateNumericUpDown.Value;
        public int AttackerPhaseCount => DoesAttackerFollowUpAttackCheckBox.Checked ? 2 : 1;
        public IUnitStatusDetail AttackerStatusDetail => m_AttackerStatusDetail;
        public int DefenderHp => (int)DefenderHpNumericUpDown.Value;
        public int DefenderPower => (int)DefenderPowerNumericUpDown.Value;
        public int DefenderHitRate => (int)DefenderHitRateNumericUpDown.Value;
        public int DefenderCriticalRate => (int)DefenderCriticalRateNumericUpDown.Value;
        public int DefenderPhaseCount => DoesDefenderAttackCheckBox.Checked ? (DoesDefenderFollowUpAttackCheckBox.Checked ? 2 : 1) : 0;
        public IUnitStatusDetail DefenderStatusDetail => m_DefenderStatusDetail;

        private UnitStatusDetail m_AttackerStatusDetail = new UnitStatusDetail();
        private UnitStatusDetail m_DefenderStatusDetail = new UnitStatusDetail();

        // 戦闘事後条件
        public int AttackerHpPostconditionMin => FiltersByAttackerHpPostconditionCheckBox.Checked ? (int)AttackerHpPostconditionMinNumericUpDown.Value : 0;
        public int AttackerHpPostconditionMax => FiltersByAttackerHpPostconditionCheckBox.Checked ? (int)AttackerHpPostconditionMaxNumericUpDown.Value : 999;
        public int DefenderHpPostconditionMin => FiltersByDefenderHpPostconditionCheckBox.Checked ? (int)DefenderHpPostconditionMinNumericUpDown.Value : 0;
        public int DefenderHpPostconditionMax => FiltersByDefenderHpPostconditionCheckBox.Checked ? (int)DefenderHpPostconditionMaxNumericUpDown.Value : 999;

        // レベルアップ
        public bool ContainsGrowth => ContainsGrowthCheckBox.Checked;
        public int HpGrowthRate => (int)GrowthHpRateNumericUpDown.Value;
        public int AtkGrowthRate => (int)GrowthAtkRateNumericUpDown.Value;
        public int TecGrowthRate => (int)GrowthTecRateNumericUpDown.Value;
        public int SpdGrowthRate => (int)GrowthSpdRateNumericUpDown.Value;
        public int DefGrowthRate => (int)GrowthDefRateNumericUpDown.Value;
        public int MdfGrowthRate => (int)GrowthMdfRateNumericUpDown.Value;
        public int LucGrowthRate => (int)GrowthLucRateNumericUpDown.Value;
        public GrowthSearchType HpSearchType => IsHpGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType AtkSearchType => IsAtkGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType TecSearchType => IsTecGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType SpdSearchType => IsSpdGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType DefSearchType => IsDefGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType MdfSearchType => IsMdfGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType LucSearchType => IsLucGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;

        // 検索条件
        public int CurrentPosition => (int)CurrentRngCountNumericUpDown.Value;
        public int OffsetMin => (int)OffsetMinNumericUpDown.Value;
        public int OffsetMax => (int)OffsetMaxNumericUpDown.Value;

        // 結果出力用
        public int FalconKnightMethodMove => (int)FalconKnightConsumeMoveNumericUpDown.Value;

        private Form? m_FalconKnightToolForm = null;

        private readonly IMainFormView m_MainFormView;
        private readonly IReadOnlyList<ICharacter> m_Characters;
        private readonly IButton m_FalconKnightToolOpenButton;

        public MainFormUserControl(IMainFormView mainFormView)
        {
            m_MainFormView = mainFormView;
            InitializeComponent();

            m_FalconKnightToolOpenButton = ButtonFactory.CreateButton(FalconKnightToolOpenButton);

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

            AttackerStatusDetailLabel.Text = m_AttackerStatusDetail.ToString();
            DefenderStatusDetailLabel.Text = m_DefenderStatusDetail.ToString();

            // 検索条件にかかわるコントロールの値が変化した時、外部に通知する用のイベントハンドラを登録
            ContainsCombatCheckBox.CheckedChanged += SearchConditionControlValueChanged;
            ContainsGrowthCheckBox.CheckedChanged += SearchConditionControlValueChanged;
        }

        public void ReflectConfig(IConfig config)
        {
            IsBindingBladeRadioButton.Checked = config.IsBindingBlade;
        }

        public void InitializeDefaults()
        {
            OffsetMinNumericUpDown.Value = 0;
            OffsetMaxNumericUpDown.Value = 10000;
        }

        public void OpenFalconKnightTool()
        {
            if (m_FalconKnightToolForm != null)
            {
                m_FalconKnightToolForm.Focus();
            }
            else
            {
                m_FalconKnightToolForm = FalconKnightToolLauncher.CreateToolForm(FalconKnightToolEntryFactory.Create(MainFormEntry.Title, AddCxString));
                m_FalconKnightToolForm.FormClosed += (object? sender, FormClosedEventArgs e) => {
                    m_FalconKnightToolForm = null;
                };
                m_FalconKnightToolForm.StartPosition = FormStartPosition.CenterScreen;
                m_FalconKnightToolForm.Show();
            }
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

        private void AddCxString(string cxString) => CxStringTextBox.Text += cxString;

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

        private void AttackerStatusDetailDialogButton_Click(object sender, EventArgs e) => OpenStatusDetailDialog(m_AttackerStatusDetail, AttackerStatusDetailLabel);
        private void DefenderStatusDetailDialogButton_Click(object sender, EventArgs e) => OpenStatusDetailDialog(m_DefenderStatusDetail, DefenderStatusDetailLabel);

        private void OpenStatusDetailDialog(UnitStatusDetail targetStatus, Label targetStatusLabel)
        {
            using (var form = new UnitStatusDetailDialog(targetStatus))
            {
                form.StartPosition = FormStartPosition.CenterParent;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    form.WriteToUnitStatusDetail(targetStatus);
                    targetStatusLabel.Text = targetStatus.ToString();
                }
            }
        }
    }
}
