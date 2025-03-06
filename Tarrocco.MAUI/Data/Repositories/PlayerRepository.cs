using Tarrocco.MAUI.Models;

namespace Tarrocco.MAUI.Data.Repositories
{
    public class PlayerRepository
    {
        private readonly TarroccoContext _context;

        public PlayerRepository(TarroccoContext context)
        {
            _context = context;
        }

        // Hämta alla spelare från databasen
        public List<Player> GetAllPlayers()
        {
            return _context.Players.ToList();
        }

        // Lägg till en ny spelare i databasen
        public void AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        // Uppdatera en befintlig spelare
        public void UpdatePlayer(Player player)
        {
            _context.Players.Update(player);
            _context.SaveChanges();
        }

        // Ta bort en spelare från databasen
        public void DeletePlayer(int id)
        {
            var player = _context.Players.Find(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                _context.SaveChanges();
            }
        }
    }
}