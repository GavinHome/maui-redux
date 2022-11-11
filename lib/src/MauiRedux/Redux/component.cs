using Redux.Basic;

namespace Redux.Component;

/// Seen in view-part or adapter-part
public abstract class ViewService //implements ExtraData
{
}

/// Component's view part
/// 1.State is used to decide how to render
/// 2.Dispatch is used to send actions
/// 3.ViewService is used to build sub-components or adapter.
public delegate Object ViewBuilder<T>(T state, Dispatch dispatch, ViewService viewService);


public abstract class AbstractComponent<T>
{
}

public class Component<T> : AbstractComponent<T>
{
    private ViewBuilder<T> view;
    private Reducer<T> reducer;
    private Effect<T> effect;

    public Component(ViewBuilder<T> view, Reducer<T> reducer, Effect<T> effect)
    {
        this.view = view;
        this.reducer = reducer;
        this.effect = effect;
    }
}
