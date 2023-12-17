using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheTwilightOrder.Shared.Models.Game;

namespace TheTwilightOrder.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        [Route("api/game/new")]
        public async Task<ActionResult<State>> GetNewGame()
        {
            return NoContent();
        }
    }
}
