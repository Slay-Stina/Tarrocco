using System.Text.Json.Serialization;

namespace Tarrocco.MAUI.Data;

class GeminiResponse
{
    public Candidate[] candidates { get; set; }
    public Usagemetadata usageMetadata { get; set; }
    public string modelVersion { get; set; }
}
public class Usagemetadata
{
    public int promptTokenCount { get; set; }
    public int candidatesTokenCount { get; set; }
    public int totalTokenCount { get; set; }
    public Prompttokensdetail[] promptTokensDetails { get; set; }
    public Candidatestokensdetail[] candidatesTokensDetails { get; set; }
}

public class Prompttokensdetail
{
    public string modality { get; set; }
    public int tokenCount { get; set; }
}

public class Candidatestokensdetail
{
    public string modality { get; set; }
    public int tokenCount { get; set; }
}

public class Candidate
{
    public Content content { get; set; }
    public string finishReason { get; set; }
    public float avgLogprobs { get; set; }
}