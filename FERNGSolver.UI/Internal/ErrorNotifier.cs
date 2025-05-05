using FERNGSolver.Common.ViewContracts;

namespace FERNGSolver.UI.Internal
{
    internal sealed class ErrorNotifier : IErrorNotifier
    {
        public void NotifyError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
