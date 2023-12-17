namespace TheTwilightOrder.Shared.Models.Game
{
    public class State
    {
        public int Round { get; set; } = 0;
        public Phase Phase { get; set; }

        public DefCon DefCon { get; set; }

        public Dictionary<string, Region> Regions { get; set; }
        public Dictionary<string, Country> Countries { get; set; }

        public Stack<Card> PlayedCards { get; set; }
        public Stack<Card> UnplayedCards { get; set; }

        public SpaceRace SpaceRaceUS { get; set; }
        public SpaceRace SpaceRaceGermany { get; set; }
        public SpaceRace SpaceRaceJapan { get; set; }
    }
}
