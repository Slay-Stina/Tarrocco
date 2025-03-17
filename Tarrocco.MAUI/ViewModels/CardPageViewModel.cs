using Tarrocco.MAUI.Data.Repositories;
using Tarrocco.MAUI.Models;

namespace Tarrocco.MAUI.ViewModels;

public class CardPageViewModel
{
    public List<Card> CardList { get; } = CardRepository.GetCards();
}
