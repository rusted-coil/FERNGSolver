using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.UI.Interfaces;
using FERNGSolver.Gba.Application.Config;
using FERNGSolver.Gba.Domain.Repository.Stub;

namespace FERNGSolver.Gba.UI
{
    public static class MainFormEntryProvider
    {
        public static IMainFormEntry CreateBindingBlade(IConfigService configService, IErrorNotifier errorNotifier)
        {
            return new Internal.MainFormEntry(Titles.Title.BindingBlade, new StubBindingBladeCharacterRepository(), configService, errorNotifier);
        }

        public static IMainFormEntry CreateBlazingBlade(IConfigService configService, IErrorNotifier errorNotifier)
        {
            return new Internal.MainFormEntry(Titles.Title.BlazingBlade, new StubBlazingBladeCharacterRepository(), configService, errorNotifier);
        }

        public static IMainFormEntry CreateSacredStones(IConfigService configService, IErrorNotifier errorNotifier)
        {
            return new Internal.MainFormEntry(Titles.Title.SacredStones, new StubSacredStonesCharacterRepository(), configService, errorNotifier);
        }
    }
}
