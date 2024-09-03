using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoccerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        
        private readonly ICoachServices _coachServices;
        private readonly IMapper _mapper;
        private readonly IPlayerServices _playerServices;

        public PlayerController(ICoachServices coachServices, IMapper mapper, IPlayerServices playerServices)

        {
            _coachServices = coachServices;
            _mapper = mapper;
            _playerServices = playerServices;
        }
        #region Get
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var playersgot = await _playerServices.GetAll();
            var players = _mapper.Map<IEnumerable<PlayerDto>>(playersgot);
            return Ok(players);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var playergot = await _playerServices.GetById(id);
            var player = _mapper.Map<PlayerDto>(playergot);
            return Ok(player);
        }

        #endregion
        #region Post
        [HttpPost]
        public async Task<IActionResult> AddPlayer([FromForm] PlayerDto playerdto)
        {
            var player = _mapper.Map<Player>(playerdto);
            await _playerServices.AddPlayer(player);
            return Ok(player);
        }
        #endregion
        #region Put
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id,[FromForm]PlayerDto playerdto)
        {
            var player = await _playerServices.GetById(id);
            if (player == null)
            {
                return BadRequest("There is no such player with this id");
            }
            player.Name = playerdto.Name;
            player.Position = playerdto.Position;
            player.TeamId = playerdto.TeamId;
            _playerServices.Update(player);
            return Ok(player);

        }
        #endregion
        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _playerServices.GetById(id);
            if (player == null)
            {
                return BadRequest("There is no such a player with this id");
            }
            _playerServices.Delete(player);
            return Ok(player);
        }
        #endregion
    }
}
