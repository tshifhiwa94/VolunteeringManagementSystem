using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteeringManagementSystem.Migrations
{
    public partial class _202306060920 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDay",
                table: "TaskAssigns",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "CompletedDay",
                table: "TaskAssigns",
                newName: "CompletedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "TaskAssigns",
                newName: "StartDay");

            migrationBuilder.RenameColumn(
                name: "CompletedDate",
                table: "TaskAssigns",
                newName: "CompletedDay");
        }
    }
}
