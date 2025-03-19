using Tarrocco.MAUI.Views;

namespace Tarrocco.MAUI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void CardsPage_ButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CardPage());
    }

    private async void FortunePage_ButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FortunePage());
    }
}
