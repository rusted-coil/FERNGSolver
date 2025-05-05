using FERNGSolver.Windows.Common.Interfaces;

namespace FERNGSolver.Windows.Common
{
    public class MainFormEntry : IMainFormEntry
    {
        /// <summary>
        /// タイトルを取得します。
        /// <para> * IDとしても使用するため、複数追加する場合は一意である必要があります。</para>
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// 検索条件を設定するパネルのユーザーコントロールを取得します。
        /// </summary>
        public UserControl MainFormControl { get; }

        public MainFormEntry(string title, UserControl mainFormControl)
        {
            Title = title;
            MainFormControl = mainFormControl;
        }
    }
}
