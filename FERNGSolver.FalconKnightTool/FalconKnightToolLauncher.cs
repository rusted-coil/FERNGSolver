using FERNGSolver.FalconKnightTool.Presentation.Presenter;

namespace FERNGSolver.FalconKnightTool.UI
{
    public static class FalconKnightToolLauncher
    {
        public static Form CreateToolForm()
        {
            var form = new FalconKnightToolForm();
            var presenter = PresenterFactory.Create(form);
            return form;
        }
    }
}
