using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteka.Data.Migrations
{
    public partial class migracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id",
                table: "Osoba");

            migrationBuilder.DropColumn(
                name: "biblioteka_id",
                table: "Osoba");

            migrationBuilder.DropColumn(
                name: "Bibliotekar_id",
                table: "Osoba");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Osoba");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Osoba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "biblioteka_id",
                table: "Osoba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bibliotekar_id",
                table: "Osoba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Osoba",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
