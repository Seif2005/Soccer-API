namespace SoccerAPI.Services
{
    public class CoachServices : ICoachServices
    {

        private readonly ApplicationDBContext _context;

        public CoachServices(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<Coach> Add(Coach Coach)
        {
            await _context.Coaches.AddAsync(Coach);
            _context.SaveChanges();
            return Coach;

        }

        public Coach Delete(Coach Coach)
        {
            _context.Coaches.Remove(Coach);
            _context.SaveChanges();
            return Coach;
        }

        public async Task<IEnumerable<Coach>> GetAll()
        {
            return await _context.Coaches.Include(c=>c.Team).OrderBy(c=>c.Name).ToListAsync();
        }

        public async Task<Coach> GetById(int id)
        {
            return await _context.Coaches.Include(c => c.Team).FirstOrDefaultAsync(c => c.CoachId == id);
        }

        public Task<bool> IsValidCoach(int id)
        {
            return _context.Coaches.AnyAsync(m => m.CoachId == id);
        }

        public Coach Update(Coach Coach)
        {
            _context.Coaches.Update(Coach);
            _context.SaveChanges();
            return Coach;
        }
    }
}
