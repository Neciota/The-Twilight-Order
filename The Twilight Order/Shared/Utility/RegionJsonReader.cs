using System.Text.Json;
using TheTwilightOrder.Shared.Models.Game;
using TheTwilightOrder.Shared.Utility.Interfaces;

namespace TheTwilightOrder.Shared.Utility
{
	public class RegionJsonReader: IRegionFactory
	{
		private JsonSerializerOptions GetSerializerOptions()
		{
			return new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
		}

		public IEnumerable<Region> GetRegions()
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/Regions");
			IEnumerable<string> filePaths = Directory.EnumerateFiles(path);
			return filePaths.Select(File.ReadAllText)
				.Select(content => JsonSerializer.Deserialize<Region>(content, GetSerializerOptions()))
				.Where(region => region is not null)
				.Select(region => region!);
		}

		public Region GetRegion(string code)
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/Regions", $"{code}.json");
			string content = File.ReadAllText(path);
			return JsonSerializer.Deserialize<Region>(content, GetSerializerOptions()) ?? throw new ArgumentException("No region data for this code.");
		}
	}
}
