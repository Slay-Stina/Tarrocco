using System.Diagnostics;
using System.Text.Json;
using Tarrocco.MAUI.Extensions;
using Tarrocco.MAUI.Models;

namespace Tarrocco.MAUI.Data;

public class Gemini
{
    public string RequestContent { get; set; }

    public Gemini(string cardOne, string cardTwo, string cardThree, string question)
    {
        RequestContent = $"{question} {cardOne}, {cardTwo}, {cardThree}";
    }

    public async static Task<TarotReadingResponse> GetGeminiResponse(Gemini gemini)
    {
        GeminiRequestContent geminiRequest = new GeminiRequestContent(gemini);
        GeminiResponse geminiResponse = null;
        TarotReadingResponse readingResponse = null;

        var client = new HttpClient();
        var response = await client.ToGeminiResponse(gemini);

        if (response.IsSuccessStatusCode)
        {
            string stringResponse = await response.Content.ReadAsStringAsync();
            geminiResponse = JsonSerializer.Deserialize<GeminiResponse>(stringResponse);
        }
        string answer = geminiResponse.candidates[0].content.parts[0].text;
        if (answer != null)
        {
            readingResponse = JsonSerializer.Deserialize<TarotReadingResponse>(answer);
        }
        return readingResponse;
    }
}

