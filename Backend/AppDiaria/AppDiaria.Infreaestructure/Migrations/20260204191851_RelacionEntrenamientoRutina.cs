using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDiaria.Infreaestructure.Migrations
{
    /// <inheritdoc />
    public partial class RelacionEntrenamientoRutina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rutinas_Entrenamientos_EntrenamientosId",
                table: "Rutinas");

            migrationBuilder.DropIndex(
                name: "IX_Rutinas_EntrenamientosId",
                table: "Rutinas");

            migrationBuilder.DropColumn(
                name: "EntrenamientosId",
                table: "Rutinas");

            migrationBuilder.AddColumn<bool>(
                name: "EsPredeterminada",
                table: "Rutinas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EntrenamientoRutinas",
                columns: table => new
                {
                    EntrenamientoId = table.Column<int>(type: "INTEGER", nullable: false),
                    RutinaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntrenamientoRutinas", x => new { x.EntrenamientoId, x.RutinaId });
                    table.ForeignKey(
                        name: "FK_EntrenamientoRutinas_Entrenamientos_EntrenamientoId",
                        column: x => x.EntrenamientoId,
                        principalTable: "Entrenamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntrenamientoRutinas_Rutinas_RutinaId",
                        column: x => x.RutinaId,
                        principalTable: "Rutinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntrenamientoRutinas_RutinaId",
                table: "EntrenamientoRutinas",
                column: "RutinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntrenamientoRutinas");

            migrationBuilder.DropColumn(
                name: "EsPredeterminada",
                table: "Rutinas");

            migrationBuilder.AddColumn<int>(
                name: "EntrenamientosId",
                table: "Rutinas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rutinas_EntrenamientosId",
                table: "Rutinas",
                column: "EntrenamientosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rutinas_Entrenamientos_EntrenamientosId",
                table: "Rutinas",
                column: "EntrenamientosId",
                principalTable: "Entrenamientos",
                principalColumn: "Id");
        }
    }
}
