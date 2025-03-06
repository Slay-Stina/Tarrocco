using System.Diagnostics;
using Tarrocco.MAUI.ViewModels;
using Tarrocco.MAUI.Views;

namespace Tarrocco.MAUI;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

    private async void CardsPage_ButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///CardPage");
    }
}
