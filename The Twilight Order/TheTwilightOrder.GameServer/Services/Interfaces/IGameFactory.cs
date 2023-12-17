using TheTwilightOrder.Shared.Models.Game;

namespace TheTwilightOrder.GameServer.Services.Interfaces
{
	public interface IGameFactory
	{
		State GetNewGame();
	}
}
