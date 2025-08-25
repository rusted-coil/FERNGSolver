using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Common.UI.Interfaces;
using FERNGSolver.Presentation.Presenter;
using System.Reactive.Disposables;

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
            var disposables = new CompositeDisposable();
            PresenterFactory.Create(form, configService).AddTo(disposables);
            form.FormClosed += (object? sender, FormClosedEventArgs e) => {
                disposables.Dispose();
            };

            // 作品個別コントロールを初期化
            var entries = new IMainFormEntry[]{
                Genealogy.UI.MainFormEntryProvider.Create(errorNotifier),
//                Thracia.UI.MainFormEntryProvider.Create(errorNotifier),
                Gba.UI.MainFormEntryProvider.Create(gbaConfigService, errorNotifier),
            };
            form.SetEntries(entries);

            form.StartPosition = FormStartPosition.CenterScreen;

            return form;
        }
    }
}
