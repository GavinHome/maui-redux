namespace Redux.Component;

public enum Lifecycle
{
    /// componenmt(page) or adapter receives the following events
    initState,
    didChangeDependencies,
    build,
    reassemble,
    didUpdateWidget,
    deactivate,
    dispose,
    // didDisposed,

    /// Only a adapter mixin VisibleChangeMixin will receive appear & disappear events.
    /// class MyAdapter extends Adapter<T> with VisibleChangeMixin<T> {
    ///   MyAdapter():super(
    ///     ///
    ///   );
    /// }
    appear,
    disappear,

    /// Only a componenmt(page) or adapter mixin WidgetsBindingObserverMixin will receive didChangeAppLifecycleState event.
    /// class MyComponent extends Component<T> with WidgetsBindingObserverMixin<T> {
    ///   MyComponent():super(
    ///     ///
    ///   );
    /// }
    didChangeAppLifecycleState,
}