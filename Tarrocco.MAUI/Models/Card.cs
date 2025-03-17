namespace Tarrocco.MAUI.Models;

public partial class Card
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Value { get; set; }

    public string? Effect { get; set; }

    public string ImagePath { get; set; } = null!;
}
