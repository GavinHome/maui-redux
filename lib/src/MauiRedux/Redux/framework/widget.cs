using Redux.Component.Context;
using Redux.Framework;

namespace Redux.Framework;

public abstract class Widget : object //Microsoft.Maui.Controls.ContentPage
{
}

public abstract class StatefulWidget : Widget
{
    /// Initializes [key] for subclasses.
    public StatefulWidget() : base() { }

    public abstract State<StatefulWidget>? createState();
}

public abstract class StatelessWidget : Widget
{
    /// Initializes [key] for subclasses.
    public StatelessWidget() : base() { }

    protected abstract Widget Build(BuildContext context);
}

