using Redux.Component;
using Redux.Framework;

namespace Redux.PageRoutes;

public abstract class AbstractRoutes
{
    public abstract Widget BuildPage(string path, dynamic arguments);
}

/// Each page has a unique store.
public class PageRoutes : AbstractRoutes
{
    private readonly IDictionary<String, Page<Object, dynamic>> pages;

    public PageRoutes(
        IDictionary<String, Page<Object, dynamic>> pages,
        System.Action<String, Page<Object, dynamic>> visitor)
    {
        if (visitor != null)
        {
            foreach (var kv in pages)
            {
                visitor(kv.Key, kv.Value);
            }
        }
    }

    public override Widget BuildPage(string path, dynamic arguments) => pages[path]?.BuildPage(arguments);
}
