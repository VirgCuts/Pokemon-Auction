using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAuctionAPI.Models
{
    [Table("move_effect_prose")]
    public class Move_effect_prose
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        public int MoveEffectId { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        public byte LocalLanguageId { get; set; }

        [Required]
        [StringLength(150)]
        public string ShortEffect { get; set; } = string.Empty;

        public string? Effect { get; set; }
    }
}