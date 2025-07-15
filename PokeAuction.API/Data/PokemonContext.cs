using Microsoft.EntityFrameworkCore;
using PokeAuctionAPI.Models;

namespace PokeAuctionAPI.Data;

public class PokeContext : DbContext
{
    public PokeContext(DbContextOptions<PokeContext> options) : base(options) { }

    public DbSet<Pokemon> Pokemon { get; set; } = null!;
}
