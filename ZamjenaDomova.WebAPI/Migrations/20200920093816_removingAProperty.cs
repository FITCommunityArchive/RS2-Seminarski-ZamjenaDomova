using Microsoft.EntityFrameworkCore.Migrations;

namespace ZamjenaDomova.WebAPI.Migrations
{
    public partial class removingAProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreferredSwapTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreferredSwapTime",
                columns: table => new
                {
                    PreferredSwapTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_PreferredSwapTime_ListingId",
                table: "PreferredSwapTime",
                column: "ListingId");
        }
    }
}
