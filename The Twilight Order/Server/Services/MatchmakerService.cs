using TheTwilightOrder.Server.Services.Interfaces;
using TheTwilightOrder.Shared.Models;
using TheTwilightOrder.Shared.Models.Game;
using TheTwilightOrder.Shared.Models.GameServer;

namespace TheTwilightOrder.Server.Services
{
    public class MatchmakerService: IMatchmakerService
    {
        private readonly Dictionary<Guid, Lobby> _activeLobbies;
        private readonly IGameServerService _gameServerService;

        public MatchmakerService(IGameServerService gameServerService)
        {
            _activeLobbies = new Dictionary<Guid, Lobby>();
            _gameServerService = gameServerService;
        }

        public IEnumerable<Lobby> GetActiveLobbies()
        {
            return _activeLobbies.Values;
        }

        public Lobby CreateLobby(string name, Account creator)
        {
            Lobby lobby = new Lobby(Guid.NewGuid(), name, creator);

            _activeLobbies.Add(lobby.Id, lobby);
            return lobby;
        }

        public Lobby? JoinLobby(Guid id, Account player)
        {
            if (!_activeLobbies.ContainsKey(id))
                return null;

            Lobby lobby = _activeLobbies[id];

            if (lobby.USA is null)
                lobby.USA = new Player(player, PlayerCountry.USA);
            else if (lobby.Germany is null)
                lobby.USA = new Player(player, PlayerCountry.Germany);
            else if (lobby.Japan is null)
                lobby.USA = new Player(player, PlayerCountry.Japan);
            else
                return null;

            return lobby;
        }

        public async Task<GameServer?> StartGame(Guid id)
        {
            if (!_activeLobbies.ContainsKey(id))
                return null;

            GameServer server = _gameServerService.GetLowestOccupancyServer();
            Lobby lobby = _activeLobbies[id];

            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync($"{server.Address}/game/start", lobby);
            if (!response.IsSuccessStatusCode)
                return null;

            return server;
        }
    }
}
