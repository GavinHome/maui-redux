namespace example.Pages.Counter;
public class CounterState
{
    public int Count { get; set; } = 0;
    public string ClickedText => $"Clicked {Count} time{(Count == 0 ? "Click me" : (Count == 1 ? string.Empty : "s"))}";

    internal static CounterState initState(Dictionary<string, dynamic> args)
    {
        return new CounterState();
    }
}
