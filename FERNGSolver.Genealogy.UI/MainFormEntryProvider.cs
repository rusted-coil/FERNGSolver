using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.UI.Interfaces;

namespace FERNGSolver.Genealogy.UI
{
    public static class MainFormEntryProvider
    {
        public static IMainFormEntry Create(IErrorNotifier errorNotifier)
        {
            return new Internal.MainFormEntry(errorNotifier);
        }
    }
}
