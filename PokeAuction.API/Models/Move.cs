using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAuctionAPI.Models
{
    [Table("move")]
    public class Move
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        [StringLength(50)]
        public string Identifier { get; set; } = string.Empty;

        [Column("generation_id")]
        public byte GenerationId { get; set; }

        [Column("type_id")]
        public int TypeId { get; set; }

        [Column("power")]
        public byte? Power { get; set; }

        [Column("pp")]
        public byte? PP { get; set; }

        [Column("accuracy")]
        public byte? Accuracy { get; set; }

        [Column("priority")]
        public short? Priority { get; set; }

        [Column("target_id")]
        public byte? TargetId { get; set; }

        [Column("damage_class_id")]
        public byte? DamageClassId { get; set; }

        [Column("effect_id")]
        public short? EffectId { get; set; }

        [Column("effect_chance")]
        public byte? EffectChance { get; set; }

        [Column("contest_type_id")]
        public byte? ContestTypeId { get; set; }

        [Column("contest_effect_id")]
        public byte? ContestEffectId { get; set; }

        [Column("super_contest_effect_id")]
        public byte? SuperContestEffectId { get; set; }
    }
}