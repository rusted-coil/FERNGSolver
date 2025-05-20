using FERNGSolver.Presentation.Presenter;
using FERNGSolver.UI.Internal;
using FERNGSolver.Windows.Common.Interfaces;

namespace FERNGSolver.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var serializer = new Serializer();
            var errorNotifier = new ErrorNotifier();

            // コンフィグを初期化
            var configService = Application.Config.ConfigServiceFactory.Create(serializer, serializer, errorNotifier);
            var gbaConfigService = Gba.Application.Config.ConfigServiceFactory.Create(serializer, serializer, errorNotifier);

            // メインフォームを初期化
            var form = new MainForm();
            var presenter = PresenterFactory.Create(form, configService);
            form.FormClosed += (object? sender, FormClosedEventArgs e) => {
                presenter.Dispose();
            };

            // 作品個別コントロールを初期化
            var entries = new IMainFormEntry[]{
                Gba.UI.Search.MainFormEntryProvider.Create(form, gbaConfigService, errorNotifier),
//                Thracia.UI.Search.MainFormEntryProvider.Create(form, errorNotifier),
            };
            form.SetEntries(entries);

            form.StartPosition = FormStartPosition.CenterScreen;
            System.Windows.Forms.Application.Run(form);
        }
    }
}
