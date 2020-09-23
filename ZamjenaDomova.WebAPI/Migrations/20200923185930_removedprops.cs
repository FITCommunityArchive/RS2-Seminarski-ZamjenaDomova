using Microsoft.EntityFrameworkCore.Migrations;

namespace ZamjenaDomova.WebAPI.Migrations
{
    public partial class removedprops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Listing");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Listing",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
