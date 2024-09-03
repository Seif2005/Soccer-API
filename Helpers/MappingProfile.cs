namespace SoccerAPI.Helpers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Coach, CoachDto>();
            CreateMap<CoachDto, Coach>();

            CreateMap<PlayerDto, Player>();
            CreateMap<Player, PlayerDto>();

            CreateMap<Team, TeamDto>();
            CreateMap<TeamDto, Team>();
        }
    }
}
