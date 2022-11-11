using Redux.Basic;
using Redux.Component.Basic;

namespace example.Pages.Counter;
internal partial class CounterView
{
    internal static Object buildView(CounterState state, Dispatch dispatch, ViewService viewService)
    {
        return new example.Pages.Counter.View(state, dispatch, viewService);
    }
}
