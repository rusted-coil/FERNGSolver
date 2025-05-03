using FERNGSolver.FalconKnightTool.Presentation.Presenter;
using FERNGSolver.FalconKnightTool.Windows.Common.Interfaces;

namespace FERNGSolver.FalconKnightTool.UI
{
    public static class FalconKnightToolLauncher
    {
        public static Form CreateToolForm(params IFalconKnightToolEntry[] entries)
        {
            var form = new Internal.FalconKnightToolForm(entries);
            var presenter = PresenterFactory.Create(form, entries);

            // フォームを閉じた時にpresenterをdispose
            form.FormClosed += (object? sender, FormClosedEventArgs e) => {
                presenter.Dispose();
            };

            return form;
        }
    }
}
