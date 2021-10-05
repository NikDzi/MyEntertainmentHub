using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class listmedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedia_Media_MediaID",
                table: "WatchListMedia");

            migrationBuilder.DropIndex(
                name: "IX_WatchListMedia_MediaID",
                table: "WatchListMedia");

            migrationBuilder.AddColumn<int>(
                name: "WatchListMediaID",
                table: "Media",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_WatchListMediaID",
                table: "Media",
                column: "WatchListMediaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_WatchListMedia_WatchListMediaID",
                table: "Media",
                column: "WatchListMediaID",
                principalTable: "WatchListMedia",
                principalColumn: "WatchListMediaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_WatchListMedia_WatchListMediaID",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_WatchListMediaID",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "WatchListMediaID",
                table: "Media");

            migrationBuilder.CreateIndex(
                name: "IX_WatchListMedia_MediaID",
                table: "WatchListMedia",
                column: "MediaID");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListMedia_Media_MediaID",
                table: "WatchListMedia",
                column: "MediaID",
                principalTable: "Media",
                principalColumn: "MediaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
