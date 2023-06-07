using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteeringManagementSystem.Migrations
{
    public partial class _202306061512 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Title",
                table: "Vms_Persons");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Vms_Persons",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "Vms_Persons",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Vms_Persons");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Vms_Persons",
                newName: "Password");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Vms_Persons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Title",
                table: "Vms_Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
