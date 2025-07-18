using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAuctionAPI.Models
{
    [Table("move_effect_prose")]
    public class Move_effect_prose
    {
        [Key]
        [Column("move_effect_id", Order = 0)]
        public int MoveEffectId { get; set; }

        [Key]
        [Column("local_language_id", Order = 1)]
        public byte LocalLanguageId { get; set; }

        [Column("short_effect")]
        [StringLength(150)]
        public string ShortEffect { get; set; } = string.Empty;

        [Column("effect")]
        public string? Effect { get; set; }
    }
}