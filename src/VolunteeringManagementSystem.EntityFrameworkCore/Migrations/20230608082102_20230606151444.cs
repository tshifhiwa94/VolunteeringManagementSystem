using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteeringManagementSystem.Migrations
{
    public partial class _20230606151444 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Vms_Persons");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Vms_Persons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequiredSkills",
                table: "TaskAssigns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Province",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vms_Persons_AddressId",
                table: "Vms_Persons",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vms_Persons_Address_AddressId",
                table: "Vms_Persons",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vms_Persons_Address_AddressId",
                table: "Vms_Persons");

            migrationBuilder.DropIndex(
                name: "IX_Vms_Persons_AddressId",
                table: "Vms_Persons");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Vms_Persons");

            migrationBuilder.DropColumn(
                name: "RequiredSkills",
                table: "TaskAssigns");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Vms_Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
