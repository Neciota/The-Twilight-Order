using TheTwilightOrder.GameServer.Services.Interfaces;
using TheTwilightOrder.Shared.Models.Game;
using TheTwilightOrder.Shared.Utility.Interfaces;

namespace TheTwilightOrder.GameServer.Services
{
	public class GameFactory : IGameFactory
	{
		private readonly ICountryFactory _countryFactory;
		private readonly IRegionFactory _regionFactory;

        public GameFactory(ICountryFactory countryFactory, IRegionFactory regionFactory)
        {
			_countryFactory = countryFactory;
			_regionFactory = regionFactory;
        }

        public State GetNewGame()
		{
			IEnumerable<Country> countries = _countryFactory.GetCountries();

			Dictionary<string, Region> regions = _regionFactory.GetRegions().ToDictionary(region => region.Code, region => region);

			foreach (Country country in countries)
			{
				if (!regions.TryGetValue(country.RegionCode, out Region? region))
					throw new InvalidOperationException($"Missing region code {country.RegionCode}");

				region.Countries.Add(country); 
			}

			return new State
			{
				Countries = countries.ToDictionary(country => country.Code, country => country),
				Regions = regions
			};
		}
	}
}
