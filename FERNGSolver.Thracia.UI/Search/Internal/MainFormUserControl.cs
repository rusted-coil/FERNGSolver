using FERNGSolver.Common.Presentation.Interfaces;
using FERNGSolver.Common.Presentation.ViewContracts;
using FERNGSolver.Thracia.Presentation.ViewContracts;
using System.Reactive;

namespace FERNGSolver.Thracia.UI.Search.Internal
{
    internal partial class MainFormUserControl : UserControl, IExtendedMainFormView
    {
        public IObservable<Unit> SearchButtonClicked => m_MainFormView.SearchButtonClicked;
        public void ShowSearchResults(IReadOnlyList<ITableColumn> columns, Type viewModelType, IReadOnlyList<object> viewModels) => m_MainFormView.ShowSearchResults(columns, viewModelType, viewModels);
        public IObservable<Unit> AddRngViewButtonClicked => m_MainFormView.AddRngViewButtonClicked;

        // ファルコンナイト法
        public bool UsesFalconKnightMethod => UsesFalconKnightMethodCheckBox.Checked;
        public string CxString => CxStringTextBox.Text;

        // 戦闘
        public bool ContainsCombat => false;

        // レベルアップ
        public bool ContainsGrowth => false;

        // 検索条件
        public int? SearchTableIndex => IsSpecificTableCheckBox.Checked ? (int)TableIndexNumericUpDown.Value : null;
        public int OffsetMin => (int)OffsetMinNumericUpDown.Value;
        public int OffsetMax => (int)OffsetMaxNumericUpDown.Value;

        private readonly IMainFormView m_MainFormView;

        public MainFormUserControl(IMainFormView mainFormView)
        {
            m_MainFormView = mainFormView;
            InitializeComponent();
        }
    }
}
