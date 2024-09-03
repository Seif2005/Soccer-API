namespace SoccerAPI.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public DateTime DateTime { get; set; }
        public string StadiumName { get; set; }

        public ICollection<Team> Teams { get; set; }
        public List<MatchTeam> MatchTeams { get; set; }





        public int CupId { get; set; }
        public Cup Cup { get; set; }

    }
}
