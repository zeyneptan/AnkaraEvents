using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnkaraEventsDeneme.Migrations
{
    public partial class Tickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tickets",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tickets",
                table: "Event");
        }
    }
}
