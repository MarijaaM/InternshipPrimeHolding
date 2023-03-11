using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipPrimeHolding.Migrations
{
    public partial class TaskStatusHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "WorkTasks");

            migrationBuilder.DropColumn(
                name: "TaskDone",
                table: "WorkTasks");

            migrationBuilder.CreateTable(
                name: "TaskStateHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorkTaskId = table.Column<long>(type: "INTEGER", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStateHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskStateHistory_WorkTasks_WorkTaskId",
                        column: x => x.WorkTaskId,
                        principalTable: "WorkTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskStateHistory_WorkTaskId",
                table: "TaskStateHistory",
                column: "WorkTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskStateHistory");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "WorkTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TaskDone",
                table: "WorkTasks",
                type: "TEXT",
                nullable: true);
        }
    }
}
