using Newtonsoft.Json;
using Tarrocco.MAUI.ViewModels;
using Tarrocco.MAUI.Data;
using System.Diagnostics;
using Tarrocco.MAUI.Models;
using System.Text.RegularExpressions;

namespace Tarrocco.MAUI.Views;

public partial class FortunePage : ContentPage
{
    FortunePageViewModel ViewModel = new FortunePageViewModel();
    TarotReadingResponse TarotReadingResponse;

    public FortunePage()
    {
        InitializeComponent();
        BindingContext = ViewModel;
    }

    private async void TestAI_ButtonClicked(object sender, EventArgs e)
    {
        List<Label> FortuneLabels = new List<Label>
        {Preamble, CardOneFortune, CardTwoFortune, CardThreeFortune, FortuneSummary };
        foreach (var label in FortuneLabels)
        {
            label.Opacity = 0;
        }

        Regex questionRegex = new Regex(@"\D+\?$");
        
        Match match = questionRegex.Match(FortuneEntry.Text);



        if (match.Success)
        {
            ViewModel.PickThreeCards();
            var FortuneCards = ViewModel.FortuneCards;
            var responseTask = Gemini.GetGeminiResponse(new Gemini(FortuneCards[0].Name, FortuneCards[1].Name, FortuneCards[2].Name, FortuneEntry.Text));
            TarotReadingResponse = await responseTask;
            Preamble.Text = TarotReadingResponse.MysticPreamble;
            CardOneFortune.Text = TarotReadingResponse.CardOneDescription;
            CardTwoFortune.Text = TarotReadingResponse.CardTwoDescription;
            CardThreeFortune.Text = TarotReadingResponse.CardThreeDescription;
            FortuneSummary.Text = TarotReadingResponse.Conclution;

            foreach(var label in FortuneLabels)
            {
                //await Task.Delay(1000);
                await label.FadeTo(1, 2000);
            }
        }
        else
        {
            ViewModel.FortuneCards.Clear();
            Preamble.Text = "Du måste ställa en fråga..";
            await Preamble.FadeTo(1, 2000);
        }
    }
}
