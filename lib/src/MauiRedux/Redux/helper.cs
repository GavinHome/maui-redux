using Redux.Basic;
using Redux.framework;
using Action = Redux.Basic.Action;

namespace Redux;

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


public static class ObjectCopier
{
    ///
    /// Perform a deep Copy of the object.
    ///
    /// The type of object being copied.
    /// The object instance to copy.
    /// The copied object.
    public static T? Clone<T>(this T source)
    {
        if (!typeof(T).IsSerializable)
        {
            throw new ArgumentException("The type must be serializable.", nameof(source));
        }

        // Don't serialize a null object, simply return the default for that object
        if (Object.ReferenceEquals(source, null))
        {
            return default;
        }

        var stream = System.Text.Json.JsonSerializer.Serialize<T>(source);
        return System.Text.Json.JsonSerializer.Deserialize<T>(stream);
    }
}

