namespace FERNGSolver.Gba.UI
{
    internal static class Titles
    {
        public enum Title
        {
            BindingBlade,
            BlazingBlade,
            SacredStones,
        }

        public static string ConvertToString(this Title title)
        {
            return title switch
            {
                Title.BindingBlade => "封印の剣",
                Title.BlazingBlade => "烈火の剣",
                Title.SacredStones => "聖魔の光石",
                _ => throw new ArgumentOutOfRangeException(nameof(title), title, null)
            };
        }
    }
}
