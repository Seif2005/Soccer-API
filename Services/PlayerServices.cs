namespace SoccerAPI.Services
{
    public class PlayerServices : IPlayerServices
    {

        private readonly ApplicationDBContext _context;

        public PlayerServices(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Player> AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return player;
        }

        public Player Delete(Player player)
        {
            _context.Players.Remove(player);
            _context.SaveChanges() ;
            return player;
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await _context.Players.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Player> GetById(int Id)
        {
            return await _context.Players.FirstOrDefaultAsync(c => c.PlayerId == Id);
        }

        public Player Update(Player player)
        {
            _context.Players.Update(player);
            _context.SaveChanges();
            return player;
        }
    }
}
