using FERNGSolver.Common.Application.Interfaces;
using System.Windows.Forms;

namespace FERNGSolver.Internal
{
    internal sealed class ErrorNotifier : IErrorNotifier
    {
        public void NotifyError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
