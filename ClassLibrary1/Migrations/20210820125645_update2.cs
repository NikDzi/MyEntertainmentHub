using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_TechnicalSpecifications_TechnicalSpecificationsID",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedia_Media_MediaID",
                table: "WatchListMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedia_WatchList_WatchListID",
                table: "WatchListMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedia_WatchStatus_WatchStatusID",
                table: "WatchListMedia");

            migrationBuilder.DropTable(
                name: "WatchList");

            migrationBuilder.DropIndex(
                name: "IX_WatchListMedia_MediaID",
                table: "WatchListMedia");

            migrationBuilder.DropIndex(
                name: "IX_WatchListMedia_WatchListID",
                table: "WatchListMedia");

            migrationBuilder.DropIndex(
                name: "IX_WatchListMedia_WatchStatusID",
                table: "WatchListMedia");

            migrationBuilder.DropIndex(
                name: "IX_Media_TechnicalSpecificationsID",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "WatchListID",
                table: "WatchListMedia");

            migrationBuilder.DropColumn(
                name: "WatchStatusID",
                table: "WatchListMedia");

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

            migrationBuilder.AddColumn<string>(
                name: "Watchstatus",
                table: "WatchListMedia",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaID",
                table: "TechnicalSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityTestValue",
                table: "MistakeTickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "MistakeTickets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechnicalSpecificationsID1",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WatchListMediaID",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Image",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MediaID",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reports",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Comments",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "City",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Bans",
                columns: table => new
                {
                    BanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.BanID);
                });

            migrationBuilder.CreateTable(
                name: "CommentReports",
                columns: table => new
                {
                    ReportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReports", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK_CommentReports_Comments_CommentID",
                        column: x => x.CommentID,
                        principalTable: "Comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WatchListMedia_UserID",
                table: "WatchListMedia",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MistakeTickets_UserID",
                table: "MistakeTickets",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Media_TechnicalSpecificationsID1",
                table: "Media",
                column: "TechnicalSpecificationsID1");

            migrationBuilder.CreateIndex(
                name: "IX_Media_WatchListMediaID",
                table: "Media",
                column: "WatchListMediaID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_UserID",
                table: "Image",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MediaID",
                table: "Comments",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReports_CommentID",
                table: "CommentReports",
                column: "CommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Media_MediaID",
                table: "Comments",
                column: "MediaID",
                principalTable: "Media",
                principalColumn: "MediaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserID",
                table: "Comments",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_UserID",
                table: "Image",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_TechnicalSpecifications_TechnicalSpecificationsID1",
                table: "Media",
                column: "TechnicalSpecificationsID1",
                principalTable: "TechnicalSpecifications",
                principalColumn: "TechnicalSpecificationsID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_WatchListMedia_WatchListMediaID",
                table: "Media",
                column: "WatchListMediaID",
                principalTable: "WatchListMedia",
                principalColumn: "WatchListMediaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MistakeTickets_AspNetUsers_UserID",
                table: "MistakeTickets",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListMedia_AspNetUsers_UserID",
                table: "WatchListMedia",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Media_MediaID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_UserID",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_TechnicalSpecifications_TechnicalSpecificationsID1",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_WatchListMedia_WatchListMediaID",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_MistakeTickets_AspNetUsers_UserID",
                table: "MistakeTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedia_AspNetUsers_UserID",
                table: "WatchListMedia");

            migrationBuilder.DropTable(
                name: "Bans");

            migrationBuilder.DropTable(
                name: "CommentReports");

            migrationBuilder.DropIndex(
                name: "IX_WatchListMedia_UserID",
                table: "WatchListMedia");

            migrationBuilder.DropIndex(
                name: "IX_MistakeTickets_UserID",
                table: "MistakeTickets");

            migrationBuilder.DropIndex(
                name: "IX_Media_TechnicalSpecificationsID1",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_WatchListMediaID",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Image_UserID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MediaID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "WatchListMedia");

            migrationBuilder.DropColumn(
                name: "Watchstatus",
                table: "WatchListMedia");

            migrationBuilder.DropColumn(
                name: "MediaID",
                table: "TechnicalSpecifications");

            migrationBuilder.DropColumn(
                name: "IdentityTestValue",
                table: "MistakeTickets");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "MistakeTickets");

            migrationBuilder.DropColumn(
                name: "TechnicalSpecificationsID1",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "WatchListMediaID",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "MediaID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Reports",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "MediaID",
                table: "WatchListMedia",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WatchListID",
                table: "WatchListMedia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WatchStatusID",
                table: "WatchListMedia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "City",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

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
                name: "IX_WatchListMedia_MediaID",
                table: "WatchListMedia",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_WatchListMedia_WatchListID",
                table: "WatchListMedia",
                column: "WatchListID");

            migrationBuilder.CreateIndex(
                name: "IX_WatchListMedia_WatchStatusID",
                table: "WatchListMedia",
                column: "WatchStatusID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListMedia_Media_MediaID",
                table: "WatchListMedia",
                column: "MediaID",
                principalTable: "Media",
                principalColumn: "MediaID",
                onDelete: ReferentialAction.Cascade);

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
