using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeAuction.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "evolution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvolvedSpeciesId = table.Column<int>(type: "int", nullable: false),
                    EvolutionTriggerId = table.Column<int>(type: "int", nullable: false),
                    TriggerItemId = table.Column<int>(type: "int", nullable: true),
                    MinimumLevel = table.Column<byte>(type: "tinyint", nullable: true),
                    GenderId = table.Column<byte>(type: "tinyint", nullable: true),
                    LocationId = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    HeldItemId = table.Column<short>(type: "smallint", nullable: true),
                    TimeOfDay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KnownMoveId = table.Column<short>(type: "smallint", nullable: true),
                    KnownMoveTypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MinimumHappiness = table.Column<byte>(type: "tinyint", nullable: true),
                    MinimumBeauty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MinimumAffection = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    RelativePhysicalStats = table.Column<short>(type: "smallint", nullable: true),
                    PartySpeciesId = table.Column<byte>(type: "tinyint", nullable: true),
                    PartyTypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TradeSpeciesId = table.Column<short>(type: "smallint", nullable: true),
                    NeedsOverworldRain = table.Column<byte>(type: "tinyint", nullable: true),
                    TurnUpsideDown = table.Column<byte>(type: "tinyint", nullable: true),
                    Natures = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evolution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Cost = table.Column<short>(type: "smallint", nullable: false),
                    Shard = table.Column<byte>(type: "tinyint", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Page = table.Column<byte>(type: "tinyint", nullable: false),
                    Emote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Separate = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "move",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GenerationId = table.Column<byte>(type: "tinyint", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<byte>(type: "tinyint", nullable: true),
                    PP = table.Column<byte>(type: "tinyint", nullable: true),
                    Accuracy = table.Column<byte>(type: "tinyint", nullable: true),
                    Priority = table.Column<short>(type: "smallint", nullable: true),
                    TargetId = table.Column<byte>(type: "tinyint", nullable: true),
                    DamageClassId = table.Column<byte>(type: "tinyint", nullable: true),
                    EffectId = table.Column<short>(type: "smallint", nullable: true),
                    EffectChance = table.Column<byte>(type: "tinyint", nullable: true),
                    ContestTypeId = table.Column<byte>(type: "tinyint", nullable: true),
                    ContestEffectId = table.Column<byte>(type: "tinyint", nullable: true),
                    SuperContestEffectId = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_move", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "move_effect_prose",
                columns: table => new
                {
                    MoveEffectId = table.Column<int>(type: "int", nullable: false),
                    LocalLanguageId = table.Column<byte>(type: "tinyint", nullable: false),
                    ShortEffect = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_move_effect_prose", x => new { x.MoveEffectId, x.LocalLanguageId });
                });

            migrationBuilder.CreateTable(
                name: "pokemon",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dex_number = table.Column<short>(type: "smallint", nullable: true),
                    region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    credit = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    enabled = table.Column<byte>(type: "tinyint", nullable: true),
                    catchable = table.Column<byte>(type: "tinyint", nullable: true),
                    abundance = table.Column<short>(type: "smallint", nullable: true),
                    gender_rate = table.Column<short>(type: "smallint", nullable: true),
                    has_gender_differences = table.Column<bool>(type: "bit", nullable: true),
                    name_ja = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    name_ja_r = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    name_ja_t = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    name_de = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    name_en2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    name_fr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    base_hp = table.Column<byte>(type: "tinyint", nullable: true),
                    base_atk = table.Column<byte>(type: "tinyint", nullable: true),
                    base_def = table.Column<byte>(type: "tinyint", nullable: true),
                    base_satk = table.Column<byte>(type: "tinyint", nullable: true),
                    base_sdef = table.Column<byte>(type: "tinyint", nullable: true),
                    base_spd = table.Column<byte>(type: "tinyint", nullable: true),
                    type_0 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    type_1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    height = table.Column<short>(type: "smallint", nullable: true),
                    weight = table.Column<short>(type: "smallint", nullable: true),
                    legendary = table.Column<byte>(type: "tinyint", nullable: true),
                    mythical = table.Column<byte>(type: "tinyint", nullable: true),
                    ultra_beast = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    @event = table.Column<string>(name: "event", type: "nvarchar(1)", maxLength: 1, nullable: true),
                    is_form = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    form_item = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    evo_from = table.Column<long>(type: "bigint", nullable: true),
                    evo_to = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    evo_mega = table.Column<short>(type: "smallint", nullable: true),
                    evo_mega_x = table.Column<short>(type: "smallint", nullable: true),
                    evo_mega_y = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pokemon_move",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "int", nullable: false),
                    VersionGroupId = table.Column<byte>(type: "tinyint", nullable: false),
                    MoveId = table.Column<short>(type: "smallint", nullable: false),
                    PokemonMoveMethodId = table.Column<byte>(type: "tinyint", nullable: false),
                    Level = table.Column<byte>(type: "tinyint", nullable: true),
                    Order = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemon_move", x => new { x.PokemonId, x.VersionGroupId, x.MoveId, x.PokemonMoveMethodId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "evolution");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "move");

            migrationBuilder.DropTable(
                name: "move_effect_prose");

            migrationBuilder.DropTable(
                name: "pokemon");

            migrationBuilder.DropTable(
                name: "pokemon_move");
        }
    }
}
