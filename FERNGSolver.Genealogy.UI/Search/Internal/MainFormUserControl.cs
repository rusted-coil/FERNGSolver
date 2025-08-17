using FERNGSolver.Common.Presentation.Interfaces;
using FERNGSolver.Common.Presentation.ViewContracts;
using FERNGSolver.Genealogy.Application.Search.Strategy;
using FERNGSolver.Genealogy.Domain.Character;
using FERNGSolver.Genealogy.Domain.Character.Extensions;
using FERNGSolver.Genealogy.Domain.Combat;
using FERNGSolver.Genealogy.Domain.Repository.Stub;
using FERNGSolver.Genealogy.Presentation.ViewContracts;
using FERNGSolver.Genealogy.UI.Search.Internal;
using System.Reactive;
using System.Reactive.Subjects;

namespace FERNGSolver.Genealogy.UI.Search
{
    internal partial class MainFormUserControl : UserControl, IExtendedMainFormView
    {
        public IObservable<Unit> SearchButtonClicked => m_MainFormView.SearchButtonClicked;
        public void ShowSearchResults(IReadOnlyList<ITableColumn> columns, Type viewModelType, IReadOnlyList<object> viewModels) => m_MainFormView.ShowSearchResults(columns, viewModelType, viewModels);
        public IObservable<Unit> AddRngViewButtonClicked => m_MainFormView.AddRngViewButtonClicked;
        public IObservable<IEnumerable<object>> AddRngViewRequestedFromSearchResults => m_MainFormView.AddRngViewRequestedFromSearchResults;

        public IObservable<Unit> PersistentConfigChanged => m_PersistentConfigChanged;
        Subject<Unit> m_PersistentConfigChanged = new Subject<Unit>();
        private void PersistentConfigControlValueChanged(object sender, EventArgs e) => m_PersistentConfigChanged.OnNext(Unit.Default);

        public IObservable<Unit> SearchConditionChanged => m_SearchConditionChanged;
        Subject<Unit> m_SearchConditionChanged = new Subject<Unit>();
        private void SearchConditionControlValueChanged(object? sender, EventArgs e) => m_SearchConditionChanged.OnNext(Unit.Default);
        private void CombatConditionControlValueChanged(object? sender, EventArgs e)
        {
            // 「戦闘を行う」にチェックが入っている時のみ条件が変化したものとして通知を行う
            if (ContainsCombatCheckBox.Checked)
            {
                m_SearchConditionChanged.OnNext(Unit.Default);
            }
        }
        private void GrowthConditionControlValueChanged(object? sender, EventArgs e)
        {
            // 「レベルアップ」にチェックが入っている時のみ条件が変化したものとして通知を行う
            if (ContainsGrowthCheckBox.Checked)
            {
                m_SearchConditionChanged.OnNext(Unit.Default);
            }
        }

        // 戦闘
        public bool ContainsCombat => ContainsCombatCheckBox.Checked;
        public int AttackerHp => (int)AttackerHpNumericUpDown.Value;
        public int AttackerAtk => (int)AttackerAtkNumericUpDown.Value;
        public int AttackerDef => (int)AttackerDefNumericUpDown.Value;
        public int AttackerHitRate => (int)AttackerHitRateNumericUpDown.Value;
        public int AttackerCriticalRate => 0;
        public int AttackerPhaseCount => DoesAttackerFollowUpAttackCheckBox.Checked ? 2 : 1;
        public IUnitStatusDetail AttackerStatusDetail => m_AttackerStatusDetail;
        public int DefenderHp => (int)DefenderHpNumericUpDown.Value;
        public int DefenderAtk => (int)DefenderAtkNumericUpDown.Value;
        public int DefenderDef => (int)DefenderDefNumericUpDown.Value;
        public int DefenderHitRate => (int)DefenderHitRateNumericUpDown.Value;
        public int DefenderCriticalRate => 0;
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
        public int HpGrowthRate => (int)HpGrowthRateNumericUpDown.Value;
        public int StrGrowthRate => (int)StrGrowthRateNumericUpDown.Value;
        public int MgcGrowthRate => (int)MgcGrowthRateNumericUpDown.Value;
        public int DefGrowthRate => (int)DefGrowthRateNumericUpDown.Value;
        public int TecGrowthRate => (int)TecGrowthRateNumericUpDown.Value;
        public int SpdGrowthRate => (int)SpdGrowthRateNumericUpDown.Value;
        public int LucGrowthRate => (int)LucGrowthRateNumericUpDown.Value;
        public int MdfGrowthRate => (int)MdfGrowthRateNumericUpDown.Value;
        public GrowthSearchType HpSearchType => IsHpGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType StrSearchType => IsStrGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType MgcSearchType => IsMgcGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType DefSearchType => IsDefGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType TecSearchType => IsTecGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType SpdSearchType => IsSpdGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType LucSearchType => IsLucGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;
        public GrowthSearchType MdfSearchType => IsMdfGrowthNeeded.Checked ? GrowthSearchType.MustUp : GrowthSearchType.NotConsidered;

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

