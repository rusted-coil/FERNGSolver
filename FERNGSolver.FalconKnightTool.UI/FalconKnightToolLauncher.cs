using FERNGSolver.FalconKnightTool.Presentation.Presenter;
using FERNGSolver.FalconKnightTool.Presentation.ViewContracts;

namespace FERNGSolver.FalconKnightTool.UI
{
    public static class FalconKnightToolLauncher
    {
        public static Form CreateToolForm(IFalconKnightToolEntry entry)
        {
            var form = new Internal.FalconKnightToolForm(entry.Title);
            var presenter = PresenterFactory.Create(form, entry);

            // フォームを閉じた時にpresenterをdispose
            form.FormClosed += (object? sender, FormClosedEventArgs e) => {
                presenter.Dispose();
            };

            return form;
        }
    }
}
