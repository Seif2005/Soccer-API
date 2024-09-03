namespace SoccerAPI.Services
{
    public interface ITeamServices
    {
        Task<IEnumerable<Team>> GetAll();
        Task<Team> GetById(int id);
        Task<Team> Add(Team team);
        Team Update(Team team);
        Team Delete(Team team);
        Task<bool> IsValidTeam(int id);
    }
}
