using Redux.Basic;
using Redux.Component;
using Redux.Component.Basic;
using Redux.Utils;
using Action = Redux.Basic.Action;

namespace example.Pages.Counter;
internal class CounterEffect
{
    internal static Effect<CounterState> buildEffect()
    {
        var map = new Dictionary<object, SubEffect<CounterState>>();
        map.Add(CounterAction.onAdd, _onAdd);
        return ReduxHelper.combineEffects(map);
    }

    private static async Task _onAdd(Action action, Context<CounterState> ctx)
    {
        await ctx.dispatch(CounterActionCreator.add());
    }
}