namespace SoccerAPI.Services
{
    public interface ICoachServices
    {
        Task<IEnumerable<Coach>> GetAll();
        Task<Coach> GetById(int id);
        Task<Coach> Add(Coach Coach);
        Coach Update(Coach Coach);
        Coach Delete(Coach Coach);
        Task<bool> IsValidCoach(int id);
    }
}
