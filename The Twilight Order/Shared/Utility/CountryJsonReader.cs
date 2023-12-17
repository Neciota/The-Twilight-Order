using System.Text.Json;
using TheTwilightOrder.Shared.Models.Game;
using TheTwilightOrder.Shared.Utility.Interfaces;

namespace TheTwilightOrder.Shared.Utility
{
    public class CountryJsonReader: ICountryFactory
    {
        private JsonSerializerOptions GetSerializerOptions()
        {
            return new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
		}

        public IEnumerable<Country> GetCountries()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/Countries");
            IEnumerable<string> filePaths = Directory.EnumerateFiles(path);
            return filePaths.Select(File.ReadAllText)
                .Select(content => JsonSerializer.Deserialize<Country>(content, GetSerializerOptions()))
                .Where(country => country is not null)
                .Select(country => country!);
        }

		public Country GetCountry(string code)
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/Countries", $"{code}.json");
            string content = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Country>(content, GetSerializerOptions()) ?? throw new ArgumentException("No country data for this code.");
		}
	}
}
