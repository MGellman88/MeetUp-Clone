using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBelt.Migrations
{
    public partial class SeventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Activities_ActivityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ActivityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "Activities",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ActivityId",
                table: "Users",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Activities_ActivityId",
                table: "Users",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
