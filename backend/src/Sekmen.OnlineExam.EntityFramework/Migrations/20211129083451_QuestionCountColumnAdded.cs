using Microsoft.EntityFrameworkCore.Migrations;

namespace Sekmen.OnlineExam.Migrations
{
    public partial class QuestionCountColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionCount",
                table: "AppExams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionCount",
                table: "AppExams");
        }
    }
}
