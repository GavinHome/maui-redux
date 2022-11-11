using Redux.Basic;
namespace Redux.Component;

public delegate T InitState<T, P>(P param);

public abstract class Page<T, P> : Component<T>
{
    private InitState<T, P> _initState;

    protected Page(InitState<T, P> initState, ViewBuilder<T> view, Reducer<T> reducer, Effect<T> effect) : base(view, reducer: reducer, effect: effect)
    {
        this._initState = initState;

    }
}
