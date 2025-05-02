namespace FERNGSolver.FalconKnightTool.Application.Path
{
    public static class CxStringConverter
    {
        /// <summary>
        /// cx列からDomain側で使うためのbool列に変換します。
        /// </summary>
        public static IReadOnlyList<bool> CxStringToBools(string cxString)
        {
            return cxString.Select(c => c switch
            {
                'c' => true,
                'x' => false,
                _ => throw new ArgumentException($"Invalid char: {c}")
            }).ToArray();
        }
    }
}
