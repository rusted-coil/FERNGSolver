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

            // 作品個別コントロールを初期化
            form.SetEntries(
                Gba.UI.Search.MainFormEntryProvider.Create(form, new UI.Internal.ErrorNotifier()));

            Application.Run(form);
        }
    }
}
