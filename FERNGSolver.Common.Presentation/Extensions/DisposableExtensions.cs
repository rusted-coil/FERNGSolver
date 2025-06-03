namespace FERNGSolver.Common.Presentation.Extensions
{
    public static class DisposableExtensions
    {
        public static void AddTo(this IDisposable disposable, ICollection<IDisposable> collection)
        { 
            collection.Add(disposable);
        }
    }
}
