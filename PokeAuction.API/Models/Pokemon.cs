using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAuctionAPI.Models
{
    [Table("pokemon")]
    public class Pokemon
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("dex_number")]
        public short? DexNumber { get; set; }

        [Column("region")]
        [StringLength(50)]
        public string? Region { get; set; }

        [Column("slug")]
        [StringLength(50)]
        public string? Slug { get; set; }

        [Column("description")]
        [StringLength(1000)]
        public string? Description { get; set; }

        [Column("credit")]
        [StringLength(250)]
        public string? Credit { get; set; }

        [Column("enabled")]
        public byte? Enabled { get; set; }  // tinyint in DB

        [Column("catchable")]
        public byte? Catchable { get; set; }  // tinyint in DB

        [Column("abundance")]
        public short? Abundance { get; set; }  // smallint in DB

        [Column("gender_rate")]
        public short? GenderRate { get; set; }  // smallint in DB

        [Column("has_gender_differences")]
        public bool? HasGenderDifferences { get; set; }  // bit in DB

        [Column("name_ja")]
        [StringLength(50)]
        public string? NameJa { get; set; }

        [Column("name_ja_r")]
        [StringLength(50)]
        public string? NameJaR { get; set; }

        [Column("name_ja_t")]
        [StringLength(50)]
        public string? NameJaT { get; set; }

        [Column("name_de")]
        [StringLength(50)]
        public string? NameDe { get; set; }

        [Column("name_en")]
        [StringLength(50)]
        public string? NameEn { get; set; }

        [Column("name_en2")]
        [StringLength(50)]
        public string? NameEn2 { get; set; }

        [Column("name_fr")]
        [StringLength(50)]
        public string? NameFr { get; set; }

        [Column("base_hp")]
        public byte? BaseHp { get; set; }  // tinyint in DB

        [Column("base_atk")]
        public byte? BaseAtk { get; set; }  // tinyint in DB

        [Column("base_def")]
        public byte? BaseDef { get; set; }  // tinyint in DB

        [Column("base_satk")]
        public byte? BaseSatk { get; set; }  // tinyint in DB

        [Column("base_sdef")]
        public byte? BaseSdef { get; set; }  // tinyint in DB

        [Column("base_spd")]
        public byte? BaseSpd { get; set; }  // tinyint in DB

        [Column("type_0")]
        [StringLength(50)]
        public string? Type0 { get; set; }  // nvarchar in DB

        [Column("type_1")]
        [StringLength(50)]
        public string? Type1 { get; set; }  // nvarchar in DB

        [Column("height")]
        public short? Height { get; set; }

        [Column("weight")]
        public short? Weight { get; set; }

        [Column("legendary")]
        public byte? Legendary { get; set; }  // tinyint in DB

        [Column("mythical")]
        public byte? Mythical { get; set; }  // tinyint in DB

        [Column("ultra_beast")]
        [StringLength(1)]
        public string? UltraBeast { get; set; }  // nvarchar(1) in DB

        [Column("event")]
        [StringLength(1)]
        public string? Event { get; set; }  // nvarchar(1) in DB

        [Column("is_form")]
        [StringLength(1)]
        public string? IsForm { get; set; }  // nvarchar(1) in DB

        [Column("form_item")]
        [StringLength(50)]
        public string? FormItem { get; set; }

        [Column("evo_from")]
        public long? EvoFrom { get; set; }  // bigint in DB

        [Column("evo_to")]
        [StringLength(250)]
        public string? EvoTo { get; set; }

        [Column("evo_mega")]
        public short? EvoMega { get; set; }  // smallint in DB

        [Column("evo_mega_x")]
        public short? EvoMegaX { get; set; }  // smallint in DB

        [Column("evo_mega_y")]
        public short? EvoMegaY { get; set; }  // smallint in DB
    }
}