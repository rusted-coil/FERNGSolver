using FERNGSolver.Common.Interfaces;
using FERNGSolver.FalconKnightTool.Presentation.Presenter;

namespace FERNGSolver.FalconKnightTool.UI
{
    public static class FalconKnightToolLauncher
    {
        public static Form CreateToolForm(IUserControlFactory searchConditionUserControlFactory)
        {
            var form = new Internal.FalconKnightToolForm(searchConditionUserControlFactory);
            var presenter = PresenterFactory.Create(form);

            // フォームを閉じた時にpresenterをdispose
            form.FormClosed += (object? sender, FormClosedEventArgs e) => {
                presenter.Dispose();
            };

            return form;
        }
    }
}
