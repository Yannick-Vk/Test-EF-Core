using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test_Ef.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landen",
                columns: table => new
                {
                    LandCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landen", x => x.LandCode);
                });

            migrationBuilder.CreateTable(
                name: "Talen",
                columns: table => new
                {
                    TaalCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talen", x => x.TaalCode);
                });

            migrationBuilder.CreateTable(
                name: "Steden",
                columns: table => new
                {
                    StadNr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LandCode = table.Column<string>(type: "nvarchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steden", x => x.StadNr);
                    table.ForeignKey(
                        name: "FK_Steden_Landen_LandCode",
                        column: x => x.LandCode,
                        principalTable: "Landen",
                        principalColumn: "LandCode");
                });

            migrationBuilder.CreateTable(
                name: "LandenTalen",
                columns: table => new
                {
                    LandenLandCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    TalenTaalCode = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandenTalen", x => new { x.LandenLandCode, x.TalenTaalCode });
                    table.ForeignKey(
                        name: "FK_LandenTalen_Landen_LandenLandCode",
                        column: x => x.LandenLandCode,
                        principalTable: "Landen",
                        principalColumn: "LandCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandenTalen_Talen_TalenTaalCode",
                        column: x => x.TalenTaalCode,
                        principalTable: "Talen",
                        principalColumn: "TaalCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Landen",
                columns: new[] { "LandCode", "Naam" },
                values: new object[,]
                {
                    { "BEL", "Belgie" },
                    { "DEU", "Duitsland" },
                    { "FRA", "Frankrijk" },
                    { "LUX", "Luxemburg" },
                    { "NLD", "Nederland" }
                });

            migrationBuilder.InsertData(
                table: "Talen",
                columns: new[] { "TaalCode", "Naam" },
                values: new object[,]
                {
                    { "de", "Duits" },
                    { "fr", "Frans" },
                    { "lb", "Luxemburgs" },
                    { "nl", "Nederlands" }
                });

            migrationBuilder.InsertData(
                table: "LandenTalen",
                columns: new[] { "LandenLandCode", "TalenTaalCode" },
                values: new object[,]
                {
                    { "BEL", "de" },
                    { "BEL", "fr" },
                    { "BEL", "nl" },
                    { "DEU", "de" },
                    { "FRA", "fr" },
                    { "LUX", "de" },
                    { "LUX", "fr" },
                    { "LUX", "lb" },
                    { "NLD", "nl" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LandenTalen_TalenTaalCode",
                table: "LandenTalen",
                column: "TalenTaalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Steden_LandCode",
                table: "Steden",
                column: "LandCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandenTalen");

            migrationBuilder.DropTable(
                name: "Steden");

            migrationBuilder.DropTable(
                name: "Talen");

            migrationBuilder.DropTable(
                name: "Landen");
        }
    }
}
