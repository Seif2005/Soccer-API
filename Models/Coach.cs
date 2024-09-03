namespace SoccerAPI.Models
{
    public class Coach
    {
        public int CoachId { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }

        public int Age { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
