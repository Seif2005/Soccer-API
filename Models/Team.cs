using System.Numerics;
using System.Text.RegularExpressions;

namespace SoccerAPI.Models
{
    public class Team
    {

            public int TeamId { get; set; }
            public string Name { get; set; }
            public string StadiumName { get; set; }
            public Coach Coach { get; set; }
            public List<Player> Players { get; set; }

            public ICollection<Match> Matches { get; set; }
            public List<MatchTeam> MatchTeams { get; set; }

            public ICollection<Cup> Cups { get; set; }
            public List<CupTeam> CupTeams { get; set; }

    }
}
