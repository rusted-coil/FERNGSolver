using System.Reflection;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using FERNGSolver.Common.Application.Interfaces;

namespace FERNGSolver.Presentation.Tests;

// Exercise the public presenter contracts while recording their UI output.
public class CaptureView : DispatchProxy, IDisposable
{
    public Dictionary<string, object?> Values { get; } = new();
    public Subject<Unit> SearchClicked { get; } = new();
    public Subject<Unit> ConditionChanged { get; } = new();
    public IReadOnlyList<object> Rows { get; private set; } = Array.Empty<object>();
    public Type? RowType { get; private set; }
    public int TotalCount { get; private set; }

    public static T Create<T>(out CaptureView capture) where T : class
    {
        var view = Create<T, CaptureView>();
        capture = (CaptureView)(object)view;
        return view;
    }

    protected override object? Invoke(MethodInfo? method, object?[]? args)
    {
        switch (method!.Name)
        {
            case "get_SearchButtonClicked": return SearchClicked;
            case "get_SearchConditionChanged": return ConditionChanged;
            case "ShowSearchResults":
                RowType = (Type)args![1]!;
                Rows = (IReadOnlyList<object>)args[2]!;
                TotalCount = (int?)args[3] ?? Rows.Count;
                return null;
        }
        if (method.Name.StartsWith("get_") && Values.TryGetValue(method.Name[4..], out var value))
            return value;
        if (method.ReturnType == typeof(IObservable<Unit>)) return Observable.Never<Unit>();
        if (method.ReturnType == typeof(string)) return string.Empty;
        return method.ReturnType.IsValueType && method.ReturnType != typeof(void)
            ? Activator.CreateInstance(method.ReturnType) : null;
    }

    public void Dispose()
    {
        SearchClicked.Dispose();
        ConditionChanged.Dispose();
    }
}

internal sealed class ErrorNotifier : IErrorNotifier
{
    public List<string> Messages { get; } = new();
    public void NotifyError(string message) => Messages.Add(message);
}
