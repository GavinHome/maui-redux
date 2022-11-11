using Redux;
using Redux.Basic;
using Action = Redux.Basic.Action;

namespace example.Pages.Counter;
internal static class CounterReducer
{
    internal static Reducer<CounterState> buildReducer()
    {
        var map = new Dictionary<Object, Reducer<CounterState>>();
        map.Add(CounterAction.add, _add);
        return ReduxHelper.asReducer<CounterState>(map);
    }

    private static CounterState _add(CounterState state, Action action)
    {
        CounterState newState = state.Clone(); //clone
        newState.Count++;
        return newState;
    }
}