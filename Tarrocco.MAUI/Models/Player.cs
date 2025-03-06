using System;
using System.Collections.Generic;

namespace Tarrocco.MAUI.Models;

public partial class Player
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Score { get; set; }

    public string CreatedAt { get; set; } = null!;
}
