using PokeAuctionAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<PokemonContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PokemonDatabase"))
           .LogTo(Console.WriteLine, LogLevel.Information)
           .EnableSensitiveDataLogging());

builder.Services.AddDbContext<ItemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ItemDatabase")));

builder.Services.AddDbContext<MoveContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoveDatabase")));

builder.Services.AddDbContext<PokemonMoveContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PokemonMoveDatabase")));

builder.Services.AddDbContext<MoveEffectProseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoveEffectProseDatabase")));

builder.Services.AddDbContext<EvolutionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EvolutionDatabase")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "PokeAuction API is running!");

app.Run();