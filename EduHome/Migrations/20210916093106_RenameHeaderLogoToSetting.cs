using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class RenameHeaderLogoToSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HeaderLogos",
                table: "HeaderLogos");

            migrationBuilder.RenameTable(
                name: "HeaderLogos",
                newName: "Settings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Settings",
                table: "Settings",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Settings",
                table: "Settings");

            migrationBuilder.RenameTable(
                name: "Settings",
                newName: "HeaderLogos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeaderLogos",
                table: "HeaderLogos",
                column: "Id");
        }
    }
}
