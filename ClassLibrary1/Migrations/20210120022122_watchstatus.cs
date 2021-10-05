using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class watchstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedia_WatchStatus_WatchStatusID",
                table: "WatchListMedia");

            migrationBuilder.DropIndex(
                name: "IX_WatchListMedia_WatchStatusID",
                table: "WatchListMedia");

            migrationBuilder.DropColumn(
                name: "WatchStatusID",
                table: "WatchListMedia");

            migrationBuilder.AddColumn<string>(
                name: "Watchstatus",
                table: "WatchListMedia",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Watchstatus",
                table: "WatchListMedia");

            migrationBuilder.AddColumn<int>(
                name: "WatchStatusID",
                table: "WatchListMedia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchListMedia_WatchStatusID",
                table: "WatchListMedia",
                column: "WatchStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListMedia_WatchStatus_WatchStatusID",
                table: "WatchListMedia",
                column: "WatchStatusID",
                principalTable: "WatchStatus",
                principalColumn: "WatchStatusID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
