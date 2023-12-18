using System.Net.Http.Json;
using System.Net.Http;
using TheTwilightOrder.Client.Services.Interfaces;
using TheTwilightOrder.Shared.Models.Game;
using TheTwilightOrder.Shared.Exceptions;

namespace TheTwilightOrder.Client.Services
{
    public class GameService: IGameService
    {
        private readonly HttpClient _httpGameClient;

        public GameService(IHttpClientFactory HttpClientFactory)
        {
            _httpGameClient = HttpClientFactory.CreateClient("TheTwilightOrder.GameServerAPI");
        }

        public async Task<State> GetGameStateAsync()
        {
            return await _httpGameClient.GetFromJsonAsync<State>("/api/game/new") ?? throw new GameServerCommunicationException("Error fetching game state from server.");
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            return await _httpGameClient.GetFromJsonAsync<IEnumerable<Player>>("/api/game/players") ?? throw new GameServerCommunicationException("Error fetching players from server.");
        }
    }
}
