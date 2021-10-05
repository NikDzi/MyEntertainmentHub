using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class user_na_Watchlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedia_WatchList_WatchListID",
                table: "WatchListMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedia_WatchStatus_WatchStatusID",
                table: "WatchListMedia");

            migrationBuilder.AlterColumn<int>(
                name: "WatchStatusID",
                table: "WatchListMedia",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WatchListID",
                table: "WatchListMedia",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MediaID",
                table: "WatchListMedia",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "WatchListMedia",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchListMedia_UserID",
                table: "WatchListMedia",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListMedia_AspNetUsers_UserID",
                table: "WatchListMedia",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListMedia_WatchList_WatchListID",
                table: "WatchListMedia",
                column: "WatchListID",
                principalTable: "WatchList",
                principalColumn: "WatchListID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListMedia_WatchStatus_WatchStatusID",
                table: "WatchListMedia",
                column: "WatchStatusID",
                principalTable: "WatchStatus",
                principalColumn: "WatchStatusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedia_AspNetUsers_UserID",
                table: "WatchListMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedia_WatchList_WatchListID",
                table: "WatchListMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedia_WatchStatus_WatchStatusID",
                table: "WatchListMedia");

            migrationBuilder.DropIndex(
                name: "IX_WatchListMedia_UserID",
                table: "WatchListMedia");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "WatchListMedia");

            migrationBuilder.AlterColumn<int>(
                name: "WatchStatusID",
                table: "WatchListMedia",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WatchListID",
                table: "WatchListMedia",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MediaID",
                table: "WatchListMedia",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListMedia_WatchList_WatchListID",
                table: "WatchListMedia",
                column: "WatchListID",
                principalTable: "WatchList",
                principalColumn: "WatchListID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListMedia_WatchStatus_WatchStatusID",
                table: "WatchListMedia",
                column: "WatchStatusID",
                principalTable: "WatchStatus",
                principalColumn: "WatchStatusID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
