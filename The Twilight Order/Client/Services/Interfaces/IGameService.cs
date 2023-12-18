using TheTwilightOrder.Shared.Models.Game;

namespace TheTwilightOrder.Client.Services.Interfaces
{
    public interface IGameService
    {
        Task<State> GetGameStateAsync();
        Task<IEnumerable<Player>> GetPlayersAsync();
    }
}
