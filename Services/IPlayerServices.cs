namespace SoccerAPI.Services
{
    public interface IPlayerServices 
    {
        Task<IEnumerable<Player>> GetAll();
        Task<Player> GetById(int Id);
        Task<Player> AddPlayer(Player player);
        Player Update(Player player);
        Player Delete(Player player);
    }
}
