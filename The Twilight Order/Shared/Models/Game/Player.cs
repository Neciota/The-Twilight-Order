namespace TheTwilightOrder.Shared.Models.Game
{
    public class Player
    {
        public Player(Account account, PlayerCountry country)
        {
            Account = account;
            Country = country;
        }

        public Account Account { get; set; }
        public PlayerCountry Country { get; set; }
    }
}
