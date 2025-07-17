using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAuctionAPI.Models
{
    [Table("move")]
    public class Move
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Identifier { get; set; } = string.Empty;

        [Required]
        public byte GenerationId { get; set; }

        [Required]
        public int TypeId { get; set; }

        public byte? Power { get; set; }

        public byte? PP { get; set; }

        public byte? Accuracy { get; set; }

        public short? Priority { get; set; }

        public byte? TargetId { get; set; }

        public byte? DamageClassId { get; set; }

        public short? EffectId { get; set; }

        public byte? EffectChance { get; set; }

        public byte? ContestTypeId { get; set; }

        public byte? ContestEffectId { get; set; }

        public byte? SuperContestEffectId { get; set; }
    }
}