using Redux.Basic;
using Redux.Component.Context;
using Action = Redux.Basic.Action;

namespace Redux.Component.Basic;

/// Component's view part
/// 1.State is used to decide how to render
/// 2.Dispatch is used to send actions
/// 3.ViewService is used to build sub-components or adapter.
public delegate Object ViewBuilder<T>(T state, Dispatch dispatch, ViewService viewService);


/// Interrupt if not null not false
/// bool for sync-functions, interrupted if true
/// Future<void> for async-functions, should always be interrupted.
public delegate dynamic Effect<T>(Action action, Context<T> ctx);

public abstract class ExtraData {
  /// Get|Set extra data in context if needed.
  public IDictionary<String, Object>? Extra {get; }
}

/// Seen in view-part or adapter-part
public abstract class ViewService: ExtraData //implements ExtraData
{
  /// Get BuildContext from the host-widget
  public BuildContext? Context {get;}
}

///  Seen in effect-part
public abstract class Context<T> //extends AutoDispose implements ExtraData 
{
    /// Get the latest state
    public T? state { get; }

    /// The way to send action, which will be consumed by self, or by broadcast-module and store.
    public abstract Task<dynamic> dispatch(Action action);

    /// Get BuildContext from the host-widget
    public BuildContext? context { get; }
}
