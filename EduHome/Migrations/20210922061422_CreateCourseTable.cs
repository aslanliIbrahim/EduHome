using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CreateCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CourseDescription = table.Column<string>(nullable: false),
                    AboutCourse = table.Column<string>(nullable: false),
                    HowToApply = table.Column<string>(nullable: false),
                    Certification = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<string>(maxLength: 255, nullable: false),
                    ClassDuration = table.Column<string>(maxLength: 255, nullable: false),
                    SkillLevel = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: false),
                    StudentCount = table.Column<int>(nullable: false),
                    Assesments = table.Column<string>(maxLength: 255, nullable: false),
                    Cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
