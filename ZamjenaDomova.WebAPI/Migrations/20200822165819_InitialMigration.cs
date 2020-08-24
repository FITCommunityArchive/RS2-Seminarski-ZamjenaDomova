using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZamjenaDomova.WebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmenitiesCategory",
                columns: table => new
                {
                    AmenitiesCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenitiesCategory", x => x.AmenitiesCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Territory",
                columns: table => new
                {
                    TerritoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territory", x => x.TerritoryId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Amenity",
                columns: table => new
                {
                    AmenityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false),
                    AmenitiesCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenity", x => x.AmenityId);
                    table.ForeignKey(
                        name: "FK_Amenity_AmenitiesCategory_AmenitiesCategoryId",
                        column: x => x.AmenitiesCategoryId,
                        principalTable: "AmenitiesCategory",
                        principalColumn: "AmenitiesCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    ListingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ListingDescription = table.Column<string>(nullable: true),
                    AreaDescription = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    TerritoryId = table.Column<int>(nullable: false),
                    Persons = table.Column<int>(nullable: false),
                    Beds = table.Column<int>(nullable: false),
                    Bathrooms = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.ListingId);
                    table.ForeignKey(
                        name: "FK_Listing_Territory_TerritoryId",
                        column: x => x.TerritoryId,
                        principalTable: "Territory",
                        principalColumn: "TerritoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listing_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    WishlistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.WishlistId);
                    table.ForeignKey(
                        name: "FK_Wishlist_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListingAmenity",
                columns: table => new
                {
                    ListingAmenityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingId = table.Column<int>(nullable: false),
                    AmenityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingAmenity", x => x.ListingAmenityId);
                    table.ForeignKey(
                        name: "FK_ListingAmenity_Amenity_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenity",
                        principalColumn: "AmenityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListingAmenity_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "ListingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListingImage",
                columns: table => new
                {
                    ListingImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(nullable: true),
                    ListingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingImage", x => x.ListingImageId);
                    table.ForeignKey(
                        name: "FK_ListingImage_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "ListingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreferredSwapTime",
                columns: table => new
                {
                    PreferredSwapTimeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ListingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferredSwapTime", x => x.PreferredSwapTimeId);
                    table.ForeignKey(
                        name: "FK_PreferredSwapTime_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "ListingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingValue = table.Column<int>(nullable: false),
                    ListingId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Rating_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "ListingId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rating_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistListing",
                columns: table => new
                {
                    WishlistListingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WishlistId = table.Column<int>(nullable: false),
                    ListingId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistListing", x => x.WishlistListingId);
                    table.ForeignKey(
                        name: "FK_WishlistListing_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "ListingId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WishlistListing_Wishlist_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlist",
                        principalColumn: "WishlistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenity_AmenitiesCategoryId",
                table: "Amenity",
                column: "AmenitiesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_TerritoryId",
                table: "Listing",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_UserId",
                table: "Listing",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingAmenity_AmenityId",
                table: "ListingAmenity",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingAmenity_ListingId",
                table: "ListingAmenity",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingImage_ListingId",
                table: "ListingImage",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferredSwapTime_ListingId",
                table: "PreferredSwapTime",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ListingId",
                table: "Rating",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_UserId",
                table: "Wishlist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistListing_ListingId",
                table: "WishlistListing",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistListing_WishlistId",
                table: "WishlistListing",
                column: "WishlistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingAmenity");

            migrationBuilder.DropTable(
                name: "ListingImage");

            migrationBuilder.DropTable(
                name: "PreferredSwapTime");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "WishlistListing");

            migrationBuilder.DropTable(
                name: "Amenity");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Listing");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "AmenitiesCategory");

            migrationBuilder.DropTable(
                name: "Territory");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
