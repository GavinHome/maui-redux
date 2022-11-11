using Redux.Basic;
using Redux.Component.Basic;

namespace Redux.Component;
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
