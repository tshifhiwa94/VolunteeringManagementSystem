using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteeringManagementSystem.Migrations
{
    public partial class _2023060615147767545644678990 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Vms_Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequiredSkills",
                table: "TaskItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Vms_Persons");

            migrationBuilder.DropColumn(
                name: "RequiredSkills",
                table: "TaskItems");
        }
    }
}
