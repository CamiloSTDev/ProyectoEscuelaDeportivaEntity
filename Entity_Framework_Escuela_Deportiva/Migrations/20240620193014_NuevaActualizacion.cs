using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework_Escuela_Deportiva.Migrations
{
    /// <inheritdoc />
    public partial class NuevaActualizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ejemplo de una migración limpia sin crear una tabla ya existente

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_Factura",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "IdFactura",
                table: "Estudiante");

            migrationBuilder.AddColumn<int>(
                name: "Doc",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Doc",
                table: "Factura",
                column: "Doc",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Estudiante_Doc",
                table: "Factura",
                column: "Doc",
                principalTable: "Estudiante",
                principalColumn: "Doc",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Código para revertir los cambios
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Estudiante_Doc",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_Doc",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "Doc",
                table: "Factura");

            migrationBuilder.AddColumn<int>(
                name: "IdFactura",
                table: "Estudiante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_Factura",
                table: "Estudiante",
                column: "IdFactura",
                principalTable: "Factura",
                principalColumn: "IdFactura",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
