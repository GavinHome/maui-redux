using Redux.Basic;
using Redux.Component;
using Action = Redux.Basic.Action;

namespace example.Pages.Counter;
internal partial class CounterView
{
    internal static Object buildView(CounterState state, Dispatch dispatch, ViewService viewService)
    {
        return new example.Pages.Counter.View(state, dispatch, viewService);
    }
}
