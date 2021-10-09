using Microsoft.EntityFrameworkCore.Migrations;

namespace PeliculasAPI.Domain.Migrations
{
    public partial class RenameActoresProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Actores",
                newName: "Foto");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Actores",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "BirdthDate",
                table: "Actores",
                newName: "FechaNacimiento");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Actores",
                newName: "Biografia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Actores",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Actores",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "Actores",
                newName: "BirdthDate");

            migrationBuilder.RenameColumn(
                name: "Biografia",
                table: "Actores",
                newName: "Biography");
        }
    }
}
