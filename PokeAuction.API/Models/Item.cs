using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAuctionAPI.Models
{
    [Table("item")]
    public class Item
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        [StringLength(150)]
        public string? Description { get; set; }

        [Column("cost")]
        public short Cost { get; set; }

        [Column("shard")]
        public byte? Shard { get; set; }

        [Column("action")]
        [StringLength(50)]
        public string Action { get; set; } = string.Empty;

        [Column("page")]
        public byte Page { get; set; }

        [Column("emote")]
        [StringLength(50)]
        public string? Emote { get; set; }

        [Column("separate")]
        public byte? Separate { get; set; }
    }
}