using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class specsmedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_TechnicalSpecifications_TechnicalSpecificationsID",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_TechnicalSpecificationsID",
                table: "Media");

            migrationBuilder.AddColumn<int>(
                name: "MediaID",
                table: "TechnicalSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechnicalSpecificationsID1",
                table: "Media",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_TechnicalSpecificationsID1",
                table: "Media",
                column: "TechnicalSpecificationsID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_TechnicalSpecifications_TechnicalSpecificationsID1",
                table: "Media",
                column: "TechnicalSpecificationsID1",
                principalTable: "TechnicalSpecifications",
                principalColumn: "TechnicalSpecificationsID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_TechnicalSpecifications_TechnicalSpecificationsID1",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_TechnicalSpecificationsID1",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "MediaID",
                table: "TechnicalSpecifications");

            migrationBuilder.DropColumn(
                name: "TechnicalSpecificationsID1",
                table: "Media");

            migrationBuilder.CreateIndex(
                name: "IX_Media_TechnicalSpecificationsID",
                table: "Media",
                column: "TechnicalSpecificationsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_TechnicalSpecifications_TechnicalSpecificationsID",
                table: "Media",
                column: "TechnicalSpecificationsID",
                principalTable: "TechnicalSpecifications",
                principalColumn: "TechnicalSpecificationsID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
