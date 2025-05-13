using FERNGSolver.Common.Interfaces;
using FERNGSolver.Common.ViewContracts;
using FERNGSolver.Thracia.Presentation.ViewContracts;
using System.Reactive;

namespace FERNGSolver.Thracia.UI.Search.Internal
{
    internal partial class MainFormUserControl : UserControl, IExtendedMainFormView
    {
        public IObservable<Unit> GetSearchButtonClicked(string title) => m_MainFormView.GetSearchButtonClicked(title);
        public void ShowSearchResults(IReadOnlyList<ITableColumn> columns, Type viewModelType, IReadOnlyList<object> viewModels) => m_MainFormView.ShowSearchResults(columns, viewModelType, viewModels);

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