            // 固定値で十分なのでStubクラスを使う
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

            #region 検索条件にかかわるコントロールの値が変化した時、外部に通知する用のイベントハンドラを登録

            ContainsCombatCheckBox.CheckedChanged += SearchConditionControlValueChanged;

            AttackerHpNumericUpDown.ValueChanged += CombatConditionControlValueChanged;
            AttackerAtkNumericUpDown.ValueChanged += CombatConditionControlValueChanged;
            AttackerDefNumericUpDown.ValueChanged += CombatConditionControlValueChanged;
            AttackerHitRateNumericUpDown.ValueChanged += CombatConditionControlValueChanged;
            DoesAttackerFollowUpAttackCheckBox.CheckedChanged += CombatConditionControlValueChanged;

            DefenderHpNumericUpDown.ValueChanged += CombatConditionControlValueChanged;
            DefenderAtkNumericUpDown.ValueChanged += CombatConditionControlValueChanged;
            DefenderDefNumericUpDown.ValueChanged += CombatConditionControlValueChanged;
            DefenderHitRateNumericUpDown.ValueChanged += CombatConditionControlValueChanged;
            DoesDefenderAttackCheckBox.CheckedChanged += CombatConditionControlValueChanged;
            DoesDefenderFollowUpAttackCheckBox.CheckedChanged += CombatConditionControlValueChanged;

            ContainsGrowthCheckBox.CheckedChanged += SearchConditionControlValueChanged;

            HpGrowthRateNumericUpDown.ValueChanged += GrowthConditionControlValueChanged;
            StrGrowthRateNumericUpDown.ValueChanged += GrowthConditionControlValueChanged;
            MgcGrowthRateNumericUpDown.ValueChanged += GrowthConditionControlValueChanged;
            DefGrowthRateNumericUpDown.ValueChanged += GrowthConditionControlValueChanged;
            TecGrowthRateNumericUpDown.ValueChanged += GrowthConditionControlValueChanged;
            SpdGrowthRateNumericUpDown.ValueChanged += GrowthConditionControlValueChanged;
            LucGrowthRateNumericUpDown.ValueChanged += GrowthConditionControlValueChanged;
            MdfGrowthRateNumericUpDown.ValueChanged += GrowthConditionControlValueChanged;

            #endregion
        }

        public void InitializeDefaults()
        {
            OffsetMinNumericUpDown.Value = 0;
            OffsetMaxNumericUpDown.Value = 10000;
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
                    HpGrowthRateNumericUpDown.Value = character.HpGrowthRate;
                    StrGrowthRateNumericUpDown.Value = character.StrGrowthRate;
                    MgcGrowthRateNumericUpDown.Value = character.MgcGrowthRate;
                    DefGrowthRateNumericUpDown.Value = character.DefGrowthRate;
                    TecGrowthRateNumericUpDown.Value = character.TecGrowthRate;
                    SpdGrowthRateNumericUpDown.Value = character.SpdGrowthRate;
                    LucGrowthRateNumericUpDown.Value = character.LucGrowthRate;
                    MdfGrowthRateNumericUpDown.Value = character.MdfGrowthRate;
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

                    // 「戦闘を行う」にチェックが入っている時のみ条件が変化したものとして通知を行う
                    if (ContainsCombatCheckBox.Checked)
                    {
                        m_SearchConditionChanged.OnNext(Unit.Default);
                    }
                }
            }
        }
    }
}
