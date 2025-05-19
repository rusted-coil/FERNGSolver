using FERNGSolver.Presentation.Presenter;
using FERNGSolver.Windows.Common.Interfaces;

namespace FERNGSolver
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var form = new MainForm();
            var presenter = PresenterFactory.Create();

            // フォームを閉じた時にpresenterをdispose
            form.FormClosed += (object? sender, FormClosedEventArgs e) => {
                presenter.Dispose();
            };

            var errorNotifier = new UI.Internal.ErrorNotifier();

            // 作品個別コントロールを初期化
            var entries = new IMainFormEntry[]{
                Gba.UI.Search.MainFormEntryProvider.Create(form, errorNotifier),
//                Thracia.UI.Search.MainFormEntryProvider.Create(form, errorNotifier),
            };
            form.SetEntries(entries);

            form.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(form);
        }
    }
}
