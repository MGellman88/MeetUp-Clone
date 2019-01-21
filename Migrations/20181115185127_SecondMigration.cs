using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBelt.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Users_UserId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Activity_ActivityId",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Users_UserId",
                table: "Participant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participant",
                table: "Participant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity",
                table: "Activity");

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participants");

            migrationBuilder.RenameTable(
                name: "Activity",
                newName: "Activities");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_UserId",
                table: "Participants",
                newName: "IX_Participants_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_ActivityId",
                table: "Participants",
                newName: "IX_Participants_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_UserId",
                table: "Activities",
                newName: "IX_Activities_UserId");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId1",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "ParticipantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityId1",
                table: "Activities",
                column: "ActivityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Activities_ActivityId1",
                table: "Activities",
                column: "ActivityId1",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Users_UserId",
                table: "Activities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Activities_ActivityId",
                table: "Participants",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Users_UserId",
                table: "Participants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Activities_ActivityId1",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Users_UserId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Activities_ActivityId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Users_UserId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityId1",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityId1",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participant");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "Activity");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_UserId",
                table: "Participant",
                newName: "IX_Participant_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_ActivityId",
                table: "Participant",
                newName: "IX_Participant_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_UserId",
                table: "Activity",
                newName: "IX_Activity_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participant",
                table: "Participant",
                column: "ParticipantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity",
                table: "Activity",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Users_UserId",
                table: "Activity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Activity_ActivityId",
                table: "Participant",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Users_UserId",
                table: "Participant",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
