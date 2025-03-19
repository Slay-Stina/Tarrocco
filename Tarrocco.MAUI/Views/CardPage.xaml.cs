using System.Dynamic;
using Tarrocco.MAUI.ViewModels;

namespace Tarrocco.MAUI.Views;

public partial class CardPage : ContentPage
{
    public CardPage()
    {
        InitializeComponent();
        BindingContext = new CardPageViewModel();
    }

    private void OnCardTapped(object sender, TappedEventArgs e)
    {
        var image = (Image)sender;
        var parentGrid = (Grid)image.Parent;
        var cardInfoLayout = (VerticalStackLayout)parentGrid.FindByName("CardInfoLayout");

        cardInfoLayout.IsVisible = !cardInfoLayout.IsVisible;
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}