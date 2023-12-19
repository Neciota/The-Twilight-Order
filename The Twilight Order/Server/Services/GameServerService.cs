using TheTwilightOrder.Server.Services.Interfaces;
using TheTwilightOrder.Shared.Models.GameServer;

namespace TheTwilightOrder.Server.Services
{
    public class GameServerService: IGameServerService
    {
        private readonly Dictionary<Guid, GameServer> _gameServers;

        public GameServerService()
        {
            _gameServers = new Dictionary<Guid, GameServer>();
        }

        public Guid RegisterServer(string address, int port)
        {
            GameServer newServer = new GameServer(address, port);
            _gameServers.Add(newServer.Id, newServer);

            return newServer.Id;
        }

        public bool DeregisterServer(Guid id)
        {
            return _gameServers.Remove(id);
        }

        public GameServer GetLowestOccupancyServer()
        {
            return _gameServers.MinBy(server => server.Value.GameCount).Value;
        }
    }
}
