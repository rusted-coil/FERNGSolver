using FERNGSolver.Common.Interfaces;
using FERNGSolver.FalconKnightTool.Common.Interfaces;
using FERNGSolver.FalconKnightTool.Presentation.Presenter;

namespace FERNGSolver.FalconKnightTool.UI
{
    public static class FalconKnightToolLauncher
    {
        public static Form CreateToolForm(UserControl searchConditionControl, IFalconKnightToolSearchStrategy searchStrategy)
        {
            var form = new Internal.FalconKnightToolForm(searchConditionControl);
            var presenter = PresenterFactory.Create(form, searchStrategy);

            // フォームを閉じた時にpresenterをdispose
            form.FormClosed += (object? sender, FormClosedEventArgs e) => {
                presenter.Dispose();
            };

            return form;
        }
    }
}
