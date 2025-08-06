using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.UI.Interfaces;
using FERNGSolver.Gba.Application.Config;

namespace FERNGSolver.Gba.UI
{
    public static class MainFormEntryProvider
    {
        public static IMainFormEntry Create(IConfigService configService, IErrorNotifier errorNotifier)
        {
            return new Internal.MainFormEntry(configService, errorNotifier);
        }
    }
}
