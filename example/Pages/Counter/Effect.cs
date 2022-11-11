using Redux;
using Redux.Basic;
using Action = Redux.Basic.Action;

namespace example.Pages.Counter;
internal class CounterEffect
{
    internal static Effect<CounterState> buildEffect()
    {
        var map = new Dictionary<object, SubEffect<CounterState>>();
        ////map.Add(Lifecycle.initState, _init);
        map.Add(CounterAction.onAdd, _onAdd);
        return ReduxHelper.combineEffects(map);
    }

    ////private async Task _init(Action action, Context<HomeState> ctx)
    ////{
    ////    ctx.dispatch(CounterActionCreator.initData());
    ////}

    private static async Task _onAdd(Action action, Context<CounterState> ctx)
    {
        await ctx.dispatch(CounterActionCreator.add());
    }
}