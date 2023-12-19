namespace TheTwilightOrder.Shared.Models.GameServer
{
    public class GameServer
    {
        public GameServer(string address, int port)
        {
            Id = Guid.NewGuid();
            Address = address;
            Port = port;
        }

        public Guid Id { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public int GameCount { get; set; }
    }
}
