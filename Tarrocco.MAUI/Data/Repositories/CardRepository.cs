using Microsoft.EntityFrameworkCore;
using Tarrocco.MAUI.Models;

namespace Tarrocco.MAUI.Data.Repositories
{
    public class CardRepository
    {
        private readonly TarroccoContext _context;

        public CardRepository(TarroccoContext context)
        {
            _context = context;
        }

        // Hämta alla kort från databasen
        public async Task<List<Card>> GetAllCardsAsync()
        {
            return await _context.Cards.ToListAsync();
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
}
