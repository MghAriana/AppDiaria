using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDiaria.Infreaestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Tareas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Recordatorios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Entrenamientos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_UsuarioId",
                table: "Tareas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Recordatorios_UsuarioId",
                table: "Recordatorios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrenamientos_UsuarioId",
                table: "Entrenamientos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrenamientos_Usuarios_UsuarioId",
                table: "Entrenamientos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recordatorios_Usuarios_UsuarioId",
                table: "Recordatorios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Usuarios_UsuarioId",
                table: "Tareas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrenamientos_Usuarios_UsuarioId",
                table: "Entrenamientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recordatorios_Usuarios_UsuarioId",
                table: "Recordatorios");

            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Usuarios_UsuarioId",
                table: "Tareas");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_UsuarioId",
                table: "Tareas");

            migrationBuilder.DropIndex(
                name: "IX_Recordatorios_UsuarioId",
                table: "Recordatorios");

            migrationBuilder.DropIndex(
                name: "IX_Entrenamientos_UsuarioId",
                table: "Entrenamientos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Entrenamientos");
        }
    }
}
