namespace FERNGSolver.FalconKnightTool.Application
{
    public static class FalconKnightToolFactory
    {
        public static IFalconKnightTool Create()
        {
            return new Internal.FalconKnightTool();
        }
    }
}
