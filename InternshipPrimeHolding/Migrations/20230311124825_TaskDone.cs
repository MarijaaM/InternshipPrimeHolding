using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipPrimeHolding.Migrations
{
    public partial class TaskDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TaskDone",
                table: "WorkTasks",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskDone",
                table: "WorkTasks");
        }
    }
}
