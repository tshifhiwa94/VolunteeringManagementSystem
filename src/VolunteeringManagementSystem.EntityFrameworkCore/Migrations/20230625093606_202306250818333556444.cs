using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteeringManagementSystem.Migrations
{
    public partial class _202306250818333556444 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Document",
                table: "TaskAssigns");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "TaskAssigns",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "TaskAssigns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "TaskAssigns",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
