using Redux.Basic;
using Redux.Component.Basic;
using Action = Redux.Basic.Action;

namespace Redux.Component;

public delegate Task SubEffect<T>(Action action, Context<T> ctx);

public static class ReduxHelper
{
    public static Reducer<T>? asReducer<T>(Dictionary<object, Reducer<T>> map)
    {
        if (map == null || !map.Any())
        {
            return null;
        }
        else
        {
            return (T state, Action action) =>
            {
                var fn = map.FirstOrDefault(entry => action.Type == entry.Key).Value;
                if (fn != null) { return fn(state, action); }
                else return state;
            };
        }
    }

    readonly static Object _SUB_EFFECT_RETURN_NULL = new Object();

    ///// for action.type which override it's == operator
    //// return [UserEffecr]
    public static Effect<T>? combineEffects<T>(Dictionary<object, SubEffect<T>> map) => (map == null || !map.Any())
        ? null : (Action action, Context<T> ctx) =>
        {
            SubEffect<T> subEffect = map.FirstOrDefault(entry => action.Type == entry.Key).Value;
            if (subEffect != null)
            {
                return subEffect.Invoke(action, ctx) ?? _SUB_EFFECT_RETURN_NULL;
            }

            ////kip-lifecycle-actions
            if (action.Type is Lifecycle)
            {
                return _SUB_EFFECT_RETURN_NULL;
            }

            ////no subEffect
            return null;
        };
}
