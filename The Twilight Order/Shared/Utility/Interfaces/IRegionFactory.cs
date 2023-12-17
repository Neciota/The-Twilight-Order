using TheTwilightOrder.Shared.Models.Game;

namespace TheTwilightOrder.Shared.Utility.Interfaces
{
	public interface IRegionFactory
	{
		Region GetRegion(string code);
		IEnumerable<Region> GetRegions();
	}
}
