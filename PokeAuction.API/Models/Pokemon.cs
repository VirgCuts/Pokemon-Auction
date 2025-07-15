namespace PokeAuctionAPI.Models;

public class Pokemon
{
    public int Id { get; set; }
    public int DexNumber { get; set; }
    public string Region { get; set; } = "";
    public string Slug { get; set; } = "";
    public string Description { get; set; } = "";
    public string Name { get; set; } = "";
    public string Type1 { get; set; } = "";
    public string? Type2 { get; set; }
    public int BaseHp { get; set; }
    public int BaseAtk { get; set; }
    public int BaseDef { get; set; }
    public int BaseSpAtk { get; set; }
    public int BaseSpDef { get; set; }
    public int BaseSpeed { get; set; }
}
