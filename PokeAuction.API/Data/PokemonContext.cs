using Microsoft.EntityFrameworkCore;
using PokeAuctionAPI.Models;

namespace PokeAuctionAPI.Data
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemon { get; set; } = null!;
        public DbSet<Item> Item { get; set; } = null!;
        public DbSet<Move> Move { get; set; } = null!;
        public DbSet<Pokemon_move> Pokemon_move { get; set; } = null!;
        public DbSet<Move_effect_prose> Move_effect_prose { get; set; } = null!;
        public DbSet<Evolution> Evolution { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Pokemon entity configuration
            modelBuilder.Entity<Pokemon>()
                .ToTable("pokemon");

            // Item entity configuration
            modelBuilder.Entity<Item>()
                .ToTable("item");

            // Move entity configuration
            modelBuilder.Entity<Move>()
                .ToTable("move");

            // Pokemon_Move entity configuration
            modelBuilder.Entity<Pokemon_move>()
                .ToTable("pokemon_move")
                .HasKey(pm => new { pm.PokemonId, pm.VersionGroupId, pm.MoveId, pm.PokemonMoveMethodId });

            // Move_effect_prose entity configuration
            modelBuilder.Entity<Move_effect_prose>()
                .ToTable("move_effect_prose")
                .HasKey(mep => new { mep.MoveEffectId, mep.LocalLanguageId });

            // Order by Evolve Species Id and Evo Trigger as some Id's == NULL
            modelBuilder.Entity<Evolution>()
                .ToTable("evolution")
                .HasKey(e => new { e.EvolvedSpeciesId, e.EvolutionTriggerId });
        }
    }
}