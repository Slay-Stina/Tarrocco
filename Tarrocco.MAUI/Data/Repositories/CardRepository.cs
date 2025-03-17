using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tarrocco.MAUI.Models;

namespace Tarrocco.MAUI.Data.Repositories;

public class CardRepository
{
    private static readonly CardRepository _cardRepo = new CardRepository(new TarroccoContext());
    private readonly TarroccoContext _context;
    private List<Card> _cards = new List<Card>();

    private CardRepository(TarroccoContext context)
    {
        _context = context;
        _cards = LoadAllCardsAsync().Result;
    }

    public static List<Card> GetCards()
    {
        return _cardRepo._cards;
    }

    // Hämta alla kort från databasen
    private async Task<List<Card>> LoadAllCardsAsync()
    {
        var cards = await _context.Cards.ToListAsync();
        Debug.WriteLine("Cards loaded");
        return cards; //await _context.Cards.ToListAsync();
    }

    // Lägg till ett nytt kort i databasen
    public void AddCard(Card card)
    {
        _context.Cards.Add(card);
        _context.SaveChanges();
    }

    // Uppdatera ett befintligt kort
    public void UpdateCard(Card card)
    {
        _context.Cards.Update(card);
        _context.SaveChanges();
    }

    // Ta bort ett kort från databasen
    public void DeleteCard(int id)
    {
        var card = _context.Cards.Find(id);
        if (card != null)
        {
            _context.Cards.Remove(card);
            _context.SaveChanges();
        }
    }
}
