using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oesia.Data.Migrations
{
    public partial class AllTheModels10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteToLogFile",
                table: "UserSubtask");

            migrationBuilder.AddColumn<DateTime>(
                name: "PauseTime",
                table: "UserSubtask",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PlayTime",
                table: "UserSubtask",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordTime",
                table: "UserSubtask",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StopTime",
                table: "UserSubtask",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PauseTime",
                table: "UserSubtask");

            migrationBuilder.DropColumn(
                name: "PlayTime",
                table: "UserSubtask");

            migrationBuilder.DropColumn(
                name: "RecordTime",
                table: "UserSubtask");

            migrationBuilder.DropColumn(
                name: "StopTime",
                table: "UserSubtask");

            migrationBuilder.AddColumn<string>(
                name: "RouteToLogFile",
                table: "UserSubtask",
                nullable: true);
        }
    }
}
