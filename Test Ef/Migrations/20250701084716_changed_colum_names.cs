using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Ef.Migrations
{
    /// <inheritdoc />
    public partial class changed_colum_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandenTalen_Landen_LandenLandCode",
                table: "LandenTalen");

            migrationBuilder.DropForeignKey(
                name: "FK_LandenTalen_Talen_TalenTaalCode",
                table: "LandenTalen");

            migrationBuilder.RenameColumn(
                name: "TalenTaalCode",
                table: "LandenTalen",
                newName: "TaalCode");

            migrationBuilder.RenameColumn(
                name: "LandenLandCode",
                table: "LandenTalen",
                newName: "LandCode");

            migrationBuilder.RenameIndex(
                name: "IX_LandenTalen_TalenTaalCode",
                table: "LandenTalen",
                newName: "IX_LandenTalen_TaalCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LandenTalen_Landen_LandCode",
                table: "LandenTalen",
                column: "LandCode",
                principalTable: "Landen",
                principalColumn: "LandCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LandenTalen_Talen_TaalCode",
                table: "LandenTalen",
                column: "TaalCode",
                principalTable: "Talen",
                principalColumn: "TaalCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandenTalen_Landen_LandCode",
                table: "LandenTalen");

            migrationBuilder.DropForeignKey(
                name: "FK_LandenTalen_Talen_TaalCode",
                table: "LandenTalen");

            migrationBuilder.RenameColumn(
                name: "TaalCode",
                table: "LandenTalen",
                newName: "TalenTaalCode");

            migrationBuilder.RenameColumn(
                name: "LandCode",
                table: "LandenTalen",
                newName: "LandenLandCode");

            migrationBuilder.RenameIndex(
                name: "IX_LandenTalen_TaalCode",
                table: "LandenTalen",
                newName: "IX_LandenTalen_TalenTaalCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LandenTalen_Landen_LandenLandCode",
                table: "LandenTalen",
                column: "LandenLandCode",
                principalTable: "Landen",
                principalColumn: "LandCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LandenTalen_Talen_TalenTaalCode",
                table: "LandenTalen",
                column: "TalenTaalCode",
                principalTable: "Talen",
                principalColumn: "TaalCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
