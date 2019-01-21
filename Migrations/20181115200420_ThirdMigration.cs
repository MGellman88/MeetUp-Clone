using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBelt.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Activities_ActivityId1",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityId1",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityId1",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "Attendee",
                table: "Activities",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Event",
                table: "Activities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Event",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Activities",
                newName: "Attendee");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId1",
                table: "Activities",
                nullable: true);

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
        }
    }
}
