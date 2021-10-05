using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class NewInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ColorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentContent = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    CompanyTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => x.CompanyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageID);
                });

            migrationBuilder.CreateTable(
                name: "MediaType",
                columns: table => new
                {
                    MediaTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.MediaTypeID);
                });

            migrationBuilder.CreateTable(
                name: "MistakeTicketType",
                columns: table => new
                {
                    MistakeTicketTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MistakeTicketType", x => x.MistakeTicketTypeID);
                });

            migrationBuilder.CreateTable(
                name: "NewsType",
                columns: table => new
                {
                    NewsTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsType", x => x.NewsTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Occupation",
                columns: table => new
                {
                    OccupationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupation", x => x.OccupationID);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingID);
                });

            migrationBuilder.CreateTable(
                name: "SoundMix",
                columns: table => new
                {
                    SoundMixID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundMix", x => x.SoundMixID);
                });

            migrationBuilder.CreateTable(
                name: "UserRating",
                columns: table => new
                {
                    UserRatingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRating", x => x.UserRatingID);
                });

            migrationBuilder.CreateTable(
                name: "UserTicketType",
                columns: table => new
                {
                    UserTicketTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTicketType", x => x.UserTicketTypeID);
                });

            migrationBuilder.CreateTable(
                name: "WatchList",
                columns: table => new
                {
                    WatchListID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchList", x => x.WatchListID);
                });

            migrationBuilder.CreateTable(
                name: "WatchStatus",
                columns: table => new
                {
                    WatchStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchStatus", x => x.WatchStatusID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    CountryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    GenderID = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    DateOfDeath = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterID);
                    table.ForeignKey(
                        name: "FK_Character_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalSpecifications",
                columns: table => new
                {
                    TechnicalSpecificationsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspectRatio = table.Column<string>(nullable: true),
                    Camera = table.Column<string>(nullable: true),
                    Laboratory = table.Column<string>(nullable: true),
                    NegativeFormat = table.Column<string>(nullable: true),
                    CinematographicProcess = table.Column<string>(nullable: true),
                    PrintedFilmFormat = table.Column<string>(nullable: true),
                    ColorID = table.Column<int>(nullable: true),
                    SoundMixID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalSpecifications", x => x.TechnicalSpecificationsID);
                    table.ForeignKey(
                        name: "FK_TechnicalSpecifications_Color_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Color",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TechnicalSpecifications_SoundMix_SoundMixID",
                        column: x => x.SoundMixID,
                        principalTable: "SoundMix",
                        principalColumn: "SoundMixID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTickets",
                columns: table => new
                {
                    UserTicketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTicketTypeID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTickets", x => x.UserTicketID);
                    table.ForeignKey(
                        name: "FK_UserTickets_UserTicketType_UserTicketTypeID",
                        column: x => x.UserTicketTypeID,
                        principalTable: "UserTicketType",
                        principalColumn: "UserTicketTypeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: false),
                    CompanyTypeID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Company_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_CompanyType_CompanyTypeID",
                        column: x => x.CompanyTypeID,
                        principalTable: "CompanyType",
                        principalColumn: "CompanyTypeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityID = table.Column<int>(nullable: false),
                    LocationName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Location_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateOfDeath = table.Column<DateTime>(nullable: true),
                    CityID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Person_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    MediaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    EpisodeLength = table.Column<string>(nullable: true),
                    EpisodeCount = table.Column<int>(nullable: true),
                    Budget = table.Column<string>(nullable: false),
                    Earnings = table.Column<string>(nullable: true),
                    MediaTypeID = table.Column<int>(nullable: false),
                    CountryID = table.Column<int>(nullable: true),
                    LanguageID = table.Column<int>(nullable: false),
                    RatingID = table.Column<int>(nullable: false),
                    TechnicalSpecificationsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.MediaID);
                    table.ForeignKey(
                        name: "FK_Media_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Media_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Media_MediaType_MediaTypeID",
                        column: x => x.MediaTypeID,
                        principalTable: "MediaType",
                        principalColumn: "MediaTypeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Media_Rating_RatingID",
                        column: x => x.RatingID,
                        principalTable: "Rating",
                        principalColumn: "RatingID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Media_TechnicalSpecifications_TechnicalSpecificationsID",
                        column: x => x.TechnicalSpecificationsID,
                        principalTable: "TechnicalSpecifications",
                        principalColumn: "TechnicalSpecificationsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonOccupation",
                columns: table => new
                {
                    PersonOccupationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(nullable: false),
                    OccupationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonOccupation", x => x.PersonOccupationID);
                    table.ForeignKey(
                        name: "FK_PersonOccupation_Occupation_OccupationID",
                        column: x => x.OccupationID,
                        principalTable: "Occupation",
                        principalColumn: "OccupationID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonOccupation_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    CastID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.CastID);
                    table.ForeignKey(
                        name: "FK_Cast_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    CrewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.CrewID);
                    table.ForeignKey(
                        name: "FK_Crew_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageCaption = table.Column<string>(nullable: true),
                    ImageDescription = table.Column<string>(nullable: true),
                    ImageUniqueFilename = table.Column<string>(nullable: true),
                    MediaID = table.Column<int>(nullable: true),
                    PersonID = table.Column<int>(nullable: true),
                    LocationID = table.Column<int>(nullable: true),
                    CompanyID = table.Column<int>(nullable: true),
                    CharacterID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Image_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaCompany",
                columns: table => new
                {
                    MediaCompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaID = table.Column<int>(nullable: false),
                    CompanyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaCompany", x => x.MediaCompanyID);
                    table.ForeignKey(
                        name: "FK_MediaCompany_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MediaCompany_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MediaGenre",
                columns: table => new
                {
                    MediaGenreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaID = table.Column<int>(nullable: false),
                    GenreID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaGenre", x => x.MediaGenreID);
                    table.ForeignKey(
                        name: "FK_MediaGenre_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MediaGenre_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MediaLocation",
                columns: table => new
                {
                    MediaLocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaLocation", x => x.MediaLocationID);
                    table.ForeignKey(
                        name: "FK_MediaLocation_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MediaLocation_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MistakeTickets",
                columns: table => new
                {
                    MistakeTicketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MistakeTicketTypeID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    MediaID = table.Column<int>(nullable: true),
                    PersonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MistakeTickets", x => x.MistakeTicketID);
                    table.ForeignKey(
                        name: "FK_MistakeTickets_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MistakeTickets_MistakeTicketType_MistakeTicketTypeID",
                        column: x => x.MistakeTicketTypeID,
                        principalTable: "MistakeTicketType",
                        principalColumn: "MistakeTicketTypeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MistakeTickets_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    NewsContent = table.Column<string>(nullable: true),
                    NewsTypeID = table.Column<int>(nullable: false),
                    MediaID = table.Column<int>(nullable: true),
                    PersonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsID);
                    table.ForeignKey(
                        name: "FK_News_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_NewsType_NewsTypeID",
                        column: x => x.NewsTypeID,
                        principalTable: "NewsType",
                        principalColumn: "NewsTypeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_News_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaID = table.Column<int>(nullable: false),
                    UserRatingID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Review_UserRating_UserRatingID",
                        column: x => x.UserRatingID,
                        principalTable: "UserRating",
                        principalColumn: "UserRatingID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Soundtracks",
                columns: table => new
                {
                    SoundtrackID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    MediaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soundtracks", x => x.SoundtrackID);
                    table.ForeignKey(
                        name: "FK_Soundtracks_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WatchListMedia",
                columns: table => new
                {
                    WatchListMediaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WatchListID = table.Column<int>(nullable: false),
                    MediaID = table.Column<int>(nullable: false),
                    WatchStatusID = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateFinished = table.Column<DateTime>(nullable: true),
                    Progress = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchListMedia", x => x.WatchListMediaID);
                    table.ForeignKey(
                        name: "FK_WatchListMedia_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WatchListMedia_WatchList_WatchListID",
                        column: x => x.WatchListID,
                        principalTable: "WatchList",
                        principalColumn: "WatchListID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WatchListMedia_WatchStatus_WatchStatusID",
                        column: x => x.WatchStatusID,
                        principalTable: "WatchStatus",
                        principalColumn: "WatchStatusID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CastPerson",
                columns: table => new
                {
                    CastPersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CastID = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: false),
                    CharacterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastPerson", x => x.CastPersonID);
                    table.ForeignKey(
                        name: "FK_CastPerson_Cast_CastID",
                        column: x => x.CastID,
                        principalTable: "Cast",
                        principalColumn: "CastID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CastPerson_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CastPerson_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CrewPerson",
                columns: table => new
                {
                    CrewPersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrewID = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: false),
                    OccupationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewPerson", x => x.CrewPersonID);
                    table.ForeignKey(
                        name: "FK_CrewPerson_Crew_CrewID",
                        column: x => x.CrewID,
                        principalTable: "Crew",
                        principalColumn: "CrewID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CrewPerson_Occupation_OccupationID",
                        column: x => x.OccupationID,
                        principalTable: "Occupation",
                        principalColumn: "OccupationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CrewPerson_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SoundtrackPerson",
                columns: table => new
                {
                    SoundtrackPersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoundtrackID = table.Column<int>(nullable: false),
                    PerformedByID = table.Column<int>(nullable: false),
                    WrittenByID = table.Column<int>(nullable: true),
                    ProducedByID = table.Column<int>(nullable: true),
                    ConductedByID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundtrackPerson", x => x.SoundtrackPersonID);
                    table.ForeignKey(
                        name: "FK_SoundtrackPerson_Person_ConductedByID",
                        column: x => x.ConductedByID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoundtrackPerson_Person_PerformedByID",
                        column: x => x.PerformedByID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SoundtrackPerson_Person_ProducedByID",
                        column: x => x.ProducedByID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoundtrackPerson_Soundtracks_SoundtrackID",
                        column: x => x.SoundtrackID,
                        principalTable: "Soundtracks",
                        principalColumn: "SoundtrackID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SoundtrackPerson_Person_WrittenByID",
                        column: x => x.WrittenByID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cast_MediaID",
                table: "Cast",
                column: "MediaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CastPerson_CastID",
                table: "CastPerson",
                column: "CastID");

            migrationBuilder.CreateIndex(
                name: "IX_CastPerson_CharacterID",
                table: "CastPerson",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CastPerson_PersonID",
                table: "CastPerson",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Character_GenderID",
                table: "Character",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryID",
                table: "City",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CityID",
                table: "Company",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyTypeID",
                table: "Company",
                column: "CompanyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_MediaID",
                table: "Crew",
                column: "MediaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrewPerson_CrewID",
                table: "CrewPerson",
                column: "CrewID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewPerson_OccupationID",
                table: "CrewPerson",
                column: "OccupationID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewPerson_PersonID",
                table: "CrewPerson",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CharacterID",
                table: "Image",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CompanyID",
                table: "Image",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_LocationID",
                table: "Image",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_MediaID",
                table: "Image",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_PersonID",
                table: "Image",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CityID",
                table: "Location",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Media_CountryID",
                table: "Media",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Media_LanguageID",
                table: "Media",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MediaTypeID",
                table: "Media",
                column: "MediaTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Media_RatingID",
                table: "Media",
                column: "RatingID");

            migrationBuilder.CreateIndex(
                name: "IX_Media_TechnicalSpecificationsID",
                table: "Media",
                column: "TechnicalSpecificationsID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaCompany_CompanyID",
                table: "MediaCompany",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaCompany_MediaID",
                table: "MediaCompany",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaGenre_GenreID",
                table: "MediaGenre",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaGenre_MediaID",
                table: "MediaGenre",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaLocation_LocationID",
                table: "MediaLocation",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaLocation_MediaID",
                table: "MediaLocation",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_MistakeTickets_MediaID",
                table: "MistakeTickets",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_MistakeTickets_MistakeTicketTypeID",
                table: "MistakeTickets",
                column: "MistakeTicketTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MistakeTickets_PersonID",
                table: "MistakeTickets",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_News_MediaID",
                table: "News",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsTypeID",
                table: "News",
                column: "NewsTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_News_PersonID",
                table: "News",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CityID",
                table: "Person",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonOccupation_OccupationID",
                table: "PersonOccupation",
                column: "OccupationID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonOccupation_PersonID",
                table: "PersonOccupation",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MediaID",
                table: "Review",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserRatingID",
                table: "Review",
                column: "UserRatingID");

            migrationBuilder.CreateIndex(
                name: "IX_SoundtrackPerson_ConductedByID",
                table: "SoundtrackPerson",
                column: "ConductedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SoundtrackPerson_PerformedByID",
                table: "SoundtrackPerson",
                column: "PerformedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SoundtrackPerson_ProducedByID",
                table: "SoundtrackPerson",
                column: "ProducedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SoundtrackPerson_SoundtrackID",
                table: "SoundtrackPerson",
                column: "SoundtrackID");

            migrationBuilder.CreateIndex(
                name: "IX_SoundtrackPerson_WrittenByID",
                table: "SoundtrackPerson",
                column: "WrittenByID");

            migrationBuilder.CreateIndex(
                name: "IX_Soundtracks_MediaID",
                table: "Soundtracks",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSpecifications_ColorID",
                table: "TechnicalSpecifications",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSpecifications_SoundMixID",
                table: "TechnicalSpecifications",
                column: "SoundMixID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTickets_UserTicketTypeID",
                table: "UserTickets",
                column: "UserTicketTypeID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CastPerson");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CrewPerson");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "MediaCompany");

            migrationBuilder.DropTable(
                name: "MediaGenre");

            migrationBuilder.DropTable(
                name: "MediaLocation");

            migrationBuilder.DropTable(
                name: "MistakeTickets");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "PersonOccupation");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "SoundtrackPerson");

            migrationBuilder.DropTable(
                name: "UserTickets");

            migrationBuilder.DropTable(
                name: "WatchListMedia");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cast");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "MistakeTicketType");

            migrationBuilder.DropTable(
                name: "NewsType");

            migrationBuilder.DropTable(
                name: "Occupation");

            migrationBuilder.DropTable(
                name: "UserRating");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Soundtracks");

            migrationBuilder.DropTable(
                name: "UserTicketType");

            migrationBuilder.DropTable(
                name: "WatchList");

            migrationBuilder.DropTable(
                name: "WatchStatus");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "CompanyType");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "MediaType");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "TechnicalSpecifications");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "SoundMix");
        }
    }
}
