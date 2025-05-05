namespace FERNGSolver.Presentation.Presenter
{
    public static class PresenterFactory
    {
        public static IMainFormPresenter Create()
        {
            return new Internal.MainFormPresenter();
        }
    }
}
