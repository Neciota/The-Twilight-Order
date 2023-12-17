using TheTwilightOrder.Shared.Models.Game;

namespace TheTwilightOrder.Shared.Utility.Interfaces
{
	public interface ICountryFactory
	{
		Country GetCountry(string code);
		IEnumerable<Country> GetCountries();
	}
}
