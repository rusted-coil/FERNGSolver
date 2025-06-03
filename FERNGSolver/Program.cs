using FERNGSolver.UI;

namespace FERNGSolver
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var serializer = new Internal.Serializer();
            var errorNotifier = new Internal.ErrorNotifier();

            var form = FormLauncher.Create(serializer, serializer, errorNotifier);
            System.Windows.Forms.Application.Run(form);
        }
    }
}
