using Redux.Basic;
using Redux.Component.Basic;
using Redux.Component.Context;
using Redux.Framework;

namespace Redux.Component;

public delegate T InitState<T, P>(P param);

/// Wrapper ComponentWidget if needed like KeepAlive, RepaintBoundary etc.
public delegate Widget WidgetWrapper(Widget child);

public abstract class Page<T, P> : Component<T>
{
    private InitState<T, P> _initState;
    private WidgetWrapper _wrapper;

    protected WidgetWrapper protectedWrapper => _wrapper;

    protected Page(InitState<T, P> initState, ViewBuilder<T> view, Reducer<T> reducer, Effect<T> effect) : base(view, reducer: reducer, effect: effect) => this._initState = initState;

    public Widget BuildPage(P param) => protectedWrapper(new _PageWidget<T, P>(
      page: this,
      param: param
    ));
}

public class _PageWidget<T, P> : StatefulWidget
{
    private Page<T, P> page;
    private P param;
    public _PageWidget(Page<T, P> page, P param)
    {
        this.page = page;
        this.param = param;
    }

    public override State<StatefulWidget>? createState()
    {
        return new _PageState<T, P>() as State<StatefulWidget>;
    }
}

public class _PageState<T, P> : State<_PageWidget<T, P>>
{
    private Store<T> _store;
}

