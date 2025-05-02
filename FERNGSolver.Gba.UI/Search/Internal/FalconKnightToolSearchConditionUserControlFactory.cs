using FERNGSolver.Common.Interfaces;

namespace FERNGSolver.Gba.UI.Search.Internal
{
    internal sealed class FalconKnightToolSearchConditionUserControlFactory : IUserControlFactory
    {
        public UserControl Create()
        {
            return new FalconKnightToolSearchConditionUserControl();
        }
    }
}
