using TheTwilightOrder.Shared.Models;
using TheTwilightOrder.Shared.Models.GameServer;

namespace TheTwilightOrder.Server.Services.Interfaces
{
    public interface IMatchmakerService
    {
        Lobby CreateLobby(string name, Account creator);
        IEnumerable<Lobby> GetActiveLobbies();
        Lobby? JoinLobby(Guid id, Account player);
        Task<GameServer?> StartGame(Guid id);
    }
}
