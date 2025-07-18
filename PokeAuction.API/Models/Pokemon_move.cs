using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAuctionAPI.Models
{
    [Table("pokemon_move")]
    public class Pokemon_move
    {
        [Key]
        [Column("pokemon_id", Order = 0)]
        public int PokemonId { get; set; }

        [Key]
        [Column("version_group_id", Order = 1)]
        public byte VersionGroupId { get; set; }

        [Key]
        [Column("move_id", Order = 2)]
        public short MoveId { get; set; }

        [Key]
        [Column("pokemon_move_method_id", Order = 3)]
        public byte PokemonMoveMethodId { get; set; }

        [Column("level")]
        public byte? Level { get; set; }

        [Column("order")]
        public byte? Order { get; set; }
    }
}