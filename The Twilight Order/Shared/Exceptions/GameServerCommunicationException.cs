namespace TheTwilightOrder.Shared.Exceptions
{
    public class GameServerCommunicationException: Exception
    {
        public GameServerCommunicationException() { }
        public GameServerCommunicationException(string message) : base(message) { }
    }
}
