using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAuctionAPI.Models
{
    [Table("evolution")]
    public class Evolution
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; }

        [Column("evolved_species_id")]
        public int EvolvedSpeciesId { get; set; }

        [Column("evolution_trigger_id")]
        public int EvolutionTriggerId { get; set; }

        [Column("trigger_item_id")]
        public int? TriggerItemId { get; set; }

        [Column("minimum_level")]
        public byte? MinimumLevel { get; set; }

        [Column("gender_id")]
        public byte? GenderId { get; set; }

        [Column("location_id")]
        [StringLength(1)]
        public string? LocationId { get; set; }

        [Column("held_item_id")]
        public short? HeldItemId { get; set; }

        [Column("time_of_day")]
        [StringLength(50)]
        public string? TimeOfDay { get; set; }

        [Column("known_move_id")]
        public short? KnownMoveId { get; set; }

        [Column("known_move_type_id")]
        [StringLength(50)]
        public string? KnownMoveTypeId { get; set; }

        [Column("minimum_happiness")]
        public byte? MinimumHappiness { get; set; }

        [Column("minimum_beauty")]
        [StringLength(50)]
        public string? MinimumBeauty { get; set; }

        [Column("minimum_affection")]
        [StringLength(1)]
        public string? MinimumAffection { get; set; }

        [Column("relative_physical_stats")]
        public short? RelativePhysicalStats { get; set; }

        [Column("party_species_id")]
        public byte? PartySpeciesId { get; set; }

        [Column("party_type_id")]
        [StringLength(50)]
        public string? PartyTypeId { get; set; }

        [Column("trade_species_id")]
        public short? TradeSpeciesId { get; set; }

        [Column("needs_overworld_rain")]
        public byte? NeedsOverworldRain { get; set; }

        [Column("turn_upside_down")]
        public byte? TurnUpsideDown { get; set; }

        [Column("natures")]
        [StringLength(200)]
        public string? Natures { get; set; }
    }
}