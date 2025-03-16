using Newtonsoft.Json;
using Tarrocco.MAUI.ViewModels;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Tarrocco.MAUI.AI;
using DotnetGeminiSDK.Client.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Tarrocco.MAUI.Views;

public partial class FortunePage : ContentPage
{
    FortunePageViewModel ViewModel = new FortunePageViewModel();

    public FortunePage()
    {
        InitializeComponent();
        BindingContext = ViewModel;
    }

    private async void DI_TEST(object sender, EventArgs e)
    {
        Regex questionRegex = new Regex(@"\D+\?$");
        Match match = questionRegex.Match(FortuneEntry.Text);

        if (match.Success)
        {
            Preamble.IsVisible = false;
            FortuneSummary.Opacity = 0;
            ViewModel.PickThreeCards();
            var FortuneCards = ViewModel.FortuneCards;
            var serviceProvider = App.Services.BuildServiceProvider();
            var geminiClient = serviceProvider.GetRequiredService<IGeminiClient>();
            var tarotReader = new TarotReader(geminiClient);
            FortuneSummary.Text = await tarotReader.GetFortune($"{FortuneEntry.Text} {FortuneCards[0].Name}, {FortuneCards[1].Name}, {FortuneCards[2].Name}");
            await FortuneSummary.FadeTo(1, 1000);
        }
        else
        {
            Preamble.IsVisible = true;
            ViewModel.FortuneCards.Clear();
            Preamble.Text = "Du måste ställa en fråga..";
            await Preamble.FadeTo(1, 2000);
        }
    }
}
