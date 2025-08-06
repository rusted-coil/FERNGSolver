using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.UI.Interfaces;

namespace FERNGSolver.Thracia.UI
{
    public static class MainFormEntryProvider
    {
        public static IMainFormEntry Create(IErrorNotifier errorNotifier)
        {
            return new Internal.MainFormEntry(errorNotifier);
        }
    }
}
