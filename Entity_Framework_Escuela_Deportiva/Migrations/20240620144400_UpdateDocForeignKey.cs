using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework_Escuela_Deportiva.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDocForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_Factura",
                table: "Estudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_foro_Docente_IdDocenteNavigationIdDocente",
                table: "foro");

            migrationBuilder.DropIndex(
                name: "IX_foro_IdDocenteNavigationIdDocente",
                table: "foro");

            migrationBuilder.DropIndex(
                name: "IX_Estudiante_IdFactura",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "IdDocenteNavigationIdDocente",
                table: "foro");

            migrationBuilder.DropColumn(
                name: "IdPublicacion",
                table: "foro");

            migrationBuilder.DropColumn(
                name: "IdFactura",
                table: "Estudiante");

            migrationBuilder.AddColumn<int>(
                name: "Doc",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Factura_Doc",
                table: "Factura",
                column: "Doc");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_Factura",
                table: "Estudiante",
                column: "Doc",
                principalTable: "Factura",
                principalColumn: "Doc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_Factura",
                table: "Estudiante");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Factura_Doc",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "Doc",
                table: "Factura");

            migrationBuilder.AddColumn<int>(
                name: "IdDocenteNavigationIdDocente",
                table: "foro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPublicacion",
                table: "foro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFactura",
                table: "Estudiante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_foro_IdDocenteNavigationIdDocente",
                table: "foro",
                column: "IdDocenteNavigationIdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_IdFactura",
                table: "Estudiante",
                column: "IdFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_Factura",
                table: "Estudiante",
                column: "IdFactura",
                principalTable: "Factura",
                principalColumn: "IdFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_foro_Docente_IdDocenteNavigationIdDocente",
                table: "foro",
                column: "IdDocenteNavigationIdDocente",
                principalTable: "Docente",
                principalColumn: "IdDocente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
