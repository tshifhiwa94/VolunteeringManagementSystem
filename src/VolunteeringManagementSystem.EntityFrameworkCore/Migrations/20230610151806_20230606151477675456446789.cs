using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteeringManagementSystem.Migrations
{
    public partial class _20230606151477675456446789 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_TaskAssigns_TaskAssignId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_TaskAssignId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "TaskAssignId",
                table: "Skills");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskAssignId",
                table: "VolunteerSkills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaskAssignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_TaskSkill_TaskAssigns_TaskAssignId",
                        column: x => x.TaskAssignId,
                        principalTable: "TaskAssigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskSkill_TaskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerSkills_TaskAssignId",
                table: "VolunteerSkills",
                column: "TaskAssignId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSkill_SkillId",
                table: "TaskSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSkill_TaskAssignId",
                table: "TaskSkill",
                column: "TaskAssignId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSkill_TaskItemId",
                table: "TaskSkill",
                column: "TaskItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerSkills_TaskAssigns_TaskAssignId",
                table: "VolunteerSkills",
                column: "TaskAssignId",
                principalTable: "TaskAssigns",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerSkills_TaskAssigns_TaskAssignId",
                table: "VolunteerSkills");

            migrationBuilder.DropTable(
                name: "TaskSkill");

            migrationBuilder.DropIndex(
                name: "IX_VolunteerSkills_TaskAssignId",
                table: "VolunteerSkills");

            migrationBuilder.DropColumn(
                name: "TaskAssignId",
                table: "VolunteerSkills");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "TaskItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TaskAssignId",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_TaskAssignId",
                table: "Skills",
                column: "TaskAssignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_TaskAssigns_TaskAssignId",
                table: "Skills",
                column: "TaskAssignId",
                principalTable: "TaskAssigns",
                principalColumn: "Id");
        }
    }
}
