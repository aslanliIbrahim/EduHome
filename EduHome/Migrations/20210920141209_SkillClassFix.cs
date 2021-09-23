using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class SkillClassFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Communication",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Development",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Innovation",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "TeamLeader",
                table: "Skills");

            migrationBuilder.AddColumn<string>(
                name: "SkillName",
                table: "Skills",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillName",
                table: "Skills");

            migrationBuilder.AddColumn<byte>(
                name: "Communication",
                table: "Skills",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Design",
                table: "Skills",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Development",
                table: "Skills",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Innovation",
                table: "Skills",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Language",
                table: "Skills",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "TeamLeader",
                table: "Skills",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
