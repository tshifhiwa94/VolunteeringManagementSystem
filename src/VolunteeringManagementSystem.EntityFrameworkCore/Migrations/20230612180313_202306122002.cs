using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteeringManagementSystem.Migrations
{
    public partial class _202306122002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSkills_TaskAssigns_TaskAssignId",
                table: "TaskSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerSkills_TaskAssigns_TaskAssignId",
                table: "VolunteerSkills");

            migrationBuilder.DropIndex(
                name: "IX_VolunteerSkills_TaskAssignId",
                table: "VolunteerSkills");

            migrationBuilder.DropIndex(
                name: "IX_TaskSkills_TaskAssignId",
                table: "TaskSkills");

            migrationBuilder.DropColumn(
                name: "TaskAssignId",
                table: "VolunteerSkills");

            migrationBuilder.DropColumn(
                name: "EmployeeNo",
                table: "Vms_Persons");

            migrationBuilder.DropColumn(
                name: "TaskAssignId",
                table: "TaskSkills");

            migrationBuilder.DropColumn(
                name: "RequiredSkills",
                table: "TaskItems");

            migrationBuilder.RenameColumn(
                name: "Skills",
                table: "Vms_Persons",
                newName: "EmpoyeeNo");

            migrationBuilder.RenameColumn(
                name: "Submission",
                table: "TaskAssigns",
                newName: "FilePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpoyeeNo",
                table: "Vms_Persons",
                newName: "Skills");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "TaskAssigns",
                newName: "Submission");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskAssignId",
                table: "VolunteerSkills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNo",
                table: "Vms_Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TaskAssignId",
                table: "TaskSkills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequiredSkills",
                table: "TaskItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerSkills_TaskAssignId",
                table: "VolunteerSkills",
                column: "TaskAssignId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSkills_TaskAssignId",
                table: "TaskSkills",
                column: "TaskAssignId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSkills_TaskAssigns_TaskAssignId",
                table: "TaskSkills",
                column: "TaskAssignId",
                principalTable: "TaskAssigns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerSkills_TaskAssigns_TaskAssignId",
                table: "VolunteerSkills",
                column: "TaskAssignId",
                principalTable: "TaskAssigns",
                principalColumn: "Id");
        }
    }
}
