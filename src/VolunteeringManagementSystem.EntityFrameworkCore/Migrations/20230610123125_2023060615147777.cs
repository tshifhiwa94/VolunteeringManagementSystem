using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteeringManagementSystem.Migrations
{
    public partial class _2023060615147777 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileAttachment",
                table: "TaskAssigns");

            migrationBuilder.DropColumn(
                name: "IsSubmitted",
                table: "TaskAssigns");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "RequiredSkills",
                table: "TaskAssigns",
                newName: "Submission");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "TaskAssigns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TaskAssigns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TaskAssignId",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskSkill_TaskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_TaskAssignId",
                table: "Skills",
                column: "TaskAssignId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSkill_SkillId",
                table: "TaskSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSkill_TaskItemId",
                table: "TaskSkill",
                column: "TaskItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_TaskAssigns_TaskAssignId",
                table: "Skills",
                column: "TaskAssignId",
                principalTable: "TaskAssigns",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_TaskAssigns_TaskAssignId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "TaskSkill");

            migrationBuilder.DropIndex(
                name: "IX_Skills_TaskAssignId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "TaskAssigns");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TaskAssigns");

            migrationBuilder.DropColumn(
                name: "TaskAssignId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "Submission",
                table: "TaskAssigns",
                newName: "RequiredSkills");

            migrationBuilder.AddColumn<string>(
                name: "FileAttachment",
                table: "TaskAssigns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmitted",
                table: "TaskAssigns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
