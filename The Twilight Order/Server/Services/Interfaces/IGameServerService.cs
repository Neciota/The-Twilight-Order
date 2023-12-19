using TheTwilightOrder.Shared.Models.GameServer;

namespace TheTwilightOrder.Server.Services.Interfaces
{
    public interface IGameServerService
    {
        bool DeregisterServer(Guid id);
        GameServer GetLowestOccupancyServer();
        Guid RegisterServer(string address, int port);
    }
}
