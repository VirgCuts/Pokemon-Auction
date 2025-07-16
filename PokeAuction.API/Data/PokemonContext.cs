using Microsoft.EntityFrameworkCore;
using PokeAuctionAPI.Models;

namespace PokeAuctionAPI.Data
{
    public class PokeContext : DbContext
    {
        public PokeContext(DbContextOptions<PokeContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemon { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Additional configuration if needed
            modelBuilder.Entity<Pokemon>()
                .ToTable("pokemon");  // Ensure lowercase table name
        }
    }
}