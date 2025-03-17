using Tarrocco.MAUI.AI;
using Tarrocco.MAUI.Contract;
using Tarrocco.MAUI.ViewModels;

namespace Tarrocco.MAUI.Views;

public partial class FortunePage : ContentPage
{
    public static FortunePageViewModel ViewModel = new FortunePageViewModel();

    public FortunePage()
    {
        InitializeComponent();
        BindingContext = ViewModel;
    }

    private async void GetFortune_Clicked(object sender, EventArgs e)
    {
        FortuneCardCollection.IsVisible = false;
        FortuneCardCollection.Opacity = 0;
        FortuneSummary.Opacity = 0;
        ITarotReader tarotReader = new TarotReader();
        FortuneSummary.Text = await tarotReader.GetFortune(FortuneEntry.Text, FortuneCardCollection);
        await FortuneSummary.FadeTo(1, 1000);
    }
}
