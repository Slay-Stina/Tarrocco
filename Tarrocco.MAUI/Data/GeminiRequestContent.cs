using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarrocco.MAUI.Data;

public class GeminiRequestContent
{
    public Content[] contents { get; set; }
    public Systeminstruction systemInstruction { get; set; }
    public Generationconfig generationConfig { get; set; }

    public GeminiRequestContent(Gemini gemini)
    {
        contents = new Content[]
        {
            new Content
            {
                role = "user",
                parts = new Part[]
                {
                    new Part
                    {
                        text = gemini.RequestContent
                    }
                }
            }
        };
        systemInstruction = new Systeminstruction();
        systemInstruction.role = "user";
        systemInstruction.parts = new Part[] {
            new Part
            {
                text = "Svensk tarotläsare med en mystisk ton. Ger ett övergripande svar av korten och läsningen."
            }
        };
        generationConfig = new Generationconfig();
        generationConfig.temperature = 1;
        generationConfig.topK = 40;
        generationConfig.topP = 0.95f;
        generationConfig.maxOutputTokens = 8192;
        generationConfig.responseMimeType = "application/json";
        generationConfig.responseSchema = new Responseschema
        {
            type = "object",
            properties = new Properties
            {
                MysticPreamble = new Mysticpreamble
                {
                    type = "string"
                },
                CardOneDescription = new Cardonedescription
                {
                    type = "string"
                },
                CardTwoDescription = new Cardtwodescription
                {
                    type = "string"
                },
                CardThreeDescription = new Cardthreedescription
                {
                    type = "string"
                },
                Conclution = new Conclution
                {
                    type = "string"
                }
            },
            required = new string[]
            {
                "MysticPreamble",
                "CardOneDescription",
                "CardTwoDescription",
                "CardThreeDescription",
                "Conclution"
            }
        };
    }
}
public class Systeminstruction
{
    public string role { get; set; }
    public Part[] parts { get; set; }
}

public class Content
{
    public string role { get; set; }
    public Part[] parts { get; set; }
}

public class Part
{
    public string text { get; set; }
}

public class Generationconfig
{
    public int temperature { get; set; }
    public int topK { get; set; }
    public float topP { get; set; }
    public int maxOutputTokens { get; set; }
    public string responseMimeType { get; set; }
    public Responseschema responseSchema { get; set; }
}

public class Responseschema
{
    public string type { get; set; }
    public Properties properties { get; set; }
    public string[] required { get; set; }
}

public class Properties
{
    public Mysticpreamble MysticPreamble { get; set; }
    public Cardonedescription CardOneDescription { get; set; }
    public Cardtwodescription CardTwoDescription { get; set; }
    public Cardthreedescription CardThreeDescription { get; set; }
    public Conclution Conclution { get; set; }
}

public class Mysticpreamble
{
    public string type { get; set; }
}

public class Cardonedescription
{
    public string type { get; set; }
}

public class Cardtwodescription
{
    public string type { get; set; }
}

public class Cardthreedescription
{
    public string type { get; set; }
}

public class Conclution
{
    public string type { get; set; }
}