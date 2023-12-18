using Microsoft.AspNetCore.Mvc;
using TheTwilightOrder.GameServer.Services.Interfaces;
using TheTwilightOrder.Shared.Models.Game;

namespace TheTwilightOrder.Server.Controllers
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameFactory _gameFactory;

        public GameController(IGameFactory gameFactory)
        {
			_gameFactory = gameFactory;
        }

        [HttpGet]
        [Route("api/game/new")]
        public async Task<ActionResult<State>> GetNewGame()
        {
            return _gameFactory.GetNewGame();
        }
    }
}
