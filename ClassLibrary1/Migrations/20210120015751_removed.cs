using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedia_WatchList_WatchListID",
                table: "WatchListMedia");

            migrationBuilder.DropTable(
                name: "WatchList");

            migrationBuilder.DropIndex(
                name: "IX_WatchListMedia_WatchListID",
                table: "WatchListMedia");

            migrationBuilder.DropColumn(
                name: "WatchListID",
                table: "WatchListMedia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WatchListID",
                table: "WatchListMedia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WatchList",
                columns: table => new
                {
                    WatchListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchList", x => x.WatchListID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WatchListMedia_WatchListID",
                table: "WatchListMedia",
                column: "WatchListID");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListMedia_WatchList_WatchListID",
                table: "WatchListMedia",
                column: "WatchListID",
                principalTable: "WatchList",
                principalColumn: "WatchListID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
