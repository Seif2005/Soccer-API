using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoccerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamServices _teamServices;
        private readonly ICoachServices _coachServices;
        private IMapper _mapper;
        public TeamController(IMapper mapper, ITeamServices teamServices, ICoachServices coachServices)
        {
            _mapper = mapper;
            _coachServices = coachServices;
            _teamServices = teamServices;
        }
        #region Get
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var teamsgot = await _teamServices.GetAll();
            var teams = _mapper.Map<IEnumerable<TeamDto>>(teamsgot);
            return Ok(teams);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teamgot = await _teamServices.GetById(id);
            var team = _mapper.Map<TeamDto>(teamgot);
            return Ok(team);
        }

        #endregion
        #region Post
        [HttpPost]
        public async Task<IActionResult> AddTeam([FromForm] TeamDto dto)
        {
            var team = _mapper.Map<Team>(dto);
            await _teamServices.Add(team);
            return Ok(team);
        }
        #endregion
        #region Put
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id,[FromForm]TeamDto Teamdto)
        {
            var available = await _teamServices.IsValidTeam(id);
            if (!available)
            {
                return BadRequest($"There is no such an id: {id}");

            }
            var team = await _teamServices.GetById(id);
            team.Name= Teamdto.Name;
            team.StadiumName= Teamdto.StadiumName;
            _teamServices.Update(team);
            return Ok(team);
        }
        #endregion
        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var available = await _teamServices.IsValidTeam(id);
            if (!available)
            {
                return BadRequest($"There is no such an id: {id}");

            }
            var team = await _teamServices.GetById(id);
            _teamServices.Delete(team);
            return Ok(team);
        }
        #endregion


    }
}
