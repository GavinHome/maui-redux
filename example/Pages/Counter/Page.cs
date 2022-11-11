using Redux.Basic;
using Redux.Component;
using Action = Redux.Basic.Action;

namespace example.Pages.Counter;
public class CounterPage : Page<CounterState, Dictionary<string, dynamic>>
{
    public CounterPage() : base(
              initState: CounterState.initState,
              view: CounterView.buildView,
              effect: CounterEffect.buildEffect(),
              reducer: CounterReducer.buildReducer()
        )
    { }
}
