using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteeringManagementSystem.Migrations
{
    public partial class _202306061514776754564467899090 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSkill_Skills_SkillId",
                table: "TaskSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSkill_TaskAssigns_TaskAssignId",
                table: "TaskSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSkill_TaskItems_TaskItemId",
                table: "TaskSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskSkill",
                table: "TaskSkill");

            migrationBuilder.RenameTable(
                name: "TaskSkill",
                newName: "TaskSkills");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSkill_TaskItemId",
                table: "TaskSkills",
                newName: "IX_TaskSkills_TaskItemId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSkill_TaskAssignId",
                table: "TaskSkills",
                newName: "IX_TaskSkills_TaskAssignId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSkill_SkillId",
                table: "TaskSkills",
                newName: "IX_TaskSkills_SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskSkills",
                table: "TaskSkills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSkills_Skills_SkillId",
                table: "TaskSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSkills_TaskAssigns_TaskAssignId",
                table: "TaskSkills",
                column: "TaskAssignId",
                principalTable: "TaskAssigns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSkills_TaskItems_TaskItemId",
                table: "TaskSkills",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSkills_Skills_SkillId",
                table: "TaskSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSkills_TaskAssigns_TaskAssignId",
                table: "TaskSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSkills_TaskItems_TaskItemId",
                table: "TaskSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskSkills",
                table: "TaskSkills");

            migrationBuilder.RenameTable(
                name: "TaskSkills",
                newName: "TaskSkill");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSkills_TaskItemId",
                table: "TaskSkill",
                newName: "IX_TaskSkill_TaskItemId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSkills_TaskAssignId",
                table: "TaskSkill",
                newName: "IX_TaskSkill_TaskAssignId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSkills_SkillId",
                table: "TaskSkill",
                newName: "IX_TaskSkill_SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskSkill",
                table: "TaskSkill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSkill_Skills_SkillId",
                table: "TaskSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSkill_TaskAssigns_TaskAssignId",
                table: "TaskSkill",
                column: "TaskAssignId",
                principalTable: "TaskAssigns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSkill_TaskItems_TaskItemId",
                table: "TaskSkill",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id");
        }
    }
}
