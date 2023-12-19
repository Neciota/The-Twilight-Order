using TheTwilightOrder.GameServer.Services;
using TheTwilightOrder.GameServer.Services.Interfaces;
using TheTwilightOrder.Shared.Utility;
using TheTwilightOrder.Shared.Utility.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowOrigin", policy => policy.WithOrigins("https://localhost:7192").AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<IGameFactory, GameFactory>();
builder.Services.AddScoped<IGameFactory, GameFactory>();

// Utilities
builder.Services.AddScoped<ICountryFactory, CountryJsonReader>();
builder.Services.AddScoped<IRegionFactory, RegionJsonReader>();

var app = builder.Build();
app.UseCors("AllowOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await ServerService.RegisterSelf();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
