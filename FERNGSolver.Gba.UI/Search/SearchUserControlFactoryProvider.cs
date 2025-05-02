using FERNGSolver.Common.Interfaces;

namespace FERNGSolver.Gba.UI.Search
{
    public static class SearchUserControlFactoryProvider
    {
        public static IUserControlFactory CreateFalconKnightToolSearchConditionUserControlFactory()
        {
            return new Internal.FalconKnightToolSearchConditionUserControlFactory();
        }
    }
}
