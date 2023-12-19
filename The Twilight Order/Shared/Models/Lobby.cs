using System.Text.Json.Serialization;
using TheTwilightOrder.Shared.Models.Game;

namespace TheTwilightOrder.Shared.Models
{
    public class Lobby
    {
        public Lobby(Guid id, string name, Account creator, string? password = null)
        {
            Id = id;
            Name = name;
            Creator = creator;
            Password = password;
            USA = new Player(Creator, PlayerCountry.USA);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Account Creator { get; set; }
        [JsonIgnore]
        public string? Password { get; set; }
        public Player? USA { get; set; }
        public Player? Germany { get; set; }
        public Player? Japan { get; set; }
    }
}
