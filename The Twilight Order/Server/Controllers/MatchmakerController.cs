using Microsoft.AspNetCore.Mvc;
using TheTwilightOrder.Server.Services.Interfaces;
using TheTwilightOrder.Shared.Models;
using TheTwilightOrder.Shared.Models.GameServer;

namespace TheTwilightOrder.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchmakerController : ControllerBase
    {
        private readonly IMatchmakerService _matchmakerService;

        public MatchmakerController(IMatchmakerService matchmakerService)
        {
            _matchmakerService = matchmakerService;
        }

        [HttpGet]
        [Route("api/lobbies")]
        public ActionResult<IEnumerable<Lobby>> GetLobbies()
        {
            return Ok(_matchmakerService.GetActiveLobbies());
        }

        [HttpPost]
        [Route("api/lobbies")]
        public ActionResult<Lobby> CreateLobbies(string name, Account creator)
        {
            return Ok(_matchmakerService.CreateLobby(name, creator));
        }

        [HttpPut]
        [Route("api/lobbies/{id}")]
        public ActionResult<Lobby> JoinLobby([FromRoute] Guid id, Account player)
        {
            Lobby? lobby = _matchmakerService.JoinLobby(id, player);

            if (lobby is null)
                return BadRequest("No lobby with space found by this id.");

            return lobby;
        }

        [HttpPost]
        [Route("api/lobbies/{id}/start")]
        public async Task<ActionResult<GameServer>> StartGame([FromRoute] Guid id)
        {
            GameServer? server = await _matchmakerService.StartGame(id);

            if (server is null)
                return BadRequest("Could not start a game with this id.");

            return server;
        }
    }
}
