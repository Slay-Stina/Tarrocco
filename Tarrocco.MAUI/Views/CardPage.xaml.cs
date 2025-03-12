using System.Threading.Tasks;
using Tarrocco.MAUI.ViewModels;

namespace Tarrocco.MAUI.Views;

public partial class CardPage : ContentPage
{
    static CardPageViewModel cardPageViewModel = CardPageViewModel.CPVM();

	public CardPage()
	{
		InitializeComponent();
        BindingContext = cardPageViewModel;
	}

    private void OnCardTapped(object sender, TappedEventArgs e)
    {

    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}