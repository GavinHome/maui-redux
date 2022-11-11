using Redux;
using Redux.Basic;
using Redux.Component;
using System.Windows.Input;

namespace example.Pages.Counter;

public partial class View : ContentPage
{
    private CounterState State { get; set; }
    public ICommand OnCounterCommand { private set; get; }

    public View(CounterState state, Dispatch dispatch, ViewService viewService)
    {
        State = state;
        OnCounterCommand = new Command(execute: () =>
        {
            dispatch(CounterActionCreator.onAdd());
        });

        InitializeComponent();
    }
}