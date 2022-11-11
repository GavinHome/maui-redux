namespace Redux.Utils;

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

