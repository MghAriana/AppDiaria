using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDiaria.Infreaestructure.Migrations
{
    /// <inheritdoc />
    public partial class CambioEnEntidadRutina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Rutinas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rutinas_UsuarioId",
                table: "Rutinas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rutinas_Usuarios_UsuarioId",
                table: "Rutinas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rutinas_Usuarios_UsuarioId",
                table: "Rutinas");

            migrationBuilder.DropIndex(
                name: "IX_Rutinas_UsuarioId",
                table: "Rutinas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Rutinas");
        }
    }
}
