using Microsoft.EntityFrameworkCore.Migrations;

namespace Sewit.Data.Migrations
{
    public partial class AddModels_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkirtComponents",
                columns: table => new
                {
                    SkirtId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkirtComponents", x => x.SkirtId);
                });

            migrationBuilder.CreateTable(
                name: "SleeveComponents",
                columns: table => new
                {
                    SkirtId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleeveComponents", x => x.SkirtId);
                });

            migrationBuilder.CreateTable(
                name: "TopComponents",
                columns: table => new
                {
                    SkirtId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopComponents", x => x.SkirtId);
                });

            migrationBuilder.CreateTable(
                name: "Dresses",
                columns: table => new
                {
                    ClothId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(nullable: true),
                    TopId = table.Column<int>(nullable: false),
                    SkirtId = table.Column<int>(nullable: false),
                    SleeveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dresses", x => x.ClothId);
                    table.ForeignKey(
                        name: "FK_Dresses_SkirtComponents_SkirtId",
                        column: x => x.SkirtId,
                        principalTable: "SkirtComponents",
                        principalColumn: "SkirtId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dresses_SleeveComponents_SleeveId",
                        column: x => x.SleeveId,
                        principalTable: "SleeveComponents",
                        principalColumn: "SkirtId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dresses_TopComponents_TopId",
                        column: x => x.TopId,
                        principalTable: "TopComponents",
                        principalColumn: "SkirtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dresses_SkirtId",
                table: "Dresses",
                column: "SkirtId");

            migrationBuilder.CreateIndex(
                name: "IX_Dresses_SleeveId",
                table: "Dresses",
                column: "SleeveId");

            migrationBuilder.CreateIndex(
                name: "IX_Dresses_TopId",
                table: "Dresses",
                column: "TopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dresses");

            migrationBuilder.DropTable(
                name: "SkirtComponents");

            migrationBuilder.DropTable(
                name: "SleeveComponents");

            migrationBuilder.DropTable(
                name: "TopComponents");
        }
    }
}
