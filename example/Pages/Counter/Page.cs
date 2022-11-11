using Redux.Basic;
using Redux.Component;
using Action = Redux.Basic.Action;

namespace example.Pages.Counter;
internal class CounterPage : Page<CounterState, Dictionary<string, dynamic>>
{
    internal CounterPage() : base(
              initState: CounterState.initState,
              view: CounterView.buildView,
              effect: CounterEffect.buildEffect(),
              reducer: CounterReducer.buildReducer()
        )
    { }
}
