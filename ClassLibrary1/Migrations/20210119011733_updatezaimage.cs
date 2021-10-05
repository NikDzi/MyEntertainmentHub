using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class updatezaimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Image",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_UserID",
                table: "Image",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_UserID",
                table: "Image",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_UserID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_UserID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Image");
        }
    }
}
