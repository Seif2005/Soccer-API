namespace SoccerAPI.Models
{
    public class Cup
    {
        public int CupId { get; set; }
        public string Name { get; set; }
        public int NumberOfTeams { get; set; }
        public List<Match> Matches { get; set; }


        public ICollection<Team> Teams { get; set; }
        public List<CupTeam> CupTeams { get; set; }
    }
}
