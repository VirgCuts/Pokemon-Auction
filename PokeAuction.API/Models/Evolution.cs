using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAuctionAPI.Models
{
    [Table("evolution")]
    public class Evolution
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        public int EvolvedSpeciesId { get; set; }

        [Required]
        public int EvolutionTriggerId { get; set; }

        public int? TriggerItemId { get; set; }

        public byte? MinimumLevel { get; set; }

        public byte? GenderId { get; set; }

        [StringLength(1)]
        public string? LocationId { get; set; }

        public short? HeldItemId { get; set; }

        [StringLength(50)]
        public string? TimeOfDay { get; set; }

        public short? KnownMoveId { get; set; }

        [StringLength(50)]
        public string? KnownMoveTypeId { get; set; }

        public byte? MinimumHappiness { get; set; }

        [StringLength(50)]
        public string? MinimumBeauty { get; set; }

        [StringLength(1)]
        public string? MinimumAffection { get; set; }

        public short? RelativePhysicalStats { get; set; }

        public byte? PartySpeciesId { get; set; }

        [StringLength(50)]
        public string? PartyTypeId { get; set; }

        public short? TradeSpeciesId { get; set; }

        public byte? NeedsOverworldRain { get; set; }

        public byte? TurnUpsideDown { get; set; }

        [StringLength(200)]
        public string? Natures { get; set; }
    }
}