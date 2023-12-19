using Microsoft.AspNetCore.Mvc;
using TheTwilightOrder.Server.Services.Interfaces;

namespace TheTwilightOrder.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameServerController : ControllerBase
    {
        private readonly IGameServerService _gameServerService;

        public GameServerController(IGameServerService gameServerService)
        {
            _gameServerService = gameServerService;
        }

        [HttpPost]
        [Route("api/servers")]
        public ActionResult<Guid> RegisterServer(string address)
        {
            HttpContext context = HttpContext;
            return _gameServerService.RegisterServer(address, 0);
        }

        [HttpDelete]
        [Route("api/servers")]
        public ActionResult<bool> DeregisterServer(Guid id)
        {
            return _gameServerService.DeregisterServer(id);
        }
    }
}
