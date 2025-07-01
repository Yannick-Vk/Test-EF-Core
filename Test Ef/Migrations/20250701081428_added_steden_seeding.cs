using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test_Ef.Migrations
{
    /// <inheritdoc />
    public partial class added_steden_seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steden_Landen_LandCode",
                table: "Steden");

            migrationBuilder.AlterColumn<string>(
                name: "LandCode",
                table: "Steden",
                type: "nvarchar(3)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Steden",
                columns: new[] { "StadNr", "LandCode", "Naam" },
                values: new object[,]
                {
                    { 1, "BEL", "Brussel" },
                    { 2, "BEL", "Antwerpen" },
                    { 3, "BEL", "Luik" },
                    { 4, "NLD", "Amsterdam" },
                    { 5, "NLD", "Den Haag" },
                    { 6, "NLD", "Rotterdam" },
                    { 7, "DEU", "Berlijn" },
                    { 8, "DEU", "Hamburg" },
                    { 9, "DEU", "Munchen" },
                    { 10, "LUX", "Luxemburg" },
                    { 11, "FRA", "Parijs" },
                    { 12, "FRA", "Marseille" },
                    { 13, "FRA", "Lyon" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Steden_Landen_LandCode",
                table: "Steden",
                column: "LandCode",
                principalTable: "Landen",
                principalColumn: "LandCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steden_Landen_LandCode",
                table: "Steden");

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 13);

            migrationBuilder.AlterColumn<string>(
                name: "LandCode",
                table: "Steden",
                type: "nvarchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)");

            migrationBuilder.AddForeignKey(
                name: "FK_Steden_Landen_LandCode",
                table: "Steden",
                column: "LandCode",
                principalTable: "Landen",
                principalColumn: "LandCode");
        }
    }
}
