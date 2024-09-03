namespace SoccerAPI.Services
{
    public class TeamServices : ITeamServices
    {

        private readonly ApplicationDBContext _context;

        public TeamServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Team> Add(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return team;
        }

        public Team Delete(Team team)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return team;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _context.Teams.OrderBy(t=>t.Name).ToListAsync();
        }

        public async Task<Team> GetById(int id)
        {
            return await _context.Teams.FirstOrDefaultAsync(t => t.TeamId == id);
        }

        public Task<bool> IsValidTeam(int id)
        {
            return _context.Teams.AnyAsync(t => t.TeamId == id);
        }

        public Team Update(Team team)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();
            return team;
        }
    }
}
