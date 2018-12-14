using Microsoft.EntityFrameworkCore.Migrations;

namespace Oesia.Data.Migrations
{
    public partial class UserIdInTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Task",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Task");
        }
    }
}
