using Microsoft.EntityFrameworkCore.Migrations;

namespace Sewit.Data.Migrations
{
    public partial class AddedDressPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Dresses",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Dresses");
        }
    }
}
