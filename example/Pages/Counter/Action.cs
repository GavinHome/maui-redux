using Redux.Basic;
using Action = Redux.Basic.Action;

namespace example.Pages.Counter;

internal enum CounterAction
{
    add,
    onAdd,
}

internal class CounterActionCreator
{


    internal static Action add()
    {
        return new Action(CounterAction.add);
    }

    internal static Action onAdd()
    {
        return new Action(CounterAction.onAdd);
    }
}