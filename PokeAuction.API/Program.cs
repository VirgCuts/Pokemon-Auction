using PokeAuctionAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<PokemonContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PokeAuctionDb"))
           .LogTo(Console.WriteLine, LogLevel.Information)
           .EnableSensitiveDataLogging());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Pokemon Auction API Running");

app.Run();