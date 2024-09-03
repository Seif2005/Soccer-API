using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoccerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachServices _coachServices;
        private readonly ITeamServices _teamServices;
        private readonly IMapper _mapper; 

        public CoachController(ICoachServices coachServices, IMapper mapper, ITeamServices teamServices)
        {
            _coachServices = coachServices;
            _mapper = mapper;
            _teamServices = teamServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllASync()
        {
            var coachgot = await _coachServices.GetAll();
            var coaches = _mapper.Map<IEnumerable<CoachDto>>(coachgot);
            return Ok(coaches);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coachgot= await _coachServices.GetById(id);
            //Convert via mapper
            var coach = _mapper.Map<CoachDto>(coachgot);
            return Ok(coach);
        }
        [HttpPost]
        public async Task<IActionResult> AddCoach([FromForm]CoachDto dto)
        {
            var available = await _teamServices.IsValidTeam(dto.TeamId);
            if (!available)
            {
                return BadRequest($"No Such Id for a team: {dto.TeamId}");
            }
            var coach = _mapper.Map<Coach>(dto);
            await _coachServices.Add(coach);
            return Ok(coach);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoach(int id, [FromForm]CoachDto dto)
        {
            var available= await _coachServices.IsValidCoach(id);
            if (!available)
            {
                return BadRequest($"No Such Id : {id}");
            }
            var coach = await _coachServices.GetById(id);
            coach.Name = dto.Name;
            coach.TeamId = dto.TeamId;
            coach.Experience = dto.Experience;
            coach.Age = dto.Age;
            _coachServices.Update(coach);
            return Ok(coach);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            var available = await _coachServices.IsValidCoach(id);
            if (!available)
            {
                return BadRequest($"No Such Id : {id}");
            }
            var coach = await _coachServices.GetById(id);
            _coachServices.Delete(coach);
            return Ok(coach);
        }

    }
}
