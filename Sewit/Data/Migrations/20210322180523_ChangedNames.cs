using Microsoft.EntityFrameworkCore.Migrations;

namespace Sewit.Data.Migrations
{
    public partial class ChangedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dresses_SleeveComponents_SleeveId",
                table: "Dresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Dresses_TopComponents_TopId",
                table: "Dresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopComponents",
                table: "TopComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SleeveComponents",
                table: "SleeveComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dresses",
                table: "Dresses");

            migrationBuilder.DropColumn(
                name: "SkirtId",
                table: "TopComponents");

            migrationBuilder.DropColumn(
                name: "SkirtId",
                table: "SleeveComponents");

            migrationBuilder.DropColumn(
                name: "ClothId",
                table: "Dresses");

            migrationBuilder.AddColumn<int>(
                name: "TopId",
                table: "TopComponents",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SleeveId",
                table: "SleeveComponents",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DressId",
                table: "Dresses",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopComponents",
                table: "TopComponents",
                column: "TopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SleeveComponents",
                table: "SleeveComponents",
                column: "SleeveId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dresses",
                table: "Dresses",
                column: "DressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dresses_SleeveComponents_SleeveId",
                table: "Dresses",
                column: "SleeveId",
                principalTable: "SleeveComponents",
                principalColumn: "SleeveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dresses_TopComponents_TopId",
                table: "Dresses",
                column: "TopId",
                principalTable: "TopComponents",
                principalColumn: "TopId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dresses_SleeveComponents_SleeveId",
                table: "Dresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Dresses_TopComponents_TopId",
                table: "Dresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopComponents",
                table: "TopComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SleeveComponents",
                table: "SleeveComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dresses",
                table: "Dresses");

            migrationBuilder.DropColumn(
                name: "TopId",
                table: "TopComponents");

            migrationBuilder.DropColumn(
                name: "SleeveId",
                table: "SleeveComponents");

            migrationBuilder.DropColumn(
                name: "DressId",
                table: "Dresses");

            migrationBuilder.AddColumn<int>(
                name: "SkirtId",
                table: "TopComponents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SkirtId",
                table: "SleeveComponents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ClothId",
                table: "Dresses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopComponents",
                table: "TopComponents",
                column: "SkirtId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SleeveComponents",
                table: "SleeveComponents",
                column: "SkirtId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dresses",
                table: "Dresses",
                column: "ClothId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dresses_SleeveComponents_SleeveId",
                table: "Dresses",
                column: "SleeveId",
                principalTable: "SleeveComponents",
                principalColumn: "SkirtId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dresses_TopComponents_TopId",
                table: "Dresses",
                column: "TopId",
                principalTable: "TopComponents",
                principalColumn: "SkirtId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
