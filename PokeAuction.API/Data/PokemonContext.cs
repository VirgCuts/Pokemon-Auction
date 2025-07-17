using Microsoft.EntityFrameworkCore;
using PokeAuctionAPI.Models;

namespace PokeAuctionAPI.Data
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemon { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .ToTable("pokemon");
        }
    }
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options) { }
        
        public DbSet<Item> Item { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .ToTable("Items");
        }
    }
    public class MoveContext : DbContext
    {
        public MoveContext(DbContextOptions<MoveContext> options) : base(options) { }
        
        public DbSet<Move> Move { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Move>()
                .ToTable("Moves");
        }
    }
    public class PokemonMoveContext : DbContext
    {
        public PokemonMoveContext(DbContextOptions<PokemonMoveContext> options) : base(options) { }
        
        public DbSet<Pokemon_Move> PokemonMove { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon_Move>()
                .ToTable("PokemonMoves")
                .HasKey(pm => new { pm.PokemonId, pm.VersionGroupId, pm.MoveId, pm.PokemonMoveMethodId });
        }
    }
    public class MoveEffectProseContext : DbContext
    {
        public MoveEffectProseContext(DbContextOptions<MoveEffectProseContext> options) : base(options) { }
        
        public DbSet<Move_effect_prose> MoveEffectText { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Move_effect_prose>()
                .ToTable("MoveEffectText")
                .HasKey(met => new { met.MoveEffectId, met.LocalLanguageId });
        }
    }
    public class EvolutionContext : DbContext
    {
        public EvolutionContext(DbContextOptions<EvolutionContext> options) : base(options) { }
        
        public DbSet<Evolution> Evolution { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evolution>()
                .ToTable("Evolution");
        }
    }
}