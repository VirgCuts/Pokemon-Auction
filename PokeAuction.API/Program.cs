using Microsoft.EntityFrameworkCore;
using PokemonAuction.Data;
using PokemonAuction.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Entity Framework
builder.Services.AddDbContext<PokemonAuctionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CORS for Angular frontend
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});

// Add SignalR for real-time features
builder.Services.AddSignalR();

// Add custom services - only add the ones we have
builder.Services.AddScoped<IPokemonService, PokemonService>();
// builder.Services.AddScoped<IAuctionService, AuctionService>(); // Comment out for now

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

// Map SignalR hub - comment out for now
// app.MapHub<AuctionHub>("/auctionHub");

app.Run();