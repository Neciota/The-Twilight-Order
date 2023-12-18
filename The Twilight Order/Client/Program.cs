using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TheTwilightOrder.Client;
using TheTwilightOrder.Client.Services;
using TheTwilightOrder.Client.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("TheTwilightOrder.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient("TheTwilightOrder.GameServerAPI", client => client.BaseAddress = new Uri("https://localhost:7194"));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("TheTwilightOrder.ServerAPI"));

// Services
builder.Services.AddScoped<IGameService, GameService>();

await builder.Build().RunAsync();
