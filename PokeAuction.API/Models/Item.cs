using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAuctionAPI.Models
{
    [Table("item")]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(150)]
        public string? Description { get; set; }

        [Required]
        public short Cost { get; set; }

        public byte? Shard { get; set; }

        [Required]
        [StringLength(50)]
        public string Action { get; set; } = string.Empty;

        [Required]
        public byte Page { get; set; }

        [StringLength(50)]
        public string? Emote { get; set; }

        public byte? Separate { get; set; }
    }
}