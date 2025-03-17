using DotnetGeminiSDK.Client.Interfaces;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Tarrocco.MAUI.Contract;
using Tarrocco.MAUI.Models;
using Tarrocco.MAUI.ViewModels;
using Tarrocco.MAUI.Views;

namespace Tarrocco.MAUI.AI;

public class TarotReader : ITarotReader
{
    private readonly IGeminiStartup _geminiStartup;
    private IGeminiClient _geminiClient;
    private IServiceCollection _services { get; } = new ServiceCollection();
    private IServiceProvider _serviceProvider { get; set; }
    private Regex _questionRegex = new Regex(@"\D+\?$");
    private FortunePageViewModel _viewModel = FortunePage.ViewModel;

    private string QuestionFormat = ". Svensk tarotläsare med en mystisk ton. Ger direkt ett övergripande svar av korten, en rad per kort. Ge en kort förklaring av läsningen. Ska inte innehålla tecknet *";
    private ObservableCollection<Card> FortuneCards;

    public TarotReader()
    {
        _geminiStartup = new GeminiStartup();
        _geminiStartup.ConfigureServices(_services);
        _serviceProvider = _services.BuildServiceProvider();
        _geminiClient = _serviceProvider.GetRequiredService<IGeminiClient>();
    }

    public async Task<string> GetFortune(string question, CollectionView fortuneCardCollection)
    {
        if (IsValidQuestion(question))
        {
            _viewModel.PickThreeCards();
            FortuneCards = _viewModel.FortuneCards;
            string cardNames = FortuneCards.Select(c => c.Name).Aggregate((a, b) => $"{a}, {b}");
            var response = await _geminiClient.TextPrompt(question + " " + cardNames + QuestionFormat);
            var responseText = response.Candidates[0].Content.Parts[0].Text;
            fortuneCardCollection.IsVisible = true;
            await fortuneCardCollection.FadeTo(1, 1000);
            return responseText;
        }
        else
        {
            return "Du måste ställa en fråga..";
        }
    }

    private bool IsValidQuestion(string question)
    {
        if (question != null && question != "")
        {
            Match match = _questionRegex.Match(question);
            return IsQuestion(match);
        }
        else
        {
            return false;
        }
    }

    private bool IsQuestion(Match match)
    {
        if (match.Success)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
