namespace TheTwilightOrder.GameServer.Services
{
    public class ServerService
    {
        public static async Task<bool> RegisterSelf()
        {
            await Task.Delay(5000);
            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse = await httpClient.PostAsync("https://localhost:7192/api/servers", null);
            return true;
        }

        public bool DeregisterSelf()
        {
            throw new NotImplementedException();
        }
    }
}
