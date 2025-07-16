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
                name: "pokemon",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dex_number = table.Column<short>(type: "smallint", nullable: false),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    credit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enabled = table.Column<byte>(type: "tinyint", nullable: false),
                    catchable = table.Column<byte>(type: "tinyint", nullable: false),
                    abundance = table.Column<short>(type: "smallint", nullable: false),
                    gender_rate = table.Column<short>(type: "smallint", nullable: false),
                    has_gender_differences = table.Column<bool>(type: "bit", nullable: false),
                    name_ja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_ja_r = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_ja_t = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_en2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_de = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_fr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_0 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mythical = table.Column<byte>(type: "tinyint", nullable: true),
                    legendary = table.Column<byte>(type: "tinyint", nullable: true),
                    ultra_beast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    @event = table.Column<string>(name: "event", type: "nvarchar(max)", nullable: true),
                    height = table.Column<short>(type: "smallint", nullable: false),
                    weight = table.Column<short>(type: "smallint", nullable: false),
                    evo_to = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evo_from = table.Column<long>(type: "bigint", nullable: true),
                    base_hp = table.Column<byte>(type: "tinyint", nullable: false),
                    base_atk = table.Column<byte>(type: "tinyint", nullable: false),
                    base_def = table.Column<byte>(type: "tinyint", nullable: false),
                    base_satk = table.Column<byte>(type: "tinyint", nullable: false),
                    base_sdef = table.Column<byte>(type: "tinyint", nullable: false),
                    base_spd = table.Column<byte>(type: "tinyint", nullable: false),
                    evo_mega = table.Column<short>(type: "smallint", nullable: true),
                    evo_mega_x = table.Column<short>(type: "smallint", nullable: true),
                    evo_mega_y = table.Column<short>(type: "smallint", nullable: true),
                    is_form = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    form_item = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemon", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pokemon");
        }
    }
}
