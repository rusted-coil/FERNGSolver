using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.UI.Interfaces;
using FERNGSolver.Presentation.Presenter;

namespace FERNGSolver.UI
{
    /// <summary>
    /// メインのフォームを起動するためのクラスです。
    /// </summary>
    public static class FormLauncher
    {
        public static Form Create(ISerializer serializer, IDeserializer deserializer, IErrorNotifier errorNotifier)
        {
            // コンフィグを初期化
            var configService = Application.Config.ConfigServiceFactory.Create(serializer, deserializer, errorNotifier);
            var gbaConfigService = Gba.Application.Config.ConfigServiceFactory.Create(serializer, deserializer, errorNotifier);

            // メインフォームを初期化
            var form = new Internal.MainForm();
            var presenter = PresenterFactory.Create(form, configService);
            form.FormClosed += (object? sender, FormClosedEventArgs e) => {
                presenter.Dispose();
            };

            // 作品個別コントロールを初期化
            var entries = new IMainFormEntry[]{
                Gba.UI.Search.MainFormEntryProvider.Create(form, gbaConfigService, errorNotifier),
                Thracia.UI.Search.MainFormEntryProvider.Create(form, errorNotifier),
            };
            form.SetEntries(entries);

            form.StartPosition = FormStartPosition.CenterScreen;

            return form;
        }
    }
}
