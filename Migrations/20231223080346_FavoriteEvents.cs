using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnkaraEventsDeneme.Migrations
{
    public partial class FavoriteEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FavoriteEvents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FavoriteEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
