using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDiaria.Infreaestructure.Migrations
{
    /// <inheritdoc />
    public partial class ActualizaRecordatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recordatorios_Usuarios_UsuarioId",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Recordatorios");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Recordatorios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recordatorios_Usuarios_UsuarioId",
                table: "Recordatorios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recordatorios_Usuarios_UsuarioId",
                table: "Recordatorios");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Recordatorios",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Recordatorios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Recordatorios_Usuarios_UsuarioId",
                table: "Recordatorios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
