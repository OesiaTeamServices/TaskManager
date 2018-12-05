using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oesia.Data.Migrations
{
    public partial class AllTheModels02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubtaskId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EstimatedHours = table.Column<double>(nullable: false),
                    ElapsedHours = table.Column<double>(nullable: false),
                    PendingHours = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuleId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EstimatedHours = table.Column<double>(nullable: false),
                    ElapsedHours = table.Column<double>(nullable: false),
                    PendingHours = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ProjectId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Module_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProject",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppUsersId = table.Column<string>(nullable: true),
                    ProjectsId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProject_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProject_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Submodule",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubmoduleId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EstimatedHours = table.Column<double>(nullable: false),
                    ElapsedHours = table.Column<double>(nullable: false),
                    PendingHours = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ModuleId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submodule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submodule_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaskId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Criticality = table.Column<string>(nullable: true),
                    Priority = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    EstimatedStartDate = table.Column<DateTime>(nullable: false),
                    EstimatedEndDate = table.Column<DateTime>(nullable: false),
                    RealStartDate = table.Column<DateTime>(nullable: false),
                    RealEndDate = table.Column<DateTime>(nullable: false),
                    EstimatedHours = table.Column<double>(nullable: false),
                    ElapsedHours = table.Column<double>(nullable: false),
                    PendingHours = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    SubmoduleId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Submodule_SubmoduleId",
                        column: x => x.SubmoduleId,
                        principalTable: "Submodule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subtask",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubtaskId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EstimatedHours = table.Column<double>(nullable: false),
                    ElapsedHours = table.Column<double>(nullable: false),
                    PendingHours = table.Column<double>(nullable: false),
                    Observations = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    TaskId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subtask_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTask",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppUsersId = table.Column<string>(nullable: true),
                    TasksId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTask_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTask_Task_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSubtask",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RouteToLogFile = table.Column<string>(nullable: true),
                    AppUsersId = table.Column<string>(nullable: true),
                    SubtasksId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubtask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubtask_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSubtask_Subtask_SubtasksId",
                        column: x => x.SubtasksId,
                        principalTable: "Subtask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Module_ProjectId",
                table: "Module",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodule_ModuleId",
                table: "Submodule",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtask_TaskId",
                table: "Subtask",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_SubmoduleId",
                table: "Task",
                column: "SubmoduleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_AppUsersId",
                table: "UserProject",
                column: "AppUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_ProjectsId",
                table: "UserProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubtask_AppUsersId",
                table: "UserSubtask",
                column: "AppUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubtask_SubtasksId",
                table: "UserSubtask",
                column: "SubtasksId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTask_AppUsersId",
                table: "UserTask",
                column: "AppUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTask_TasksId",
                table: "UserTask",
                column: "TasksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProject");

            migrationBuilder.DropTable(
                name: "UserSubtask");

            migrationBuilder.DropTable(
                name: "UserTask");

            migrationBuilder.DropTable(
                name: "Subtask");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Submodule");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubtaskId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");
        }
    }
}
