namespace SoccerAPI.Models
{
    public class MatchTeam
    {
        public int TeamId { get; set; }
        public int MatchId { get; set; }
        public string Status { get; set; }
        public Team Team { get; set; }
        public Match Match { get; set; }
    }
}
