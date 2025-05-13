using FERNGSolver.Presentation.Presenter;

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
            form.SetEntries(
                Gba.UI.Search.MainFormEntryProvider.Create(form, errorNotifier),
                Thracia.UI.Search.MainFormEntryProvider.Create(form, errorNotifier));

            Application.Run(form);
        }
    }
}
