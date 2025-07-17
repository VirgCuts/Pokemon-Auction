using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAuctionAPI.Models
{
    [Table("pokemon_Moves")]
    public class Pokemon_Move
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        public int PokemonId { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        public byte VersionGroupId { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        public short MoveId { get; set; }

        [Key]
        [Column(Order = 3)]
        [Required]
        public byte PokemonMoveMethodId { get; set; }

        public byte? Level { get; set; }

        public byte? Order { get; set; }
    }
}