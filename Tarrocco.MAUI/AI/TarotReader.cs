using DotnetGeminiSDK.Client.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Tarrocco.MAUI.AI;

public class TarotReader
{
    private readonly IGeminiClient _geminiClient;

    public TarotReader(IGeminiClient geminiClient)
    {
        _geminiClient = geminiClient;
    }

    public async Task<string> GetFortune(string prompt)
    {
        string questionFormat = ". Svensk tarotläsare med en mystisk ton. Ger direkt ett övergripande svar av korten, en rad per kort. Ge en kort förklaring av läsningen. Ska inte innehålla tecknet *";
        var response = await _geminiClient.TextPrompt(prompt + questionFormat);
        var responseText = response.Candidates[0].Content.Parts[0].Text;
        return responseText;
    }
}
