using System.Runtime.CompilerServices;

namespace TheTwilightOrder.Shared.Models.Game
{
    public class Country
    {
        public Country(string code, string regionCode, string name)
        {
            Code = code;
            RegionCode = regionCode;
            Name = name;
        }

        public string Code { get; set; }
        public string RegionCode { get; set; }
        public string Name { get; set; }
        public string? ShortName { get; set; }
        public bool IsPlayer { get; set; }
        public int Stability { get; set; }
        public int InfluenceUSA { get; set; }
        public int InfluenceGermany { get; set; }
        public int InfluenceJapan { get; set; }
        public bool IsBattleground { get; set; } = false;
        public int BoxX { get; set; }
        public int BoxY { get; set; }
        public IEnumerable<string> Neighbors { get; set; } = Enumerable.Empty<string>();

        public int CenterX => BoxX + 50;
        public int CenterY => BoxY + 50;

        // When rendering across the map, invert the direction to make it appear to go off map the other way
        public bool InvertLineRender(Country neighbor) => Math.Abs(CenterX - neighbor.CenterX) > 2816;

        public override string ToString()
        {
            return ShortName ?? Name;
        }
    }
}
